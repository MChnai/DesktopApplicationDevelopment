using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_lab07.Models
{
    public class BillDetail
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int FoodId { get; set; }

        public int Quantity { get; set; }

        public Food Food { get; set; }

        public Bills Bill { get; set; }
    }
}
