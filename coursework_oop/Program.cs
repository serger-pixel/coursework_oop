namespace coursework_oop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DataBaseWorker worker = new DataBaseWorker();
            bool result = File.Exists("D:\\univer\\oop\\cr\\projects\\coursework_oop\\databases\\test.db");
            worker.openDataBaseEditor("D:\\univer\\oop\\cr\\projects\\coursework_oop\\databases\\test.db", Statuses.EXISTING);
            worker.deleteDataBase();
        }
    }
}