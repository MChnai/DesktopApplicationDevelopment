using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_lab07.Models
{
    public class BillsModel
    {
        public int Id { get; set; }

        public string Name { get; set; } 

        public string TableName { get; set; }

        public int Amount { get; set; } 

        public float Discount { get; set; } 

        public double Tax { get; set; } 

        public bool Status { get; set; } 

        public DateTime CheckoutDate { get; set; } 
        public string AccountName { get; set; } 
    }
}
