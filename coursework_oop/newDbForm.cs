using System.Windows.Forms;

namespace coursework_oop
{
    /// <summary>
    /// Форма для создания новой базы данных.
    /// Позволяет пользователю указать путь и имя файла БД, затем создаёт её и открывает для работы.
    /// </summary>
    public partial class newDbForm : Form
    {
        /// <summary>
        /// Экземпляр контроллера, управляющего взаимодействием с базой данных.
        /// </summary>
        private Controller _controller;

        /// <summary>
        /// Ссылка на главную форму для обновления интерфейса после создания БД.
        /// </summary>
        private MainForm _mainForm;

        /// <summary>
        /// Инициализирует новый экземпляр формы newDbForm.
        /// </summary>
        /// <param name="dataBaseWorker">Экземпляр контроллера для работы с БД.</param>
        /// <param name="mainForm">Ссылка на главную форму приложения.</param>
        public newDbForm(Controller dataBaseWorker, MainForm mainForm)
        {
            _controller = dataBaseWorker;
            _mainForm = mainForm;
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Создать БД".
        /// Открывает новую базу данных по указанному пути, обновляет таблицу в главной форме и закрывает текущее окно.
        /// </summary>
        private void createBdButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.openDataBase(pathTextBox.Text + "\\" + nameTextBox.Text + ".db", Statuses.NEW);
                List<Tenant> tenantList = _controller.GetAllTenants();
                _mainForm.FillMainTable(tenantList);
                _mainForm.deleteDbButton.Enabled = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки выбора пути сохранения БД.
        /// Открывает диалог выбора папки и устанавливает выбранный путь в текстовое поле.
        /// </summary>
        private void pathButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = @"C:\";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedworkPath = folderDialog.SelectedPath;
                }

                pathTextBox.Text = folderDialog.SelectedPath;
            }
        }
    }
}