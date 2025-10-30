using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab06.Forms
{
    public partial class frmReport : Form
    {
        private BillsBL billsBL;
        public frmReport()
        {
            InitializeComponent();
            billsBL = new BillsBL();
            InitializeControls();
        }
        private void InitializeControls()
        {
            dtpFromDate.Value = DateTime.Now.Date; 
            dtpToDate.Value = DateTime.Now.Date;   
            lblTotalRevenue.Text = "0 VND";        
        }
        private void btnExec_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable reportTable = billsBL.GetRevenueReport(fromDate, toDate);

            dgvReport.DataSource = reportTable;
            int totalRevenue = reportTable.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
            lblTotalRevenue.Text = totalRevenue.ToString("C");
        }
        private void ExportToExcel(string filePath)
        {
            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Báo Cáo Doanh Thu");
                worksheet.Cells[1, 1].Value = "Ngày";
                worksheet.Cells[1, 2].Value = "Số hóa đơn";
                worksheet.Cells[1, 3].Value = "Tổng tiền";
                for (int i = 0; i < dgvReport.Rows.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = dgvReport.Rows[i].Cells["ReportDate"].Value?.ToString();
                    worksheet.Cells[i + 2, 2].Value = dgvReport.Rows[i].Cells["InvoiceCount"].Value?.ToString();
                    worksheet.Cells[i + 2, 3].Value = dgvReport.Rows[i].Cells["TotalAmount"].Value?.ToString();
                }
                package.SaveAs(new FileInfo(filePath));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "Xuất báo cáo doanh thu",
                FileName = "BaoCaoDoanhThu.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
