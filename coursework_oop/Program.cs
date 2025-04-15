namespace coursework_oop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DataBaseWorker worker = new DataBaseWorker("D:\\univer\\oop\\cr\\projects\\coursework_oop\\databases\\test.db");
            Tenant person = new Tenant(10, "Sergey", "Ermakov", 100, 100, 100, 100);
            worker.add(person);
            
        }
    }
}