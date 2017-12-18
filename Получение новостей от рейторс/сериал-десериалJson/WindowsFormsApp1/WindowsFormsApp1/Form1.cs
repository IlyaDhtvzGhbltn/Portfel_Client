using Newtonsoft.Json;
using System.IO;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.JSON_s;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JSON_s.Person Person = new JSON_s.Person();
            Person.Name = textBox1.Text;
            //Person.FName = textBox2.Text;
            //Person.mail = textBox3.Text;
            var strConvert = JsonConvert.SerializeObject(Person);
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "json |* .json";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveDialog.FileName,strConvert);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             var Responce = new Person();
            OpenFileDialog opDialog = new OpenFileDialog();
            if (opDialog.ShowDialog() == DialogResult.OK)
            {
                Responce = JsonConvert.DeserializeObject<Person>(File.ReadAllText(opDialog.FileName));
            }
        }
    }
}
