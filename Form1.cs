using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace TRUONGVANQUOCPHONG_1150080153_BTtuan9
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=LAPTOP-G3EK34HT\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True";
        SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);  // DÒNG NÀY GỌI BÁO CÁO KHI MỞ FORM
        }

        private void MoKetNoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MoKetNoi();

            string query = "SELECT * FROM SinhVien";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlCon);

            dsSinhVien ds = new dsSinhVien();
            adapter.Fill(ds, "SinhVien");

            // DÙNG reportViewer2 
            this.reportViewer2.LocalReport.ReportEmbeddedResource =
                "TRUONGVANQUOCPHONG_1150080153_BTtuan9.rptSinhVien.rdlc";

            ReportDataSource rds = new ReportDataSource("DataSet1", ds.SinhVien as object);
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(rds);

            this.reportViewer2.RefreshReport();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {

            this.reportViewer2.RefreshReport();
        }
    }
}