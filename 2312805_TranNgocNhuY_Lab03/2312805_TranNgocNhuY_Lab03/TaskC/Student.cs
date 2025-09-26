using _2312805_TranNgocNhuY_Lab03.Tutorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_Lab03.TaskC
{
    internal class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Class {  get; set; }
        public int CMND {  get; set; }
        public string Phone {  get; set; }
        public string Address { get; set; }
        public List<string> Subjects { get; set; }
        public bool Gender { get; set; }
        public Student() 
        {
            Subjects = new List<string>();
        }

        public Student(int id, string lastName, string firstName, DateTime dateBirth, string @class, int cMND, string phone, string address, List<string> subjects, bool gender)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            DateBirth = dateBirth;
            Class = @class;
            CMND = cMND;
            Phone = phone;
            Address = address;
            Subjects = subjects;
            Gender = gender;
        }
        public override string ToString()
        {
            return $"{this.Id}|{this.LastName}|{this.FirstName}|{this.Class}|{this.DateBirth.ToString("yyyy/MM/dd")}|{this.CMND}|{this.Phone}|{this.Address}|{this.Gender}";
        }
    }
}
