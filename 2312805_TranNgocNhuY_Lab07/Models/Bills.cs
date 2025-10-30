using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_lab07.Models
{
    public class Bills
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TableId { get; set; }

        public int Amount { get; set; }

        public double Discount { get; set; }

        public double Tax { get; set; }

        public bool Status { get; set; }

        public DateTime CheckoutDate { get; set; }

        public string Account { get; set; }

        public Table01 Table01 { get; set; }

        public ICollection<BillDetail> BillDetails { get; set; }
    }
}
