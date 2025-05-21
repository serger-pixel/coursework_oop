namespace coursework_oop
{
    public partial class Form1 : Form
    {
        private DataBaseWorker dataBaseWorker;
        public Form1()
        {
            InitializeComponent();
            dataBaseWorker = new DataBaseWorker();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // ��������� ������� ��� ����� ������
                openFileDialog.Filter = "��������� ����� (*.db)|*.db|��� ����� (*.*)|*.*";
                openFileDialog.FilterIndex = 1; // ������������� ��������� ������ �� ���������
                openFileDialog.RestoreDirectory = true; // ��������������� ������� ���������� ����� ��������

                // ���������, ��� �� ������ ����
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dataBaseWorker.openDataBaseEditor(openFileDialog.FileName, Statuses.EXISTING);
                    table.DataSource = DataBaseWorker.pathOfCopy;
                }
            }
        }
    }
}
