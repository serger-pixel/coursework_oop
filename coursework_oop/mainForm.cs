using System.Windows.Forms;

namespace coursework_oop
{
    public partial class MainForm : Form
    {
        private Controller _controller;
        private string _currentValue;
        private int cntRecords = 0;


        public MainForm(Controller dataBaseWorker)
        {
            InitializeComponent();
            _controller = dataBaseWorker;
            mainTable.ColumnCount = 7;
            mainTable.Columns[0].Name = "ID";
            mainTable.Columns[1].Name = "Фамилия";
            mainTable.Columns[2].Name = "Имя";
            mainTable.Columns[3].Name = "Номер квартиры";
            mainTable.Columns[4].Name = "Аренда";
            mainTable.Columns[5].Name = "Электричество";
            mainTable.Columns[6].Name = "Коммунальные услуги";
            mainTable.Columns[0].ReadOnly = true;
            mainTable.AllowUserToAddRows = false;
            mainTable.CellEndEdit += updateRecord;
            mainTable.CellBeginEdit += safeCurrentValue;
            mainTable.Dock = DockStyle.Fill;
            mainTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            searchComboBox.SelectedIndex = 0;

            searchBox.TextChanged += find;

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
                openFileDialog.Filter = "*.db|";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _controller.openDataBase(openFileDialog.FileName, Statuses.EXISTING);
                    List<Tenant> tenantList = _controller.GetAllTenants();
                    FillMainTable(tenantList);
                    deleteDbButton.Enabled = true;
                    
                }
            }
        }


        private void createButton_Click(object sender, EventArgs e)
        {
            newDbForm subForm = new newDbForm(_controller, this);
            subForm.ShowDialog();
        }

        private void safeCurrentValue(object sender, EventArgs e)
        {
            int currentRow = mainTable.CurrentCell.RowIndex;
            int currentColumn = mainTable.CurrentCell.ColumnIndex;
            _currentValue = mainTable.Rows[currentRow].Cells[currentColumn].Value.ToString();
        }
        private void updateRecord(object sender, EventArgs e)
        {
            int currentRow = mainTable.CurrentCell.RowIndex;
            int currentColumn = mainTable.CurrentCell.ColumnIndex;
            try
            {
                string id = mainTable.Rows[currentRow].Cells[0].Value.ToString();
                string lastName = mainTable.Rows[currentRow].Cells[1].Value.ToString();
                string firstName = mainTable.Rows[currentRow].Cells[2].Value.ToString();
                string apartNumb = mainTable.Rows[currentRow].Cells[3].Value.ToString();
                string rent = mainTable.Rows[currentRow].Cells[4].Value.ToString();
                string electricity = mainTable.Rows[currentRow].Cells[5].Value.ToString();
                string utilities = mainTable.Rows[currentRow].Cells[6].Value.ToString();
                _controller.updateRecord(id, firstName, lastName, apartNumb,
                    rent, electricity, utilities);
            }
            catch (Exception ex)
            {
                mainTable.Rows[currentRow].Cells[currentColumn].Value = _currentValue;
                MessageBox.Show(ex.Message);
            }
        }

        private void find(object sender, EventArgs e)
        {
            string crit = searchComboBox.Text;
            string findText = searchBox.Text;
            for (int i = 0; i < mainTable.Rows.Count; i++)
            {
                mainTable.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
            if (findText.Length == 0)
            {
                return;
            }
            int ind = -1;
            switch (crit)
            {
                case "ID":
                    ind = 0;
                    break;
                case "Имя":
                    ind = 1;
                    break;
                case "Фамилия":
                    ind = 2;
                    break;
                case "Номер квартиры":
                    ind = 3;
                    break;
                case "Аренда":
                    ind = 4;
                    break;
                case "Электричество":
                    ind = 5;
                    break;
                case "Коммунальные услуги":
                    ind = 6;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < mainTable.Rows.Count; i++)
            {
                string currentStr = mainTable.Rows[i].Cells[ind].Value.ToString();
                if (currentStr.Contains(findText))
                {
                    mainTable.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void safeButton_Click(object sender, EventArgs e)
        {
            _controller.safeDb();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddRecordForm subForm = new AddRecordForm(_controller, this);
            subForm.ShowDialog();
        }

        public void FillMainTable(List<Tenant> tenants)
        {
            mainTable.Rows.Clear();

            foreach (var tenant in tenants)
            {
                mainTable.Rows.Add(
                    tenant.Id,
                    tenant.LastName,
                    tenant.FirstName,
                    tenant.AppartamentNumb,
                    tenant.Rent,
                    tenant.Electricity,
                    tenant.Utilities
                );
            }
        }

        private void deleteDbButton_Click(object sender, EventArgs e)
        {
            mainTable.Rows.Clear();
            _controller.deleteDataBase();
            deleteDbButton.Enabled = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int current = mainTable.CurrentCell.RowIndex;
            if (current != -1)
            {
                _controller.deleteRecord(Convert.ToInt64(mainTable.Rows[current].Cells[0].Value));
                List<Tenant> tenantList = _controller.GetAllTenants();
                FillMainTable(tenantList);
                deleteDbButton.Enabled = true;
            }
        }

        private void searchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            find(null, null);
        }
    }
}
