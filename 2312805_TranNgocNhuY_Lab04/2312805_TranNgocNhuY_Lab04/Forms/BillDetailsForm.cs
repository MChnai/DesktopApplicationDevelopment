using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab04.Forms
{
    public partial class BillDetailsForm : Form
    {
        SQLStuff sqlStuff;
        SqlDataAdapter sqlDataReader;
        public string ID { get; set; }
        public BillDetailsForm()
        {
            InitializeComponent();
        }
        private void BillDetailsForm_Load(object sender, EventArgs e)
        {
            dtgrvBillDetail.DataSource = new DataTable();
            sqlStuff = new SQLStuff();
            string sqlCommand = "SELECT DISTINCT A.ID, B.ID, FoodCategoryID, B.Name, Price, Notes FROM BillDetail A, Food B WHERE A.FoodID = B.ID AND A.ID = " + ID;
            sqlDataReader = sqlStuff.Read_Data_Adapter(sqlCommand);
            DataTable dt = new DataTable("BillDetail");
            sqlDataReader.Fill(dt);
            dtgrvBillDetail.DataSource = dt;
            sqlDataReader.Dispose();
        }
    }
}
