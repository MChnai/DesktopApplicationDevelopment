using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab03.TaskC
{
    public partial class ThongTinSV : Form
    {
        public ThongTinSV()
        {
            InitializeComponent();
        }
        private StudentManaging students;
        private Dictionary<string, int> lastCccNumbers = new Dictionary<string, int>();      
        private void ThongTinSV_Load(object sender, EventArgs e)
        {
            students = new StudentManaging();
            //students.XMLRead();
            //students.LoadJson("G:\\STUDY\\PTUDD\\2312805_TranNgocNhuY-Lab03\\bin\\Debug\\TaskC\\Students.json");
            Student stu;
            foreach (string lines in File.ReadAllLines("TaskC\\Students.txt"))
            {
                string[] line = lines.Split('|');
                stu = new Student();
                stu.Id = Convert.ToInt32(line[0].ToString());
                stu.LastName = line[1].ToString();
                stu.FirstName = line[2].ToString();
                stu.Class = line[3].ToString();
                DateTime.TryParseExact(line[4].ToString(), "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime);
                stu.DateBirth = parsedDateTime;
                stu.CMND = Convert.ToInt32(line[5]);
                stu.Phone = line[6].ToString();
                stu.Address = line[7].ToString();
                if (line[8].ToString() == "True")
                  stu.Gender = true;
                else
                    stu.Gender = false;
                string[] subjects = line[9].Split(',');
                for(int i = 0;  i < subjects.Length; i++)
                    stu.Subjects.Add(subjects[i]);
                students.Add(stu);
            }
            Display(students.students);
        }
        private void Display(List<Student> list)
        {
            if(list.Count <= 0)
                return;
            lvDSSV.Items.Clear();
            ListViewItem item;
            foreach (Student student in list)
            {
                item = new ListViewItem();
                item.Text = student.Id.ToString();
                item.SubItems.Add(student.LastName);
                item.SubItems.Add(student.DateBirth.ToString());
                item.SubItems.Add(student.FirstName);
                item.SubItems.Add(student.Class);
                item.SubItems.Add(student.CMND.ToString());
                item.SubItems.Add(student.Phone);
                item.SubItems.Add(student.Address);
                if (student.Gender)
                    item.SubItems.Add("Nam");
                else
                    item.SubItems.Add("Nu");
                lvDSSV.Items.Add(item);
            }
        }
        private bool Check()
        {
            if(mtxtID.Text.Length != 7 || mtxtPhone.Text.Length != 10 || txtCMND.Text.Length != 9)
            {
                return false;
            }
            return true;
        }
        private void pnlSubjects_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ctmscpSubjects.Show();
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student stu = students.FindID(mtxtID.Text);
            foreach (Control control in pnlSubjects.Controls)
                if (control is CheckBox checkBox && checkBox.Checked)
                    stu.Subjects.Remove(checkBox.Text);
            students.Update(stu);
            MessageBox.Show("Delete succesfully!!!");
        }
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student stu = students.FindID(mtxtID.Text);
            foreach (Control control in pnlSubjects.Controls)
                if (control is CheckBox checkBox && checkBox.Checked)
                    stu.Subjects.Add(checkBox.Text);
            students.Update(stu);
            MessageBox.Show("Adding succesfully!!!");
        }
        private void ClearPanel()
        {
            foreach (Control control in pnlSubjects.Controls)
                if(control is CheckBox checkBox)
                    checkBox.Checked = false;
        }
        private void lvDSSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvDSSV.SelectedItems.Count > 0)
            {
                ListViewItem item = lvDSSV.SelectedItems[0];
                mtxtID.Mask = string.Empty;
                mtxtID.Text = item.Text;
                txtLastName.Text = item.SubItems[1].Text;
                txtName.Text = item.SubItems[3].Text;               
                dtpkDateBirth.Text = item.SubItems[2].Text;
                cbxClass.Text = item.SubItems[4].Text;
                txtCMND.Mask = string.Empty;
                txtCMND.Text = item.SubItems[5].Text;
                mtxtPhone.Mask = string.Empty;
                mtxtPhone.Text = item.SubItems[6].Text;
                txtAdress.Text = item.SubItems[7].Text;
                if (item.SubItems[8].Text == "Nam")
                    rbtnMale.Checked = true;
                else
                    rbtnFemale.Checked = true;
                ClearPanel();
                Student stu = students.FindID(item.Text);
                foreach(string subject in stu.Subjects)
                    foreach(Control control in pnlSubjects.Controls)
                        if(control.Text == subject && control is CheckBox checkbox)
                            checkbox.Checked = true;
            }
        }
        private bool CheckInformation()
        {
            if ((mtxtID.Text == string.Empty && mtxtID.Mask == "_______") ||
                txtLastName.Text == string.Empty ||
                txtName.Text == string.Empty ||
                (mtxtID.Text == string.Empty && mtxtID.Mask == "____________") ||
                txtCMND.Text == string.Empty ||
                (mtxtID.Text == string.Empty && mtxtID.Mask == "________") ||
                mtxtPhone.Text == string.Empty ||
                txtAdress.Text == string.Empty)
            {
                MessageBox.Show("Please enter all the necessary information above!!!");
                return false;
            }
            return true;
        }
        private void xóaCácSinhViênĐãChọnMônHọcNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chkANVBMHT.Checked)
                foreach(Student student in students.students) 
                    if(student.Subjects.Contains(chkANVBMHT.Text))
                        student.Subjects.Remove(chkANVBMHT.Text);
            if (chkCSDL.Checked)
                foreach (Student student in students.students)
                    if (student.Subjects.Contains(chkCSDL.Text))
                        student.Subjects.Remove(chkCSDL.Text);
            if (chkDACS.Checked)
                foreach (Student student in students.students)
                    if (student.Subjects.Contains(chkDACS.Text))
                        student.Subjects.Remove(chkDACS.Text);
            if (chkHDH.Checked)
                foreach (Student student in students.students)
                    if (student.Subjects.Contains(chkHDH.Text))
                        student.Subjects.Remove(chkHDH.Text);
            if (chkLTM.Checked)
                foreach (Student student in students.students)
                    if (student.Subjects.Contains(chkLTM.Text))
                        student.Subjects.Remove(chkLTM.Text);
            if (chkLTTTBDD.Checked)
                foreach (Student student in students.students)
                    if (student.Subjects.Contains(chkLTTTBDD.Text))
                        student.Subjects.Remove(chkLTTTBDD.Text);
            if (chkMMT.Checked)
                foreach (Student student in students.students)
                    if (student.Subjects.Contains(chkMMT.Text))
                        student.Subjects.Remove(chkMMT.Text);
            if (chkNCKH.Checked)
                foreach (Student student in students.students)
                    if (student.Subjects.Contains(chkNCKH.Text))
                        student.Subjects.Remove(chkNCKH.Text);
            MessageBox.Show("Delete succesfully!!!");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to close the window? ", "XConform exiting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Check() || !CheckInformation())
                return;
            Student stu = students.FindID(mtxtID.Text);
            students.Update(stu);
            MessageBox.Show("Upadte succesfully!!!");
            students.SaveStudentsToFile("G:\\STUDY\\PTUDD\\2312805_TranNgocNhuY-Lab03\\TaskC\\Students.txt");
            Display(students.students);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(!Check() || !CheckInformation())
            {
                MessageBox.Show("Information not suitable!!!");
                return;
            }
            if(students.FindID(mtxtID.Mask) != null)
            {
                MessageBox.Show("Alreday exist student ID: " + mtxtID.Text);
                return;
            }
            List<string> list = new List<string>();
            foreach(Control control in pnlSubjects.Controls)
                if(control is CheckBox checkBoxControl)
                    list.Add(control.Text);
            Student stu = new Student();
            stu.Id = Convert.ToInt32(mtxtID.Text);
            stu.LastName = txtLastName.Text;
            stu.FirstName = txtName.Text;
            stu.Address = txtAdress.Text;
            stu.DateBirth = Convert.ToDateTime(dtpkDateBirth.Value);
            stu.CMND = Convert.ToInt32(txtCMND.Text);
            stu.Phone = mtxtPhone.Text;
            stu.Subjects = list;
            stu.Class = cbxClass.Text;
            students.Add(stu);
            MessageBox.Show("Adding succesfully!!!");
            students.SaveStudentsToFile("G:\\STUDY\\PTUDD\\2312805_TranNgocNhuY-Lab03\\TaskC\\Students.txt");
            Display(students.students);
        }
        private void mtxtID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtxtID.Mask = string.Empty;
        }
        private void txtCMND_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtCMND.Mask = string.Empty;
        }
        private void mtxtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtxtPhone.Mask = string.Empty;  
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ctmspSearch.Show();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Student student = students.FindID(mtxtID.Text);
            List<Student> result = new List<Student>();
            result.Add(student);
            Display(result);
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<Student> result = students.FindName(txtName.Text);
            Display(result);
        }
        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Student> result = students.FindClass(cbxClass.Text);
            Display(result);
        }
        private string GetYearFromClassName(string className)
        {
            if (string.IsNullOrWhiteSpace(className)) return null;
            Match match = Regex.Match(className, @"\d{2}(?=\D|$)"); 
            if (match.Success)
            {
                return match.Value; 
            }
            Console.WriteLine($"Không thể xác định năm nhập học từ tên lớp: {className}. Vui lòng nhập đúng định dạng lớp.");
            return null; 
        }
        public string GenerateNewStudentID(string className)
        {
            string aa = GetYearFromClassName(className);
            if (aa == null)
                throw new InvalidOperationException("Không thể tạo MSSV: Không xác định được năm nhập học từ tên lớp.");
            const string bb = "10";
            int nextCccNumber = 1;
            if (lastCccNumbers.ContainsKey(aa))
                nextCccNumber = lastCccNumbers[aa] + 1;            
            string newStudentID;
            do
            {
                if (nextCccNumber > 999)
                    throw new InvalidOperationException($"Đã hết MSSV cho năm nhập học {aa}. Vui lòng liên hệ quản trị viên.");
                string ccc = nextCccNumber.ToString("D3");
                newStudentID = $"{aa}{bb}{ccc}";
                if(students.FindID(newStudentID) != null)
                    MessageBox.Show("Alreday exist student ID: " + newStudentID);                
            } while (students.FindID(newStudentID) != null);
            lastCccNumbers[aa] = nextCccNumber;
            return newStudentID;
        }
    }
}
