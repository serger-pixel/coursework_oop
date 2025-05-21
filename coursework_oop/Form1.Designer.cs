namespace coursework_oop
{
    partial class Form1
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
            table = new DataGridView();
            openButton = new Button();
            createButton = new Button();
            deleteButton = new Button();
            safeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Location = new Point(3, 67);
            table.Name = "table";
            table.RowHeadersWidth = 62;
            table.Size = new Size(1304, 520);
            table.TabIndex = 0;
            // 
            // openButton
            // 
            openButton.Location = new Point(3, 12);
            openButton.Name = "openButton";
            openButton.Size = new Size(112, 34);
            openButton.TabIndex = 1;
            openButton.Text = "Открыть";
            openButton.UseVisualStyleBackColor = true;
            openButton.Click += openButton_Click;
            // 
            // createButton
            // 
            createButton.Location = new Point(138, 12);
            createButton.Name = "createButton";
            createButton.Size = new Size(112, 34);
            createButton.TabIndex = 2;
            createButton.Text = "Создать";
            createButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(270, 12);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(112, 34);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Удалить";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // safeButton
            // 
            safeButton.Location = new Point(28, 599);
            safeButton.Name = "safeButton";
            safeButton.Size = new Size(112, 34);
            safeButton.TabIndex = 4;
            safeButton.Text = "Сохранить";
            safeButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 645);
            Controls.Add(safeButton);
            Controls.Add(deleteButton);
            Controls.Add(createButton);
            Controls.Add(openButton);
            Controls.Add(table);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView table;
        private Button openButton;
        private Button createButton;
        private Button deleteButton;
        private Button safeButton;
    }
}
