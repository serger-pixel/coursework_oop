using System.Windows.Forms;

namespace coursework_oop
{
    public partial class Form1 : Form
    {
        private DataBaseWorker dataBaseWorker;
        public Form1(DataBaseWorker dataBaseWorker)
        {
            InitializeComponent();
            this.dataBaseWorker = dataBaseWorker;
            mainTable.ColumnCount = 7;
            mainTable.Columns[0].Name = "ID";
            mainTable.Columns[1].Name = "Фамилия";
            mainTable.Columns[2].Name = "Имя";
            mainTable.Columns[3].Name = "Номер квартиры";
            mainTable.Columns[4].Name = "Аренда";
            mainTable.Columns[5].Name = "Электричество";
            mainTable.Columns[6].Name = "Коммунальные услуги";
            mainTable.Dock = DockStyle.Fill;
            mainTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            panelButtons.Height = 120;
            panelButtons.Dock = DockStyle.Top;

            SplitContainer splitContainer = new SplitContainer(); ;
            splitContainer.Orientation = Orientation.Horizontal;
            splitContainer.Panel1.Controls.Add(panelButtons);
            splitContainer.Panel2.Controls.Add(mainTable);
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.SplitterDistance = 1;

            Controls.Add(splitContainer);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.db)";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dataBaseWorker.openDataBase(openFileDialog.FileName, Statuses.EXISTING);
                    mainTable.DataSource = DataBaseWorker.pathOfCopy;
                }
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = @"C:\";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    dataBaseWorker.openDataBase(selectedPath, Statuses.NEW);
                }
            }
        }

        private void safeButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }
    }
}
