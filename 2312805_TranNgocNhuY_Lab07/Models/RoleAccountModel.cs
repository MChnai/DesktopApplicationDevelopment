using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_lab07.Models
{
    public class RoleAccountModel
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } 

        public string AccountName { get; set; } 

        public bool Actived { get; set; } 

        public string Notes { get; set; }
    }
}
