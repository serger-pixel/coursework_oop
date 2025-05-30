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
    public partial class AddRecordForm : Form
    {
        private Controller _controller;

        private MainForm _mainForm;
        public AddRecordForm(Controller controller, MainForm mainForm)
        {
            _controller = controller;
            _mainForm = mainForm;

            InitializeComponent();

            idValue.Minimum = RegsAndConsts.minId;
            idValue.Maximum = RegsAndConsts.maxId;

            apartNumbValue.Minimum = RegsAndConsts.minNumbAppart;
            apartNumbValue.Maximum = RegsAndConsts.maxNumbAppart;

            rentValue.Minimum = RegsAndConsts.minRent;
            rentValue.Maximum = RegsAndConsts.maxRent;

            electricityValue.Minimum = RegsAndConsts.minElectricity;
            electricityValue.Maximum = RegsAndConsts.maxElectricity;

            utilitiesValue.Minimum = RegsAndConsts.minUtilities;
            utilitiesValue.Maximum = RegsAndConsts.maxUtilities;
        }

        public void createButton_Click(object sender, EventArgs e)
        {
            try
            {

                string firstName = firstNameValue.Text;
                string lastName = lastNameValue.Text;
                long id = (long)idValue.Value;
                int apartNumb = (int)apartNumbValue.Value;
                double rent = (double)rentValue.Value;
                double electricity = (double)electricityValue.Value;
                double utilities = (double)utilitiesValue.Value;

                _controller.addRecord(id, firstName, lastName, apartNumb,
                    rent, electricity, utilities);
                List<Tenant> tenantList = _controller.GetAllTenants();
                _mainForm.FillMainTable(tenantList);
                _mainForm.deleteDbButton.Enabled = true;
                Close();
                _mainForm.saveButton.Enabled = true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
