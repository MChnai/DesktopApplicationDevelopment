using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace _2312805_TranNgocNhuY_Lab03.TaskC
{
    internal class StudentManaging
    {
        public List<Student> students;
        public StudentManaging() 
        {
            students = new List<Student>();
        }
        public void Add(Student student)
        {
            students.Add(student);
        }
        public void Update(Student student)
        {
            Student s = students.Find(stu => stu.Id == student.Id);
            if(s == null)
            {
                MessageBox.Show("Can't find student ID: " + student.Id);
                return;
            }
            foreach(Student stu  in students) 
                if(stu.Id == student.Id)
                {
                    stu.FirstName = student.FirstName;
                    stu.LastName = student.LastName;
                    stu.DateBirth = student.DateBirth;
                    stu.Phone = student.Phone;
                    stu.CMND = student.CMND;
                    stu.Class = student.Class;
                    stu.Address = student.Address;
                    stu.Subjects.Clear();
                    foreach(string subjects in student.Subjects) 
                        stu.Subjects.Add(subjects);
                    return;
                }

        }
        //Read file
        public void LoadJson(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string json = streamReader.ReadToEnd();
            var array = (JObject)JsonConvert.DeserializeObject(json);
            var student = array["Student"].Children();
            Student s;
            foreach (var item in student)
            {
                s = new Student();
                s.Id = Convert.ToInt32(item["Id"]);
                s.LastName = Convert.ToString(item["LastName"]);
                s.FirstName = Convert.ToString(item["Name"]);
                DateTime.TryParseExact(item["DateBirth"].ToString(), "dd/MM/yyyy", 
                    null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime);
                s.DateBirth = parsedDateTime;
                s.Class = Convert.ToString(item["Class"]);
                s.CMND = Convert.ToInt32(item["CMND"]);
                s.Phone = Convert.ToString(item["Phone"]);
                s.Address = Convert.ToString(item["Address"]);
                if (Convert.ToString(item["Gender"]).Equals("Nam"))
                    s.Gender = true;
                else
                    s.Gender= false;
                students.Add(s);
            }
        }
        public void XMLRead()
        {
            students.Clear();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("G:\\STUDY\\PTUDD\\2312805_TranNgocNhuY-Lab03\\bin\\Debug\\TaskC\\Students.xml");
            var node = xmlDoc.DocumentElement.SelectNodes("/catalog/Student");
            Student student;
            foreach (XmlNode item in node)
            {
                student = new Student();
                student.Id = Convert.ToInt32(item.Attributes["Id"].Value);
                student.LastName = item.SelectSingleNode("LastName").InnerText;
                student.FirstName = Convert.ToString(item.SelectSingleNode("Name").InnerText);
                DateTime.TryParseExact(item.SelectSingleNode("DateBirth").InnerText, "dd/MM/yyyy",
                   null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime);
                student.DateBirth = parsedDateTime;
                student.Class = item.SelectSingleNode("Class").InnerText;
                student.CMND = Convert.ToInt32(item.SelectSingleNode("CMND").InnerText);
                student.Phone = Convert.ToString(item.SelectSingleNode("Phone").InnerText);
                student.Address = Convert.ToString(item.SelectSingleNode("Adress").InnerText);
                if (Convert.ToString(item.SelectSingleNode("Gender").InnerText).Equals("Nam"))
                    student.Gender = true;
                else
                    student.Gender = false;
                students.Add(student);
            }
        }
        //Find
        public Student FindID(string ID)
        {
            foreach (Student stu in students)
                if (stu.Id.ToString() == ID)
                    return stu;
            return null;
        }
        public List<Student> FindName(string name)
        {
            List<Student> result = new List<Student>();
            foreach(Student student in students) 
                if(student.FirstName.Contains(name) || student.LastName.Contains(name))
                    result.Add(student);
            return result;
        }
        public List<Student> FindClass(string className)
        {
            List<Student> result = new List<Student>();
            foreach (Student student in students)
                if (student.Class.Contains(className))
                    result.Add(student);
            return result;
        }
        //Remove
        public void Remove(string ID)
        {
            students.RemoveAll(stu => stu.Id.Equals(ID));
        }
        //Save
        public void SaveStudentsToFile(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                    foreach (var student in students)
                        sw.WriteLine(student.ToString());
                Console.WriteLine("Dữ liệu sinh viên đã được lưu vào file thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu dữ liệu vào file: {ex.Message}");
            }
        }
    }
}
