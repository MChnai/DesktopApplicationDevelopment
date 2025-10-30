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
    public partial class SalesLogForm : Form
    {
        private RestaurantContext _context;
        public SalesLogForm(int _tableID)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            LoadSalesLog(_tableID);
        }
        private void LoadSalesLog(int _tableID)
        {
            var logs = _context.Bills
                .Select(b => new
                {
                    b.Id,
                    b.Name,
                    b.CheckoutDate,
                    b.Account,
                    b.Amount,
                    Discount = (double)b.Discount,
                    Tax = (double)b.Tax,
                    b.TableId
                })
                .Where(tb =>  tb.TableId == _tableID)
                .ToList();

            listViewSalesLog.Items.Clear();

            foreach (var log in logs)
            {
                var item = new ListViewItem(log.Name ?? "N/A"); 
                item.SubItems.Add(log.CheckoutDate != null
                    ? log.CheckoutDate.ToString("dd/MM/yyyy")
                    : "N/A"); 
                item.SubItems.Add(log.Account ?? "Unknown"); 
                item.SubItems.Add(log.Amount.ToString("C"));
                item.SubItems.Add(log.Discount.ToString("P")); 
                item.SubItems.Add(log.Tax.ToString("P"));

                listViewSalesLog.Items.Add(item);
            }
        }
    }
}
