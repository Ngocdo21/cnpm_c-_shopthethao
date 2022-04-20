using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CNPM.Class;
namespace CNPM
{
    public partial class baocao : Form
    {
        public baocao()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main frm = new main();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hoadon frm = new hoadon();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            khachhang frm = new khachhang();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sanpham frm = new sanpham();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            nhanvien frm = new nhanvien();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dangnhap frm = new dangnhap();
            frm.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DateTime batdau = dateTimePicker1.Value;
            DateTime ketthuc = dateTimePicker2.Value;
            string sql = "select * from ChiTietHoaDon where [NgayTaoHD] between '" + batdau + "' and '" + ketthuc + "'";
            //string sql1 = "select SUM(ThanhTien) from ChiTietHoaDon";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(sql, "ChiTietHoaDon");
            dataGridView1.DataSource = ds.Tables["ChiTietHoaDon"];
        }

        public void getbaocao()
        {
            string sql = "select * from ChiTietHoaDon";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(sql, "ChiTietHoaDon");
            dataGridView1.DataSource = ds.Tables["ChiTietHoaDon"];
        }

        private void baocao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cnpmDataSet.ChiTietHoaDon' table. You can move, or remove it, as needed.
            this.chiTietHoaDonTableAdapter.Fill(this.cnpmDataSet.ChiTietHoaDon);
            getbaocao();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTong_Click(object sender, EventArgs e)
        {
           
            int sc = dataGridView1.Rows.Count;
            int thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
            {
                thanhtien += int.Parse(dataGridView1.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            txtTong.Text = thanhtien.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            getbaocao();
        }

      
    }
}
