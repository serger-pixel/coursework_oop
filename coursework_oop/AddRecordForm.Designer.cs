namespace coursework_oop
{
    partial class AddRecordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecordForm));
            firstNameLabel = new Label();
            lastNameLabel = new Label();
            apartNumbLabel = new Label();
            rentLabel = new Label();
            electricityLabel = new Label();
            utilitiesLabel = new Label();
            utilitiesValue = new NumericUpDown();
            electricityValue = new NumericUpDown();
            rentValue = new NumericUpDown();
            firstNameValue = new TextBox();
            lastNameValue = new TextBox();
            apartNumbValue = new NumericUpDown();
            createButton = new Button();
            idLable = new Label();
            idValue = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)utilitiesValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)electricityValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rentValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)apartNumbValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)idValue).BeginInit();
            SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(178, 91);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(47, 25);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "Имя";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(152, 37);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(85, 25);
            lastNameLabel.TabIndex = 1;
            lastNameLabel.Text = "Фамилия";
            // 
            // apartNumbLabel
            // 
            apartNumbLabel.AutoSize = true;
            apartNumbLabel.Location = new Point(71, 205);
            apartNumbLabel.Name = "apartNumbLabel";
            apartNumbLabel.Size = new Size(154, 25);
            apartNumbLabel.TabIndex = 2;
            apartNumbLabel.Text = "Номер квартиры";
            // 
            // rentLabel
            // 
            rentLabel.AutoSize = true;
            rentLabel.Location = new Point(152, 257);
            rentLabel.Name = "rentLabel";
            rentLabel.Size = new Size(73, 25);
            rentLabel.TabIndex = 3;
            rentLabel.Text = "Аренда";
            // 
            // electricityLabel
            // 
            electricityLabel.AutoSize = true;
            electricityLabel.Location = new Point(92, 302);
            electricityLabel.Name = "electricityLabel";
            electricityLabel.Size = new Size(133, 25);
            electricityLabel.TabIndex = 4;
            electricityLabel.Text = "Электричество";
            // 
            // utilitiesLabel
            // 
            utilitiesLabel.AutoSize = true;
            utilitiesLabel.Location = new Point(31, 342);
            utilitiesLabel.Name = "utilitiesLabel";
            utilitiesLabel.Size = new Size(194, 25);
            utilitiesLabel.TabIndex = 5;
            utilitiesLabel.Text = "Коммунальные услуги";
            // 
            // utilitiesValue
            // 
            utilitiesValue.DecimalPlaces = 4;
            utilitiesValue.Location = new Point(256, 336);
            utilitiesValue.Name = "utilitiesValue";
            utilitiesValue.Size = new Size(180, 31);
            utilitiesValue.TabIndex = 6;
            // 
            // electricityValue
            // 
            electricityValue.DecimalPlaces = 4;
            electricityValue.Location = new Point(256, 296);
            electricityValue.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            electricityValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            electricityValue.Name = "electricityValue";
            electricityValue.Size = new Size(180, 31);
            electricityValue.TabIndex = 6;
            electricityValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // rentValue
            // 
            rentValue.DecimalPlaces = 4;
            rentValue.Location = new Point(256, 251);
            rentValue.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            rentValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            rentValue.Name = "rentValue";
            rentValue.Size = new Size(180, 31);
            rentValue.TabIndex = 6;
            rentValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // firstNameValue
            // 
            firstNameValue.Location = new Point(256, 88);
            firstNameValue.Name = "firstNameValue";
            firstNameValue.Size = new Size(180, 31);
            firstNameValue.TabIndex = 7;
            // 
            // lastNameValue
            // 
            lastNameValue.Location = new Point(254, 37);
            lastNameValue.Name = "lastNameValue";
            lastNameValue.Size = new Size(180, 31);
            lastNameValue.TabIndex = 7;
            // 
            // apartNumbValue
            // 
            apartNumbValue.Location = new Point(256, 203);
            apartNumbValue.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            apartNumbValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            apartNumbValue.Name = "apartNumbValue";
            apartNumbValue.Size = new Size(180, 31);
            apartNumbValue.TabIndex = 6;
            apartNumbValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // createButton
            // 
            createButton.Location = new Point(230, 453);
            createButton.Name = "createButton";
            createButton.Size = new Size(112, 34);
            createButton.TabIndex = 8;
            createButton.Text = "Добавить";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // idLable
            // 
            idLable.AutoSize = true;
            idLable.Location = new Point(195, 153);
            idLable.Name = "idLable";
            idLable.Size = new Size(30, 25);
            idLable.TabIndex = 2;
            idLable.Text = "ID";
            // 
            // idValue
            // 
            idValue.Location = new Point(256, 151);
            idValue.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            idValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            idValue.Name = "idValue";
            idValue.Size = new Size(180, 31);
            idValue.TabIndex = 6;
            idValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // AddRecordForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 509);
            Controls.Add(createButton);
            Controls.Add(lastNameValue);
            Controls.Add(firstNameValue);
            Controls.Add(idValue);
            Controls.Add(apartNumbValue);
            Controls.Add(rentValue);
            Controls.Add(electricityValue);
            Controls.Add(utilitiesValue);
            Controls.Add(utilitiesLabel);
            Controls.Add(electricityLabel);
            Controls.Add(idLable);
            Controls.Add(rentLabel);
            Controls.Add(apartNumbLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddRecordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление";
            ((System.ComponentModel.ISupportInitialize)utilitiesValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)electricityValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)rentValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)apartNumbValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)idValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label firstNameLabel;
        private Label lastNameLabel;
        private Label apartNumbLabel;
        private Label rentLabel;
        private Label electricityLabel;
        private Label utilitiesLabel;
        private NumericUpDown utilitiesValue;
        private NumericUpDown electricityValue;
        private NumericUpDown rentValue;
        private TextBox firstNameValue;
        private TextBox lastNameValue;
        private NumericUpDown apartNumbValue;
        private Button createButton;
        private Label idLable;
        private NumericUpDown idValue;
    }
}