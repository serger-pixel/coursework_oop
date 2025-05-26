namespace coursework_oop
{
    partial class HelloForm
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelloForm));
            nameLabel = new Label();
            programLabel = new Label();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(242, 58);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(319, 39);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "С. Е. Ермаков 23ВП2";
            // 
            // programLabel
            // 
            programLabel.AutoSize = true;
            programLabel.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            programLabel.Location = new Point(166, 152);
            programLabel.Name = "programLabel";
            programLabel.Size = new Size(497, 39);
            programLabel.TabIndex = 0;
            programLabel.Text = "Информационная система \"Дом\"";
            // 
            // HelloForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 295);
            Controls.Add(programLabel);
            Controls.Add(nameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HelloForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Приветствие";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Label programLabel;
    }
}