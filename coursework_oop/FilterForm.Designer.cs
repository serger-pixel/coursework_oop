namespace coursework_oop
{
    partial class FilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            filterLabel = new Label();
            valueLabel = new Label();
            valueBox = new TextBox();
            filterBox = new ComboBox();
            filterButton = new Button();
            cancelFilterButton = new Button();
            SuspendLayout();
            // 
            // filterLabel
            // 
            filterLabel.AutoSize = true;
            filterLabel.Location = new Point(92, 51);
            filterLabel.Name = "filterLabel";
            filterLabel.Size = new Size(90, 25);
            filterLabel.TabIndex = 0;
            filterLabel.Text = "Критерий";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.Location = new Point(12, 101);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(170, 25);
            valueLabel.TabIndex = 0;
            valueLabel.Text = "Значение критерия";
            // 
            // valueBox
            // 
            valueBox.Location = new Point(219, 101);
            valueBox.Name = "valueBox";
            valueBox.Size = new Size(188, 31);
            valueBox.TabIndex = 1;
            // 
            // filterBox
            // 
            filterBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterBox.FormattingEnabled = true;
            filterBox.Items.AddRange(new object[] { "Фамилия", "Имя", "Номер квартиры", "Аренда", "Электричество", "Коммунальные услуги" });
            filterBox.Location = new Point(219, 46);
            filterBox.Name = "filterBox";
            filterBox.Size = new Size(182, 33);
            filterBox.TabIndex = 2;
            // 
            // filterButton
            // 
            filterButton.Location = new Point(473, 96);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(112, 34);
            filterButton.TabIndex = 3;
            filterButton.Text = "Найти";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += filterButton_Click;
            // 
            // cancelFilterButton
            // 
            cancelFilterButton.Location = new Point(419, 46);
            cancelFilterButton.Name = "cancelFilterButton";
            cancelFilterButton.Size = new Size(210, 34);
            cancelFilterButton.TabIndex = 4;
            cancelFilterButton.Text = "Отменить фильтрацию";
            cancelFilterButton.UseVisualStyleBackColor = true;
            cancelFilterButton.Click += cancelFilterButton_Click;
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 158);
            Controls.Add(cancelFilterButton);
            Controls.Add(filterButton);
            Controls.Add(filterBox);
            Controls.Add(valueBox);
            Controls.Add(valueLabel);
            Controls.Add(filterLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FilterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Фильтрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label filterLabel;
        private Label valueLabel;
        private TextBox valueBox;
        private ComboBox filterBox;
        private Button filterButton;
        private Button cancelFilterButton;
    }
}