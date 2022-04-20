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
    public partial class nhanvien : Form
    {
        public nhanvien()
        {
            InitializeComponent();
        }

        public void getdata()
        {
            string query = "select * from NhanVien";
            Functions cn = new Functions();
            DataSet ds = cn.laydulieu(query, "NhanVien");

            dgvNhanVien.DataSource = ds.Tables["NhanVien"];
        }

        private void nhanvien_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;
            string tennv = txtHoTen.Text;
            DateTime ngaysinh = dtpNgaySinh.Value;
            string cmt = txtSoCMT.Text;
            string sdt = txtSDT.Text;
            string diachi = txtDiaChi.Text;
            string gioitinh = txtGioiTinh.Text;


            string query = "insert into NhanVien(IdNv, HoTen, NgaySinh, SoCMT, DiaChi, GioiTinh, SDT) " +
                "values ('" + manv + "', N'" + tennv + "', '" + ngaysinh + "', '" + cmt + "', N'" + diachi + "', '" + gioitinh + "', '" + sdt + "')";
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

        private void cbxGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            //txtDiaChi.Text = "";
            //dtpNgaySinh.Text = " / /";
            txtSoCMT.Text = "";
            txtSDT.Text = "";
            txtGioiTinh.Text = "";
            txtDiaChi.Text = "";
            getdata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;
            string tennv = txtHoTen.Text;
            DateTime ngaysinh = dtpNgaySinh.Value;
            string cmt = txtSoCMT.Text;
            string sdt = txtSDT.Text;
            string diachi = txtDiaChi.Text;
            string gioitinh = txtGioiTinh.Text;
            //IdNv, HoTen, NgaySinh, SoCMT, DiaChi, GioiTinh, SDT
            string query = "update NhanVien set HoTen=N'" + tennv + "', NgaySinh='" + ngaysinh + "', SoCMT='" + cmt+ "', SDT='" + sdt + "', DiaChi=N'" + diachi + "', GioiTinh = N'" + gioitinh + "'where IdNv='" + manv + "'";
            Functions cn = new Functions();
            bool kt = cn.thucthi(query);

            if (kt == true)
            {
                MessageBox.Show("sua thanh cong");
                getdata();
            }
            else
                MessageBox.Show("sua that bai");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;
            string sql = "delete from ChiTietHoaDon where IdNv='" + manv + "'";
            string query = "delete from NhanVien where IdNv='" + manv + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            hoadon frm = new hoadon();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main frm = new main();
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
            string timkiem = txtTimKiem.Text;
            string sql = "select * from NhanVien where [HoTen] like N'%" + timkiem + "%'";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(sql, "NhanVien");
            dgvNhanVien.DataSource = ds.Tables["NhanVien"];
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                //cbxPLKH.Text = row.Cells[1].Value.ToString();
                // num2.Value = int.Parse(row.Cells[2].Value.ToString());
                txtHoTen.Text = row.Cells[1].Value.ToString();
                dtpNgaySinh.Text = row.Cells[2].Value.ToString();
                txtSoCMT.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtGioiTinh.Text = row.Cells[5].Value.ToString();
                txtSDT.Text = row.Cells[6].Value.ToString();


            }
        }
    }
}
