using _2312805_TranNgocNhuY_lab07.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_lab07.Forms
{
    public partial class RoleAccountForm : Form
    {
        private RestaurantContext _context;
        public RoleAccountForm(List<string> roles)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            LoadRoles(roles);
        }
        private void LoadRoles(List<string> roles)
        {
            lvRoles.Items.Clear();

            
            foreach (var roleName in roles)
            {
                int value = Convert.ToInt32(roleName);
                var role = _context.Roles.Select(r => new RoleModel
                {
                    Id = r.Id,
                    RoleName = r.RoleName,
                    Path = r.Path,
                    Notes = r.Notes
                }).Where(r => r.Id == value)
                    .ToList();
                foreach (var r in role)
                {
                    var item = new ListViewItem(r.Id.ToString());
                    item.SubItems.Add(r.RoleName);
                    item.SubItems.Add(r.Path);
                    item.SubItems.Add(r.Notes);

                    lvRoles.Items.Add(item);
                }
            }
        }
    }
}
