using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DZ_2_kfu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Police users = Deserialays();

            string way = System.IO.Directory.GetCurrentDirectory() + @"\account.png";/*"..\..\..\account.png"*/
            pictureBox1.Image = Image.FromFile(way);

            foreach (Polic man in users.UserList)
            {
                treeView1.Nodes[0].Nodes[0].Nodes.Add(man.Name);
            }
            foreach (Polic man in users.UserList1)
            {
                treeView1.Nodes[0].Nodes[1].Nodes.Add(man.Name);
            }

        }

        private Police Deserialays()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Police));

            using (FileStream fs = new FileStream(@"..\..\..\XMML.xml", FileMode.Open))
            {
                Police users = (Police)serializer.Deserialize(fs);
                return users;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                Police users = Deserialays();



                dataGridView1.AllowUserToAddRows = false;

                DataTable table = new DataTable();
                table.Columns.Add("Имя", typeof(string));
                table.Columns.Add("Возраст", typeof(int));
                table.Columns.Add("Опыт", typeof(int));

                foreach (Polic man in users.UserList)
                {
                    table.Rows.Add(man.Name, man.Age, man.Exp);
                }
                dataGridView1.DataSource = table;

            }
            else if (radioButton2.Checked)
            {

                Police users = Deserialays();

                dataGridView1.AllowUserToAddRows = false;

                DataTable table = new DataTable();
                table.Columns.Add("Имя", typeof(string));
                table.Columns.Add("Возраст", typeof(int));
                table.Columns.Add("Опыт", typeof(int));

                foreach (Polic man in users.UserList1)
                {
                    table.Rows.Add(man.Name, man.Age, man.Exp);
                }
                dataGridView1.DataSource = table;
            }
            
            else
            {
                
                MessageBox.Show("Выберите что-нибудь из списка", "Система", MessageBoxButtons.OK);
            }

            tabControl1.SelectedTab = tabPage2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    public class Police
    {
        public List<Investigator> UserList { get; set; } = new List<Investigator>();
        public List<Judge> UserList1 { get; set; } = new List<Judge>();
    }
    public class Polic
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Exp { get; set; }
        public Polic() { }
        public Polic(string Name, int Age, int Exp)
        {
            this.Name = Name;
            this.Age = Age;
            this.Exp = Exp;
        }
    }
    public class Investigator : Polic
    { }
    public class Judge : Polic
    { }
}

