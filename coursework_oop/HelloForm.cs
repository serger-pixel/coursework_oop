using System;
using System.Windows.Forms;

namespace coursework_oop
{
    /// <summary>
    /// Приветственная форма, отображаемая при запуске приложения.
    /// Через заданное время автоматически закрывается и открывает главное окно.
    /// </summary>
    public partial class HelloForm : Form
    {
        /// <summary>
        /// Таймер для автоматического перехода на главное окно.
        /// </summary>
        private System.Windows.Forms.Timer _timer;

        /// <summary>
        /// Инициализирует компоненты формы и запускает таймер.
        /// </summary>
        public HelloForm()
        {
            InitializeComponent();
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 5000;
            _timer.Tick += OnTimerTick;
            _timer.Start();
        }

        /// <summary>
        /// Обработчик события Tick таймера. 
        /// Скрывает текущую форму и открывает главное окно приложения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
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