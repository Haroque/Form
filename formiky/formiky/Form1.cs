
namespace formiky
{
    public partial class Form1 : Form
    {
        List<Student> studenti= new List<Student>();
        string dataFilePath = "studenti.txt";
        public Form1()
        {
            InitializeComponent();

            try
            {
                using (StreamReader sr = new StreamReader("studenti.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');
                        Student st = new Student(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]));
                        studenti.Add(st);
                        comboBox1.Items.Add(st.Jmeno + " " + st.Prijmeni);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            MessageBox.Show("Student vytvoøen");

            comboBox1.Items.Add(textBox1.Text = " " + textBox2.Text);

            studenti.Add(st);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            try
            {
                using (StreamWriter sw = new StreamWriter("studenti.txt", true))
                {
                    sw.WriteLine(st.Jmeno + "," + st.Prijmeni + "," + st.Vek + "," + st.CisloTridy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            textBox5.Text = studenti[index].Jmeno;
            textBox6.Text = studenti[index].Prijmeni;
            textBox7.Text = studenti[index].Vek.ToString();
            textBox8.Text = studenti[index].CisloTridy.ToString();
            
        }
    }
    class Student
    {
        public string Jmeno;
        public string Prijmeni;
        public int Vek;
        public int CisloTridy;

        public Student(string jmeno, string prijmeni, int vek, int cislotridy)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            CisloTridy = cislotridy;
        }
    }
}