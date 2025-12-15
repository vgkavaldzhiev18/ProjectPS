namespace ProjectPS
{
    partial class Form1
    {
        #region Windows Form Designer generated code

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIngredients;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.NumericUpDown numCookTime;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView gridRecipes;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.CheckBox chkFavorite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIngredients = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.numCookTime = new System.Windows.Forms.NumericUpDown();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gridRecipes = new System.Windows.Forms.DataGridView();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lblStats = new System.Windows.Forms.Label();
            this.chkFavorite = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCookTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecipes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(25, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 23);
            this.txtName.TabIndex = 22;
            // 
            // txtIngredients
            // 
            this.txtIngredients.Location = new System.Drawing.Point(25, 92);
            this.txtIngredients.Multiline = true;
            this.txtIngredients.Name = "txtIngredients";
            this.txtIngredients.Size = new System.Drawing.Size(240, 80);
            this.txtIngredients.TabIndex = 21;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(25, 204);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(240, 90);
            this.txtDescription.TabIndex = 20;
            // 
            // numCookTime
            // 
            this.numCookTime.Location = new System.Drawing.Point(25, 324);
            this.numCookTime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numCookTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCookTime.Name = "numCookTime";
            this.numCookTime.Size = new System.Drawing.Size(80, 23);
            this.numCookTime.TabIndex = 19;
            this.numCookTime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(25, 374);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(240, 23);
            this.cmbCategory.TabIndex = 18;
            this.cmbCategory.Items.AddRange(new object[] {
            "Основно",
            "Десерт",
            "Напитка",
            "Предястие",
            "Салата"});
            this.cmbCategory.SelectedIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(25, 450);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 27);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Добави";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(106, 450);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 27);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Запиши";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(187, 450);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Изтрий";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(25, 483);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(237, 27);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Изчисти";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gridRecipes
            // 
            this.gridRecipes.AllowUserToAddRows = false;
            this.gridRecipes.AllowUserToDeleteRows = false;
            this.gridRecipes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRecipes.Location = new System.Drawing.Point(285, 72);
            this.gridRecipes.MultiSelect = false;
            this.gridRecipes.Name = "gridRecipes";
            this.gridRecipes.ReadOnly = true;
            this.gridRecipes.RowHeadersVisible = false;
            this.gridRecipes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRecipes.Size = new System.Drawing.Size(520, 450);
            this.gridRecipes.TabIndex = 10;
            this.gridRecipes.SelectionChanged += new System.EventHandler(this.gridRecipes_SelectionChanged);
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.Location = new System.Drawing.Point(285, 40);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(180, 23);
            this.cmbFilterCategory.TabIndex = 9;
            this.cmbFilterCategory.Items.AddRange(new object[] {
            "Всички",
            "Основно",
            "Десерт",
            "Напитка",
            "Предястие",
            "Салата"});
            this.cmbFilterCategory.SelectedIndex = 0;
            this.cmbFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFilterCategory_SelectedIndexChanged);
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Location = new System.Drawing.Point(485, 40);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(180, 23);
            this.cmbSort.TabIndex = 8;
            this.cmbSort.Items.AddRange(new object[] {
            "Без",
            "Име (A→Z)",
            "Време (мин)"});
            this.cmbSort.SelectedIndex = 0;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(285, 536);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(0, 15);
            this.lblStats.TabIndex = 7;
            // 
            // chkFavorite
            // 
            this.chkFavorite.AutoSize = true;
            this.chkFavorite.Location = new System.Drawing.Point(25, 414);
            this.chkFavorite.Name = "chkFavorite";
            this.chkFavorite.Size = new System.Drawing.Size(73, 19);
            this.chkFavorite.TabIndex = 17;
            this.chkFavorite.Text = "Любима";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Име";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Съставки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Описание";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Време (мин)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Категория";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Филтър по категория";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(485, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Сортиране";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 720);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.gridRecipes);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chkFavorite);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.numCookTime);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtIngredients);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "Мениджър на рецепти";
            ((System.ComponentModel.ISupportInitialize)(this.numCookTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecipes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}