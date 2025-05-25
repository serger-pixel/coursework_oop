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
    public partial class newDbForm : Form
    {
        private Controller _controller;
        private MainForm _mainForm;
        public newDbForm(Controller dataBaseWorker, MainForm  mainForm)
        {
            _controller = dataBaseWorker;
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void createBdButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.openDataBase(pathTextBox.Text + "\\" + nameTextBox.Text + ".db"
                , Statuses.NEW);
                List<Tenant> tenantList = _controller.GetAllTenants();
                _mainForm.FillMainTable(tenantList);
                _mainForm.deleteDbButton.Enabled = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = @"C:\";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                }
                pathTextBox.Text = folderDialog.SelectedPath;
            }
        }
    }
}
