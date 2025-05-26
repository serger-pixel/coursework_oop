using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace coursework_oop
{
    public partial class HelloForm : Form
    {
        System.Windows.Forms.Timer _timer;
        public HelloForm()
        {
            InitializeComponent();
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 5000;
            _timer.Tick += OnTimerTick;
            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _timer.Stop();
            Hide();
            Controller dataBaseworker = new Controller();
            MainForm mainForm = new MainForm(dataBaseworker);
            mainForm.FormClosed += (s, args) => Application.Exit();
            mainForm.Show();
            dataBaseworker.closeDataBase();
        }
    }
}
