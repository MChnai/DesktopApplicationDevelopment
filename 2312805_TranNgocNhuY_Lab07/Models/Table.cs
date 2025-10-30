using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_lab07.Models
{
    public class Table01
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TableStatus Status { get; set; }

        public int Capacity { get; set; }

        public ICollection<Bills> Bills { get; set; }
    }
    public enum TableStatus
    {
        Available,
        Reserved,
        Occupied
    }
}
