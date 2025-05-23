using System.Windows.Forms;

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
                    DataBaseWorker worker = new DataBaseWorker();
                    worker.openDataBase(openFileDialog.FileName, Statuses.EXISTING);
                    table.DataSource = DataBaseWorker.pathOfCopy;
                }
            }
        }

        private void createButton_Click(object sender, EventArgs e)
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
                    DataBaseWorker worker = new DataBaseWorker();
                    worker.openDataBase(openFileDialog.FileName, Statuses.NEW);
                    table.DataSource = DataBaseWorker.pathOfCopy;
                }
            }
        }
    }
}
