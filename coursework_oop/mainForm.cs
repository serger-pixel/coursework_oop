using iTextSharp.text;
using iTextSharp.text.pdf;

namespace coursework_oop
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект контроллера, управляющий взаимодействием с базой данных.
        /// </summary>
        private Controller _controller;

        /// <summary>
        /// Хранит значение ячейки до её редактирования для отката изменений при ошибке.
        /// </summary>
        private string _currentValue;

        /// <summary>
        /// Общее количество записей в таблице.
        /// </summary>
        public int cntAllRecords = 0;

        /// <summary>
        /// Количество найденных записей после фильтрации.
        /// </summary>
        public int cntFindRecords = 0;

        /// <summary>
        /// Текущий критерий поиска (например, "Имя", "ID").
        /// </summary>
        public string crit;

        /// <summary>
        /// Значение, используемое для поиска записей.
        /// </summary>
        public string critValue;

        /// <summary>
        /// Флаг, указывающий, открыта ли сейчас база данных.
        /// </summary>
        private bool isOpen = false;

        /// <summary>
        /// Конструктор главной формы.
        /// Инициализирует элементы управления и настраивает начальное состояние формы.
        /// </summary>
        /// <param name="dataBaseWorker">Экземпляр контроллера для работы с базой данных.</param>
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

            searchBox.TextChanged += find;

            cntFindLabel.Text = "Всего записей: 0";
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
        /// Обработчик события нажатия на кнопку открытия базы данных.
        /// Открывает диалоговое окно для выбора файла базы данных (.db),
        /// загружает данные из выбранной базы и обновляет интерфейс.
        /// </summary>
        /// <param name="sender">Источник события (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
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
                    cntFindLabel.Text = $"Всего записей: {cntAllRecords}";
                    openDbButton.Enabled = false;
                    closeDbButton.Enabled = true;
                    isOpen = !isOpen;
                }
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку закрытия текущей базы данных.
        /// Очищает таблицу данных, сбрасывает счётчики и обновляет состояние элементов управления.
        /// </summary>
        /// <param name="sender">Источник события (кнопка закрытия базы данных).</param>
        /// <param name="e">Аргументы события.</param>
        private void closeDbButton_Click(object sender, EventArgs e)
        {
            mainTable.Rows.Clear();
            cntFindLabel.Text = "Всего записей: 0";
            openDbButton.Enabled = true;
            closeDbButton.Enabled = false;
            isOpen = !isOpen;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку создания новой записи или базы данных.
        /// Проверяет, открыта ли текущая база данных. Если да — открывает диалоговое окно для создания новой записи.
        /// </summary>
        /// <param name="sender">Источник события (кнопка создания).</param>
        /// <param name="e">Аргументы события.</param>
        private void createButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("База данных не открыта");
                return;
            }
            newDbForm subForm = new newDbForm(_controller, this);
            subForm.ShowDialog();
        }

        /// <summary>
        /// Обработчик события начала редактирования ячейки в DataGridView.
        /// Сохраняет текущее значение ячейки перед редактированием для последующего восстановления в случае ошибки.
        /// </summary>
        /// <param name="sender">Источник события (объект, инициировавший событие).</param>
        /// <param name="e">Аргументы события.</param>
        private void safeCurrentValue(object sender, EventArgs e)
        {
            int currentRow = mainTable.CurrentCell.RowIndex;
            int currentColumn = mainTable.CurrentCell.ColumnIndex;
            _currentValue = mainTable.Rows[currentRow].Cells[currentColumn].Value.ToString();
        }

        /// <summary>
        /// Обработчик события завершения редактирования ячейки в таблице.
        /// Обновляет данные записи в базе данных через контроллер.
        /// При возникновении ошибки откатывает изменение ячейки к предыдущему значению.
        /// </summary>
        /// <param name="sender">Источник события (таблица).</param>
        /// <param name="e">Аргументы события.</param>
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
        /// Обработчик события поиска записей в таблице.
        /// Фильтрует данные на основе выбранного критерия и значения из текстового поля.
        /// Подсвечивает совпадающие строки и обновляет статистику.
        /// </summary>
        /// <param name="sender">Источник события (обычно текстовое поле).</param>
        /// <param name="e">Аргументы события.</param>
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
                cntFindLabel.Text = $"Всего записей: {cntAllRecords}";
                return;
            }
            int ind = -1;
            switch (crit)
            {
                case "ID":
                    ind = 0;
                    break;
                case "Имя":
                    ind = 2;
                    break;
                case "Фамилия":
                    ind = 1;
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
            cntFindLabel.Text = $"Найдено: {cntFindRecords} из {cntAllRecords}";
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить".
        /// Вызывает метод контроллера для сохранения текущих данных в базу.
        /// </summary>
        private void safeButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("База данных не открыта");
                return;
            }
            _controller.safeDb();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить запись".
        /// Открывает форму добавления новой записи как модальное окно.
        /// После добавления вызывает обновление таблицы и поиск.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("База данных не открыта");
                return;
            }
            AddRecordForm subForm = new AddRecordForm(_controller, this);
            subForm.ShowDialog();
            find(null, null);
        }

        /// <summary>
        /// Заполняет DataGridView данными из списка арендаторов.
        /// Предварительно очищает таблицу.
        /// </summary>
        /// <param name="tenants">Список объектов Tenant для отображения в таблице.</param>
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
        /// Обработчик нажатия кнопки "Удалить БД".
        /// Удаляет текущую базу данных через контроллер и очищает таблицу.
        /// </summary>
        private void deleteDbButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("База данных не открыта");
                return;
            }
            mainTable.Rows.Clear();
            _controller.deleteDataBase();
            find(null, null);
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Удалить запись".
        /// Удаляет выбранную запись из БД и обновляет таблицу.
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("База данных не открыта");
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
        /// Обработчик изменения выбранного критерия поиска.
        /// Вызывает поиск без дополнительных параметров.
        /// </summary>
        private void searchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            find(null, null);
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Фильтр".
        /// Открывает форму фильтрации записей как модальное окно.
        /// </summary>
        private void filterButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("База данных не открыта");
                return;
            }
            FilterForm subForm = new FilterForm(_controller, this);
            subForm.ShowDialog();
        }

        /// <summary>
        /// Экспортирует данные из DataGridView в файл формата PDF.
        /// Показывает диалог выбора пути сохранения.
        /// </summary>
        /// <param name="dataGridView">Таблица с данными для экспорта.</param>
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

                    MessageBox.Show("Данные успешно экспортированы в PDF!", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при экспорте в PDF:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    document.Close();
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Экспорт в PDF".
        /// Вызывает метод экспорта данных таблицы в PDF-файл.
        /// </summary>
        private void exportButton_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("База данных не открыта");
                return;
            }

            exportDataGridViewToPdf(mainTable);
        }
    }
}
