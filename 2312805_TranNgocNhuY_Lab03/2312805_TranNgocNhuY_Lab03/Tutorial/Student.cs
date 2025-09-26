using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_Lab03.Tutorial
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Grade { get; set; }
        public string TonGiao { get; set; }
        public Student() { }
        public Student (int id, string name, int age, float grade, string tonGiao)
        {
            this.Age = age;
            this.Name = name;
            this.Id = id;
            this.Grade = grade;
            this.TonGiao = tonGiao;
        }
    }
}
