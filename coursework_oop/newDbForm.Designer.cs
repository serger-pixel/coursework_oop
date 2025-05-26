namespace coursework_oop
{
    partial class newDbForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            _controller.closeDataBase();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameDbLabel = new Label();
            nameTextBox = new TextBox();
            pathButton = new Button();
            pathTextBox = new TextBox();
            createBdButton = new Button();
            SuspendLayout();
            // 
            // nameDbLabel
            // 
            nameDbLabel.AutoSize = true;
            nameDbLabel.Location = new Point(121, 96);
            nameDbLabel.Name = "nameDbLabel";
            nameDbLabel.Size = new Size(157, 25);
            nameDbLabel.TabIndex = 0;
            nameDbLabel.Text = "Имя базы данных";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(315, 96);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(150, 31);
            nameTextBox.TabIndex = 1;
            // 
            // pathButton
            // 
            pathButton.Location = new Point(121, 189);
            pathButton.Name = "pathButton";
            pathButton.Size = new Size(157, 34);
            pathButton.TabIndex = 2;
            pathButton.Text = "Выбор папки";
            pathButton.UseVisualStyleBackColor = true;
            pathButton.Click += pathButton_Click;
            // 
            // pathTextBox
            // 
            pathTextBox.Location = new Point(315, 191);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new Size(150, 31);
            pathTextBox.TabIndex = 3;
            // 
            // createBdButton
            // 
            createBdButton.Location = new Point(241, 240);
            createBdButton.Name = "createBdButton";
            createBdButton.Size = new Size(112, 34);
            createBdButton.TabIndex = 4;
            createBdButton.Text = "Создать";
            createBdButton.UseVisualStyleBackColor = true;
            createBdButton.Click += createBdButton_Click;
            // 
            // newDbForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 282);
            Controls.Add(createBdButton);
            Controls.Add(pathTextBox);
            Controls.Add(pathButton);
            Controls.Add(nameTextBox);
            Controls.Add(nameDbLabel);
            Name = "newDbForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Открытие";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameDbLabel;
        private TextBox nameTextBox;
        private Button pathButton;
        private TextBox pathTextBox;
        private Button createBdButton;
    }
}