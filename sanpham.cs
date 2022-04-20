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
    public partial class sanpham : Form
    {
        public sanpham()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void getdata()
        {
            string query = "select * from SanPham";
            Functions cn = new Functions();
            DataSet ds = cn.laydulieu(query, "SanPham");

            dgvSanPham.DataSource = ds.Tables["SanPham"];
        }

        /*public void getloaisanpham()
        {
            string query = "select * from Loai_sp";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(query, "Loai_sp");
            cbxLoaiSp.DataSource = ds.Tables["Loai_sp"];
            cbxLoaiSp.DisplayMember = "IdLoaiSp";
            cbxLoaiSp.ValueMember = "IdLoaiSp";
        }*/

        private void sanpham_Load(object sender, EventArgs e)
        {
            getdata();
            //getloaisanpham();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string masp = txtSp.Text;
            string tensp = txtTenSp.Text;
            string soluong = txtSoLuong.Text;
            DateTime ngaynhap = dtpNgayNhap.Value;
            string gianhap = txtGiaNhap.Text;
            string giaban = txtGiaBan.Text;
            string query = " insert into SanPham (IdSp,TenSp,SoLuong,NgayNhap,GiaNhap,GiaBan) values ('" + masp + "',N'" + tensp + "','" + soluong + "','" + ngaynhap + "','" + gianhap + "','" + giaban + "')";
            Functions cn = new Functions();
            bool kt = cn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Them moi thanh cong");
                getdata();
            }
            else
                MessageBox.Show("them moi that bai");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtSp.Text = "";
            txtTenSp.Text = "";
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            //dtpNgayNhap.Text = " / /";
            getdata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string masp = txtSp.Text;
            string tensp = txtTenSp.Text;
            DateTime ngaynhap = dtpNgayNhap.Value;
            int soluong = Convert.ToInt32(txtSoLuong.Text);
            int gianhap = Convert.ToInt32(txtGiaNhap.Text);
            int giaban = Convert.ToInt32(txtGiaBan.Text);
            //IdSp, TenSp, SoLuong, NgayNhap, Gia
            string query = "update SanPham set TenSp=N'" + tensp + "', SoLuong ='" + soluong + "', NgayNhap='" + ngaynhap+ "', GiaNhap='" + gianhap + "', GiaBan='" + giaban + "' where IdSp='" + masp + "'";
            Functions cn = new Functions();
            bool kt = cn.thucthi(query);

            if (kt == true)
            {
                MessageBox.Show("sua thanh cong");
                getdata();
            }
            else
            {
                MessageBox.Show("sua that bai");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string masp = txtSp.Text;
            string sql = "delete from ChiTietHoaDon where IdSp='" + masp + "'";
            string query = "delete from SanPham where IdSp='" + masp + "'";
            Functions cn = new Functions();
            cn.thucthi(sql);
            bool kt = cn.thucthi(query);

            if (kt == true)
            {
                MessageBox.Show("xoa thanh cong");
                getdata();
            }
            else
                MessageBox.Show("xoa that bai");
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

        private void button5_Click(object sender, EventArgs e)
        {
            nhanvien frm = new nhanvien();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baocao frm = new baocao();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dangnhap frm = new dangnhap();
            frm.Show();
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimkiem.Text;
            string sql = "select * from SanPham where [IdSp] like N'%" + timkiem + "%'";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(sql, "SanPham");
            dgvSanPham.DataSource = ds.Tables["SanPham"];
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSanPham.Rows[e.RowIndex];
                txtSp.Text = row.Cells[0].Value.ToString();
                //cbxLoaiSp.Text = row.Cells[1].Value.ToString();
                txtTenSp.Text = row.Cells[1].Value.ToString();
                txtSoLuong.Text = row.Cells[2].Value.ToString();
                dtpNgayNhap.Text = row.Cells[3].Value.ToString();
                txtGiaNhap.Text = row.Cells[4].Value.ToString();
                txtGiaBan.Text = row.Cells[5].Value.ToString();


            }
        }

        private void cbxLoaiSp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
