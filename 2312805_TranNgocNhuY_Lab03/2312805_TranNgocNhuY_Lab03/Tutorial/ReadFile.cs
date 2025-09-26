using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _2312805_TranNgocNhuY_Lab03.Tutorial
{
    public partial class ReadFile : Form
    {
        private List<Student> students;
        public ReadFile()
        {
            InitializeComponent();
        }

        //Read text file
        private void btnText_Click(object sender, EventArgs e)
        {
            students.Clear();
            Student s;
            foreach(string line in File.ReadAllLines("Tutorial\\Text.txt"))
            {
                s = new Student();
                string[] l = line.Split('|');
                s.Id = Convert.ToInt32(l[0]);
                s.Name = l[1].ToString();
                s.Age = Convert.ToInt32(l[2]);
                s.Grade = (float)Convert.ToDouble(l[3]);
                s.TonGiao = l[4].ToString();
                students.Add(s);
            }
            Display();
        }
        //Read Json file
        private void btnJson_Click(object sender, EventArgs e)
        {
            students.Clear();
            string Path = "G:\\STUDY\\PTUDD\\2312805_TranNgocNhuY-Lab03\\bin\\Debug\\Tutorial\\Text.json";
            LoadJson(Path);
            Display();
        }
        private void LoadJson(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string json = streamReader.ReadToEnd();
            var array = (JObject)JsonConvert.DeserializeObject(json);
            var student = array["Student"].Children();
            Student s;
            foreach(var item in student)
            {
                s = new Student();
                s.Id = Convert.ToInt32(item["Id"]);
                s.Name = Convert.ToString(item["Name"]);
                s.Age = Convert.ToInt32(item["Age"]);
                s.Grade = (float)Convert.ToDouble(item["Grade"]);
                s.TonGiao = Convert.ToString(item["TonGiao"]);
                students.Add(s);
            }
        }
        //Read XML file
        private void btnXML_Click(object sender, EventArgs e)
        {
            students.Clear();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("G:\\STUDY\\PTUDD\\2312805_TranNgocNhuY-Lab03\\bin\\Debug\\Tutorial\\Text.xml");
            var node = xmlDoc.DocumentElement.SelectNodes("/catalog/Student");
            Student student;
            foreach(XmlNode item in node)
            {
                student = new Student();
                student.Id = Convert.ToInt32(item.Attributes["Id"].Value);
                student.Name = item.SelectSingleNode("Name").InnerText;
                student.Age = Convert.ToInt32(item.SelectSingleNode("Age").InnerText);
                student.Grade = (float)(Convert.ToDouble(item.SelectSingleNode("Grade").InnerText));
                student.TonGiao = item.SelectSingleNode("TonGiao").InnerText;
                students.Add(student);
            }
            Display();
        }
        //Other functions
        private void Display()
        {
            string str = "";
            foreach (Student student in students)
                str += "ID: " + student.Id.ToString() + ", Name: " + student.Name + ", Age: " + student.Age.ToString() + ", Grade: " + student.Grade + ", TonGiao: " + student.TonGiao + "\n";
            MessageBox.Show(str);
        }
        private void ReadFile_Load(object sender, EventArgs e)
        {
            this.students = new List<Student>();
        }
    }
}
