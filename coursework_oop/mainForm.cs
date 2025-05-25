using System.Windows.Forms;

namespace coursework_oop
{
    public partial class MainForm : Form
    {
        private Controller _controller;
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

        private void safeButton_Click(object sender, EventArgs e)
        {

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


    }
}
