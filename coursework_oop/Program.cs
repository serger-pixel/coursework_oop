namespace coursework_oop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DataBaseWorker dataBaseworker = new DataBaseWorker();
            Application.Run(new Form1(dataBaseworker));
        }
    }
}