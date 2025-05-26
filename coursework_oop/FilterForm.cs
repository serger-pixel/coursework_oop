using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace coursework_oop
{
    /// <summary>
    /// Форма фильтрации записей по заданному критерию.
    /// Позволяет пользователю выбрать поле и значение для фильтрации данных в таблице.
    /// </summary>
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Экземпляр контроллера для работы с базой данных.
        /// </summary>
        private Controller _controller;

        /// <summary>
        /// Ссылка на главную форму для обновления отображения данных.
        /// </summary>
        private MainForm _mainForm;

        /// <summary>
        /// Инициализирует новый экземпляр формы фильтрации.
        /// </summary>
        /// <param name="controller">Контроллер, управляющий логикой работы с данными.</param>
        /// <param name="mainForm">Главное окно приложения для обновления таблицы и меток.</param>
        public FilterForm(Controller controller, MainForm mainForm)
        {
            InitializeComponent();
            _controller = controller;
            _mainForm = mainForm;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Применить фильтр".
        /// Выполняет фильтрацию данных и обновляет таблицу в главной форме.
        /// </summary>
        private void filterButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<Tenant> definiteTenants = _controller.filter(filterBox.Text, valueBox.Text);
                _mainForm.FillMainTable(definiteTenants);
                _mainForm.cntFindRecords = definiteTenants.Count;
                _mainForm.cntAllRecords = _controller.GetAllTenants().Count;
                _mainForm.cntFindLabel.Text = $"Найдено: {_mainForm.cntFindRecords} из {_mainForm.cntAllRecords}";
                _mainForm.find(null, null);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отменить фильтр".
        /// Возвращает исходные данные и очищает фильтры в главной форме.
        /// </summary>
        private void cancelFilterButton_Click(object sender, EventArgs e)
        {
            List<Tenant> allTenants = _controller.GetAllTenants();
            _mainForm.FillMainTable(allTenants);
            _mainForm.critValue = null;
            _mainForm.crit = null;
            _mainForm.cntFindLabel.Text = $"Всего записей: {allTenants.Count}";
            _mainForm.find(null, null);
            Close();
        }
    }
}