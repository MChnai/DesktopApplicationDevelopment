using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_lab07.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryType Type { get; set; }
    }

    public enum CategoryType
    {
        Drink = 1,
        Food
    }
}
