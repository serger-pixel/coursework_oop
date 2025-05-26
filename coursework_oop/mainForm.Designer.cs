namespace coursework_oop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainTable = new DataGridView();
            openDbButton = new Button();
            createDbButton = new Button();
            deleteButton = new Button();
            saveButton = new Button();
            panelButtons = new Panel();
            filterButton = new Button();
            textBox1 = new TextBox();
            searchLabel = new Label();
            addButton = new Button();
            deleteDbButton = new Button();
            ((System.ComponentModel.ISupportInitialize)mainTable).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // mainTable
            // 
            mainTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainTable.Location = new Point(2, 270);
            mainTable.Name = "mainTable";
            mainTable.RowHeadersWidth = 62;
            mainTable.Size = new Size(1304, 478);
            mainTable.TabIndex = 0;
            // 
            // openDbButton
            // 
            openDbButton.Location = new Point(29, 3);
            openDbButton.Name = "openDbButton";
            openDbButton.Size = new Size(214, 34);
            openDbButton.TabIndex = 1;
            openDbButton.Text = "Открыть базу данных";
            openDbButton.UseVisualStyleBackColor = true;
            openDbButton.Click += openButton_Click;
            // 
            // createDbButton
            // 
            createDbButton.Location = new Point(29, 42);
            createDbButton.Name = "createDbButton";
            createDbButton.Size = new Size(214, 34);
            createDbButton.TabIndex = 2;
            createDbButton.Text = "Создать базу данных";
            createDbButton.UseVisualStyleBackColor = true;
            createDbButton.Click += createButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(306, 43);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(177, 34);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Удалить запись";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(1001, 82);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(206, 34);
            saveButton.TabIndex = 4;
            saveButton.Text = "Сохранить изменения";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += safeButton_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(filterButton);
            panelButtons.Controls.Add(textBox1);
            panelButtons.Controls.Add(searchLabel);
            panelButtons.Controls.Add(addButton);
            panelButtons.Controls.Add(saveButton);
            panelButtons.Controls.Add(deleteDbButton);
            panelButtons.Controls.Add(deleteButton);
            panelButtons.Controls.Add(createDbButton);
            panelButtons.Controls.Add(openDbButton);
            panelButtons.Location = new Point(12, 22);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1294, 140);
            panelButtons.TabIndex = 5;
            // 
            // filterButton
            // 
            filterButton.Location = new Point(691, 12);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(129, 34);
            filterButton.TabIndex = 7;
            filterButton.Text = "Фильтрация";
            filterButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(895, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(312, 31);
            textBox1.TabIndex = 6;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(826, 12);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(63, 25);
            searchLabel.TabIndex = 5;
            searchLabel.Text = "Поиск";
            // 
            // addButton
            // 
            addButton.Location = new Point(306, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(177, 34);
            addButton.TabIndex = 3;
            addButton.Text = "Добавить запись";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // deleteDbButton
            // 
            deleteDbButton.Enabled = false;
            deleteDbButton.Location = new Point(29, 82);
            deleteDbButton.Name = "deleteDbButton";
            deleteDbButton.Size = new Size(214, 34);
            deleteDbButton.TabIndex = 3;
            deleteDbButton.Text = "Удалить базу данных";
            deleteDbButton.UseVisualStyleBackColor = true;
            deleteDbButton.Click += deleteDbButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1324, 912);
            Controls.Add(panelButtons);
            Controls.Add(mainTable);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)mainTable).EndInit();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView mainTable;
        private Button openDbButton;
        private Button createDbButton;
        private Button deleteButton;
        private Button saveButton;
        private Panel panelButtons;
        private Button addButton;
        public Button deleteDbButton;
        private Button filterButton;
        private TextBox textBox1;
        private Label searchLabel;
    }
}
