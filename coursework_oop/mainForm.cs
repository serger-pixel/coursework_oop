using iTextSharp.text;
using iTextSharp.text.pdf;

namespace coursework_oop
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// ������ �����������, ����������� ��������������� � ����� ������.
        /// </summary>
        private Controller _controller;

        /// <summary>
        /// ������ �������� ������ �� � �������������� ��� ������ ��������� ��� ������.
        /// </summary>
        private string _currentValue;

        /// <summary>
        /// ����� ���������� ������� � �������.
        /// </summary>
        public int cntAllRecords = 0;

        /// <summary>
        /// ���������� ��������� ������� ����� ����������.
        /// </summary>
        public int cntFindRecords = 0;

        /// <summary>
        /// ������� �������� ������ (��������, "���", "ID").
        /// </summary>
        public string crit;

        /// <summary>
        /// ��������, ������������ ��� ������ �������.
        /// </summary>
        public string critValue;

        /// <summary>
        /// ����, �����������, ������� �� ������ ���� ������.
        /// </summary>
        private bool isOpen = false;

        /// <summary>
        /// ����������� ������� �����.
        /// �������������� �������� ���������� � ����������� ��������� ��������� �����.
        /// </summary>
        /// <param name="dataBaseWorker">��������� ����������� ��� ������ � ����� ������.</param>
        public MainForm(Controller dataBaseWorker)
        {
            InitializeComponent();
            _controller = dataBaseWorker;
            mainTable.ColumnCount = 7;
            mainTable.Columns[0].Name = "ID";
            mainTable.Columns[1].Name = "�������";
            mainTable.Columns[2].Name = "���";
            mainTable.Columns[3].Name = "����� ��������";
            mainTable.Columns[4].Name = "������";
            mainTable.Columns[5].Name = "�������������";
            mainTable.Columns[6].Name = "������������ ������";
            mainTable.Columns[0].ReadOnly = true;
            mainTable.AllowUserToAddRows = false;
            mainTable.CellEndEdit += updateRecord;
            mainTable.CellBeginEdit += safeCurrentValue;
            mainTable.Dock = DockStyle.Fill;
            mainTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            searchBox.TextChanged += find;

            cntFindLabel.Text = "����� �������: 0";
            cntFindLabel.Size = new Size(100, 25);

            panelButtons.Height = 180;
            panelButtons.Dock = DockStyle.Top;

            closeDbButton.Enabled = false;

            searchComboBox.Text = "ID";

            SplitContainer splitContainer = new SplitContainer(); ;
            splitContainer.Orientation = Orientation.Horizontal;
            splitContainer.Panel1.Controls.Add(panelButtons);
            splitContainer.Panel2.Controls.Add(mainTable);
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.SplitterDistance = 1;

            Controls.Add(splitContainer);

        }

        /// <summary>
        /// ���������� ������� ������� �� ������ �������� ���� ������.
        /// ��������� ���������� ���� ��� ������ ����� ���� ������ (.db),
        /// ��������� ������ �� ��������� ���� � ��������� ���������.
        /// </summary>
        /// <param name="sender">�������� ������� (������).</param>
        /// <param name="e">��������� �������.</param>
        private void openButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Database Files (*.db)|*.db";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _controller.openDataBase(openFileDialog.FileName, Statuses.EXISTING);
                    List<Tenant> tenantList = _controller.GetAllTenants();
                    FillMainTable(tenantList);
                    deleteDbButton.Enabled = true;
                    cntAllRecords = tenantList.Count;
                    cntFindLabel.Text = $"����� �������: {cntAllRecords}";
                    openDbButton.Enabled = false;
                    closeDbButton.Enabled = true;
                    isOpen = !isOpen;
                }
            }
        }

        /// <summary>
        /// ���������� ������� ������� �� ������ �������� ������� ���� ������.
        /// ������� ������� ������, ���������� �������� � ��������� ��������� ��������� ����������.
        /// </summary>
        /// <param name="sender">�������� ������� (������ �������� ���� ������).</param>
        /// <param name="e">��������� �������.</param>
        private void closeDbButton_Click(object sender, EventArgs e)
        {
            mainTable.Rows.Clear();
            cntFindLabel.Text = "����� �������: 0";
            openDbButton.Enabled = true;
            closeDbButton.Enabled = false;
            isOpen = !isOpen;
        }

        /// <summary>
        /// ���������� ������� ������� �� ������ �������� ����� ������ ��� ���� ������.
        /// ���������, ������� �� ������� ���� ������. ���� �� � ��������� ���������� ���� ��� �������� ����� ������.
        /// </summary>
        /// <param name="sender">�������� ������� (������ ��������).</param>
        /// <param name="e">��������� �������.</param>
        private void createButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("���� ������ �� �������");
                return;
            }
            newDbForm subForm = new newDbForm(_controller, this);
            subForm.ShowDialog();
        }

        /// <summary>
        /// ���������� ������� ������ �������������� ������ � DataGridView.
        /// ��������� ������� �������� ������ ����� ��������������� ��� ������������ �������������� � ������ ������.
        /// </summary>
        /// <param name="sender">�������� ������� (������, �������������� �������).</param>
        /// <param name="e">��������� �������.</param>
        private void safeCurrentValue(object sender, EventArgs e)
        {
            int currentRow = mainTable.CurrentCell.RowIndex;
            int currentColumn = mainTable.CurrentCell.ColumnIndex;
            _currentValue = mainTable.Rows[currentRow].Cells[currentColumn].Value.ToString();
        }

        /// <summary>
        /// ���������� ������� ���������� �������������� ������ � �������.
        /// ��������� ������ ������ � ���� ������ ����� ����������.
        /// ��� ������������� ������ ���������� ��������� ������ � ����������� ��������.
        /// </summary>
        /// <param name="sender">�������� ������� (�������).</param>
        /// <param name="e">��������� �������.</param>
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

        /// <summary>
        /// ���������� ������� ������ ������� � �������.
        /// ��������� ������ �� ������ ���������� �������� � �������� �� ���������� ����.
        /// ������������ ����������� ������ � ��������� ����������.
        /// </summary>
        /// <param name="sender">�������� ������� (������ ��������� ����).</param>
        /// <param name="e">��������� �������.</param>
        public void find(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                return;
            }
            cntAllRecords = _controller.GetAllTenants().Count;
            crit = searchComboBox.Text;
            critValue = searchBox.Text;
            for (int i = 0; i < mainTable.Rows.Count; i++)
            {
                mainTable.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
            if (critValue.Length == 0)
            {
                cntFindLabel.Text = $"����� �������: {cntAllRecords}";
                return;
            }
            int ind = -1;
            switch (crit)
            {
                case "ID":
                    ind = 0;
                    break;
                case "���":
                    ind = 2;
                    break;
                case "�������":
                    ind = 1;
                    break;
                case "����� ��������":
                    ind = 3;
                    break;
                case "������":
                    ind = 4;
                    break;
                case "�������������":
                    ind = 5;
                    break;
                case "������������ ������":
                    ind = 6;
                    break;
                default:
                    break;
            }
            cntFindRecords = 0;
            for (int i = 0; i < mainTable.Rows.Count; i++)
            {
                string currentStr = mainTable.Rows[i].Cells[ind].Value.ToString().ToLower();
                if (currentStr.Contains(critValue.ToLower()))
                {
                    mainTable.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                    cntFindRecords++;
                }
            }
            cntFindLabel.Text = $"�������: {cntFindRecords} �� {cntAllRecords}";
        }

        /// <summary>
        /// ���������� ������� ������ "���������".
        /// �������� ����� ����������� ��� ���������� ������� ������ � ����.
        /// </summary>
        private void safeButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("���� ������ �� �������");
                return;
            }
            _controller.safeDb();
        }

        /// <summary>
        /// ���������� ������� ������ "�������� ������".
        /// ��������� ����� ���������� ����� ������ ��� ��������� ����.
        /// ����� ���������� �������� ���������� ������� � �����.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("���� ������ �� �������");
                return;
            }
            AddRecordForm subForm = new AddRecordForm(_controller, this);
            subForm.ShowDialog();
            find(null, null);
        }

        /// <summary>
        /// ��������� DataGridView ������� �� ������ �����������.
        /// �������������� ������� �������.
        /// </summary>
        /// <param name="tenants">������ �������� Tenant ��� ����������� � �������.</param>
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

        /// <summary>
        /// ���������� ������� ������ "������� ��".
        /// ������� ������� ���� ������ ����� ���������� � ������� �������.
        /// </summary>
        private void deleteDbButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("���� ������ �� �������");
                return;
            }
            mainTable.Rows.Clear();
            _controller.deleteDataBase();
            find(null, null);
        }

        /// <summary>
        /// ���������� ������� ������ "������� ������".
        /// ������� ��������� ������ �� �� � ��������� �������.
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("���� ������ �� �������");
                return;
            }
            int current = mainTable.CurrentCell.RowIndex;
            if (current != -1)
            {
                _controller.deleteRecord(Convert.ToInt64(mainTable.Rows[current].Cells[0].Value));
                List<Tenant> tenantList = _controller.GetAllTenants();
                FillMainTable(tenantList);
                find(null, null);
            }

        }

        /// <summary>
        /// ���������� ��������� ���������� �������� ������.
        /// �������� ����� ��� �������������� ����������.
        /// </summary>
        private void searchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            find(null, null);
        }

        /// <summary>
        /// ���������� ������� ������ "������".
        /// ��������� ����� ���������� ������� ��� ��������� ����.
        /// </summary>
        private void filterButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("���� ������ �� �������");
                return;
            }
            FilterForm subForm = new FilterForm(_controller, this);
            subForm.ShowDialog();
        }

        /// <summary>
        /// ������������ ������ �� DataGridView � ���� ������� PDF.
        /// ���������� ������ ������ ���� ����������.
        /// </summary>
        /// <param name="dataGridView">������� � ������� ��� ��������.</param>
        public void exportDataGridViewToPdf(DataGridView dataGridView)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "some.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

                try
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                    document.Open();

                    PdfPTable table = new PdfPTable(dataGridView.Columns.Count);

                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new BaseColor(220, 220, 220);
                        table.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                table.AddCell(cell.Value.ToString());
                            }
                        }
                    }

                    document.Add(table);

                    MessageBox.Show("������ ������� �������������� � PDF!", "������� ��������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ��� �������� � PDF:\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    document.Close();
                }
            }
        }

        /// <summary>
        /// ���������� ������� ������ "������� � PDF".
        /// �������� ����� �������� ������ ������� � PDF-����.
        /// </summary>
        private void exportButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("���� ������ �� �������");
                return;
            }

            exportDataGridViewToPdf(mainTable);
        }
    }
}
