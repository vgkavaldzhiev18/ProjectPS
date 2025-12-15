using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace ProjectPS
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Recipe> _recipes = new();
        private readonly BindingSource _view = new();
        private const string DatabaseFileName = "recipes.db";

        public Form1()
        {
            InitializeComponent();
            LoadData();
            InitData();
        }

        private void InitData()
        {
            _view.DataSource = _recipes;
            gridRecipes.DataSource = _view;
            UpdateStats();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out var message))
            {
                MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var recipe = new Recipe
            {
                Name = txtName.Text.Trim(),
                Ingredients = txtIngredients.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                CookTime = (int)numCookTime.Value,
                Category = cmbCategory.Text,
                IsFavorite = chkFavorite.Checked
            };

            recipe.Id = SaveRecipeToDatabase(recipe);
            _recipes.Add(recipe);

            ClearForm();
            ApplyFilterAndSort();
            UpdateStats();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gridRecipes.CurrentRow?.DataBoundItem is not Recipe r)
            {
                MessageBox.Show("Изберете рецепта за редакция.");
                return;
            }

            if (!ValidateInput(out var message))
            {
                MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            r.Name = txtName.Text.Trim();
            r.Ingredients = txtIngredients.Text.Trim();
            r.Description = txtDescription.Text.Trim();
            r.CookTime = (int)numCookTime.Value;
            r.Category = cmbCategory.Text;
            r.IsFavorite = chkFavorite.Checked;

            UpdateRecipeInDatabase(r);

            gridRecipes.Refresh();
            ApplyFilterAndSort();
            UpdateStats();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridRecipes.CurrentRow?.DataBoundItem is not Recipe r) return;

            if (MessageBox.Show($"Изтриване на \"{r.Name}\"?", "Потвърждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteRecipeFromDatabase(r.Id);
                _recipes.Remove(r);
                ClearForm();
                ApplyFilterAndSort();
                UpdateStats();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void gridRecipes_SelectionChanged(object sender, EventArgs e)
        {
            if (gridRecipes.CurrentRow?.DataBoundItem is not Recipe r) return;

            txtName.Text = r.Name;
            txtIngredients.Text = r.Ingredients;
            txtDescription.Text = r.Description;
            numCookTime.Value = Math.Max(numCookTime.Minimum, Math.Min(numCookTime.Maximum, r.CookTime));
            cmbCategory.SelectedItem = r.Category ?? cmbCategory.Items.Cast<object>().FirstOrDefault();
            chkFavorite.Checked = r.IsFavorite;
        }

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndSort();
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndSort();

        private void ApplyFilterAndSort()
        {
            var category = cmbFilterCategory.SelectedItem?.ToString() ?? "Всички";
            var list = _recipes.AsEnumerable();

            if (category != "Всички")
                list = list.Where(r => r.Category == category);

            list = cmbSort.SelectedIndex switch
            {
                1 => list.OrderBy(r => r.Name),
                2 => list.OrderBy(r => r.CookTime),
                _ => list
            };

            _view.DataSource = new BindingList<Recipe>(list.ToList());
            gridRecipes.DataSource = _view;
            UpdateStats();
        }

        private bool ValidateInput(out string message)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                message = "Въведете име на рецепта.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIngredients.Text))
            {
                message = "Въведете съставки.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                message = "Въведете описание.";
                return false;
            }

            message = string.Empty;
            return true;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtIngredients.Clear();
            txtDescription.Clear();
            numCookTime.Value = numCookTime.Minimum;
            cmbCategory.SelectedIndex = 0;
            chkFavorite.Checked = false;
            gridRecipes.ClearSelection();
        }

        private void UpdateStats()
        {
            var total = _recipes.Count;
            var favs = _recipes.Count(r => r.IsFavorite);
            var byCat = _recipes
                .GroupBy(r => r.Category ?? "Неуточнено")
                .Select(g => $"{g.Key}: {g.Count()}");
            lblStats.Text = $"Общо: {total} | Любими: {favs} | " + string.Join(" | ", byCat);
        }

        private string GetDatabasePath()
        {
            var appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "ProjectPS");
            
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }
            
            return Path.Combine(appDataPath, DatabaseFileName);
        }

        private void InitializeDatabase()
        {
            var dbPath = GetDatabasePath();
            var connectionString = $"Data Source={dbPath}";

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var createTableSql = @"
                CREATE TABLE IF NOT EXISTS Recipes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Ingredients TEXT NOT NULL,
                    Description TEXT NOT NULL,
                    CookTime INTEGER NOT NULL,
                    Category TEXT,
                    ImagePath TEXT,
                    IsFavorite INTEGER NOT NULL DEFAULT 0
                )";

            using var command = new SqliteCommand(createTableSql, connection);
            command.ExecuteNonQuery();
        }

        private void LoadData()
        {
            try
            {
                InitializeDatabase();
                var dbPath = GetDatabasePath();
                var connectionString = $"Data Source={dbPath}";

                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                var selectSql = "SELECT Id, Name, Ingredients, Description, CookTime, Category, ImagePath, IsFavorite FROM Recipes";
                using var command = new SqliteCommand(selectSql, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var recipe = new Recipe
                    {
                        Id = reader.GetInt64(0),
                        Name = reader.GetString(1),
                        Ingredients = reader.GetString(2),
                        Description = reader.GetString(3),
                        CookTime = reader.GetInt32(4),
                        Category = reader.IsDBNull(5) ? null : reader.GetString(5),
                        ImagePath = reader.IsDBNull(6) ? null : reader.GetString(6),
                        IsFavorite = reader.GetInt32(7) != 0
                    };
                    _recipes.Add(recipe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при зареждане на данни: {ex.Message}", "Грешка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private long SaveRecipeToDatabase(Recipe recipe)
        {
            try
            {
                var dbPath = GetDatabasePath();
                var connectionString = $"Data Source={dbPath}";

                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                var insertSql = @"
                    INSERT INTO Recipes (Name, Ingredients, Description, CookTime, Category, ImagePath, IsFavorite)
                    VALUES (@Name, @Ingredients, @Description, @CookTime, @Category, @ImagePath, @IsFavorite);
                    SELECT last_insert_rowid();";

                using var command = new SqliteCommand(insertSql, connection);
                command.Parameters.AddWithValue("@Name", recipe.Name);
                command.Parameters.AddWithValue("@Ingredients", recipe.Ingredients);
                command.Parameters.AddWithValue("@Description", recipe.Description);
                command.Parameters.AddWithValue("@CookTime", recipe.CookTime);
                command.Parameters.AddWithValue("@Category", (object)recipe.Category ?? DBNull.Value);
                command.Parameters.AddWithValue("@ImagePath", (object)recipe.ImagePath ?? DBNull.Value);
                command.Parameters.AddWithValue("@IsFavorite", recipe.IsFavorite ? 1 : 0);

                return (long)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при запис на рецепта: {ex.Message}", "Грешка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void UpdateRecipeInDatabase(Recipe recipe)
        {
            try
            {
                var dbPath = GetDatabasePath();
                var connectionString = $"Data Source={dbPath}";

                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                var updateSql = @"
                    UPDATE Recipes 
                    SET Name = @Name, Ingredients = @Ingredients, Description = @Description, 
                        CookTime = @CookTime, Category = @Category, ImagePath = @ImagePath, IsFavorite = @IsFavorite
                    WHERE Id = @Id";

                using var command = new SqliteCommand(updateSql, connection);
                command.Parameters.AddWithValue("@Id", recipe.Id);
                command.Parameters.AddWithValue("@Name", recipe.Name);
                command.Parameters.AddWithValue("@Ingredients", recipe.Ingredients);
                command.Parameters.AddWithValue("@Description", recipe.Description);
                command.Parameters.AddWithValue("@CookTime", recipe.CookTime);
                command.Parameters.AddWithValue("@Category", (object)recipe.Category ?? DBNull.Value);
                command.Parameters.AddWithValue("@ImagePath", (object)recipe.ImagePath ?? DBNull.Value);
                command.Parameters.AddWithValue("@IsFavorite", recipe.IsFavorite ? 1 : 0);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при обновяване на рецепта: {ex.Message}", "Грешка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRecipeFromDatabase(long id)
        {
            try
            {
                var dbPath = GetDatabasePath();
                var connectionString = $"Data Source={dbPath}";

                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                var deleteSql = "DELETE FROM Recipes WHERE Id = @Id";

                using var command = new SqliteCommand(deleteSql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при изтриване на рецепта: {ex.Message}", "Грешка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }

    public class Recipe
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public int CookTime { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public bool IsFavorite { get; set; }
    }
}