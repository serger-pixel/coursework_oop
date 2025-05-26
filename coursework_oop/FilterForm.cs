using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework_oop
{
    public partial class FilterForm : Form
    {
        private Controller _controller;

        private MainForm _mainForm;

        public FilterForm(Controller controller, MainForm mainForm)
        {
            InitializeComponent();
            _controller = controller;
            _mainForm = mainForm;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<Tenant> definiteTenants = _controller.filter(filterBox.Text, valueBox.Text);
                _mainForm.FillMainTable(definiteTenants);
                _mainForm.cntFindRecords = definiteTenants.Count;
                _mainForm.cntAllRecords = _controller.GetAllTenants().Count;
                _mainForm.cntFindLabel.Text = $"Найдено: {_mainForm.cntFindRecords} из {_mainForm.cntAllRecords}";
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelFilterButton_Click(object sender, EventArgs e)
        {
            List<Tenant> allTenants = _controller.GetAllTenants();
            _mainForm.FillMainTable(allTenants);
            _mainForm.critValue = null;
            _mainForm.crit = null;
            _mainForm.cntFindLabel.Text = $"Всего записей: {allTenants.Count}";
            Close();
        }
    }
}
