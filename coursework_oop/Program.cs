namespace coursework_oop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DataBaseWorker worker = new DataBaseWorker("D:\\univer\\oop\\cr\\projects\\coursework_oop\\databases\\test.db");
            Tenant person = worker.select(10);
        }
    }
}