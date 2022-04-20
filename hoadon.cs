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
    public partial class hoadon : Form
    {
        public hoadon()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void LoadComboBox()
        {
            //String cmd = new SqlCommand("select * form NhanVien");
          
        }
        
        public void getdata()
        {
            string query = "select * from SanPham";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(query, "SanPham");
            cbxMaHang.DataSource = ds.Tables["SanPham"];
            cbxMaHang.DisplayMember = "IdSp";
            cbxMaHang.ValueMember = "TenSp";
           // txtTenHang.Text = "";
            txtDonGia.Text = "0";
        }


        public void getnhanvien()
        {
            string query = "select * from NhanVien";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(query, "NhanVien");
            cbxMaNhanVien.DataSource = ds.Tables["NhanVien"];
            cbxMaNhanVien.DisplayMember = "IdNv";
            cbxMaNhanVien.ValueMember = "HoTen";
            txtTenNV.Text = "";
        }
        public void getkhachhang()
        {
            string query = "select * from KhachHang";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(query, "KhachHang");
            cbxMaKhachHang.DataSource = ds.Tables["KhachHang"];
            cbxMaKhachHang.DisplayMember = "IdKhachHang";
            cbxMaKhachHang.ValueMember = "TenKhachHang";
            txtTenKH.Text = "";
            //cbxMaKhachHang.ValueMember = "DiaChi";
           // cbxMaKhachHang.ValueMember = "SDT";

        }
        public void getchitiethd()
        {
            string query = "select * from ChiTietHoaDon";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(query, "ChiTietHoaDon");
            dgvHoaDon.DataSource = ds.Tables["ChiTietHoaDon"];
        }

        private void hoadon_Load(object sender, EventArgs e)
        {
            getdata();
            getnhanvien();
            getchitiethd();
            getkhachhang();
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            number1.Text = "";
            txtDonGia.Text = "";
            txtTenHang.Text = "";
            txtGiamgia.Text = "0";
            txtThanhTien.Text = "0";
            mskNgayThanhToan.Text = DateTime.Now.ToLongDateString();
            cbxMaHang.Text = "";
            cbxMaKhachHang.Text = "";
            cbxMaNhanVien.Text = "";
            getchitiethd();
        }
        
        private void cbxMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenNV.Text = cbxMaNhanVien.SelectedValue.ToString();
           
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.ReadOnly = true;
            DataGridViewRow row = this.dgvHoaDon.Rows[e.RowIndex];
            txtMaHD.Text = row.Cells[0].Value.ToString();
            cbxMaHang.Text = row.Cells[1].Value.ToString();
            cbxMaKhachHang.Text = row.Cells[2].Value.ToString();
            cbxMaNhanVien.Text = row.Cells[3].Value.ToString();
            number1.Text = row.Cells[4].Value.ToString();
            txtDonGia.Text = row.Cells[5].Value.ToString();
            txtGiamgia.Text = row.Cells[6].Value.ToString();
            txtThanhTien.Text = row.Cells[7].Value.ToString();
            mskNgayThanhToan.Text = row.Cells[8].Value.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string mahd = txtMaHD.Text;
            string masp = cbxMaHang.Text;
            string makh = cbxMaKhachHang.Text;
            string manv = cbxMaNhanVien.Text;
            int sl = Convert.ToInt32(number1.Value.ToString());
            int giaban = Convert.ToInt32(txtDonGia.Text);
            int giamgia = Convert.ToInt32(txtGiamgia.Text);
            int thanhtien = (sl * giaban * (100 - giamgia)/100);
            txtThanhTien.Text = thanhtien.ToString();
            DateTime date = mskNgayThanhToan.Value;
            string sql = "insert into ChiTietHoaDon ([IdHD],[IdSp],[IdKhachHang],[IdNv],[SoLuong],[DonGia],[GiamGia],[ThanhTien],[NgayTaoHD])" +
                "VALUES('" + mahd + "','" + masp + "','" + makh + "','" + manv + "','" + sl + "','" + giaban + "','" + giamgia + "','" + thanhtien + "','" + date + "')";
            Functions cn = new Functions();
            bool ktra = cn.thucthi(sql);
            if (ktra == true)
            {
                MessageBox.Show("Thêm thành công !");
                getchitiethd();
            }
            else
            {
                MessageBox.Show("Lỗi ! ");
            }
        }

        private void cbxMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenKH.Text = cbxMaKhachHang.SelectedValue.ToString();
        }

        private void cbxMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {

            /* string sql = "select GiaBan form SanPham where IdSp =" + cbxMaHang.SelectedValue.ToString();
             SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GNT2HDB\\SQLEXPRESS;Initial Catalog=cnpm;Integrated Security=True");
             conn.Open();
             SqlCommand cmd = new SqlCommand(sql, conn);
             SqlDataReader sdr = cmd.ExecuteReader();
             cbxDonGia.Text = sdr.GetValue(0).ToString();
             sdr.Close();
             sdr.Dispose();
             conn.Close();
             conn.Dispose();*/

            txtDonGia.Text = cbxMaHang.SelectedValue.ToString();
            //txtTenHang.Text = cbxMaHang.SelectedValue.ToString();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            //[IdHD],[IdSp],[IdKhachHang],[IdNv],[SoLuong],[DonGia],[GiamGia],[ThanhTien],[NgayTaoHD]
            string sql = "DELETE FROM ChiTietHoaDon WHERE [IdHD]='" + txtMaHD.Text + "'";
            Functions cn = new Functions();
            bool ktra = cn.thucthi(sql);
            if (ktra == true)
            {
                MessageBox.Show("Xóa thành công !");
                getchitiethd();
            }
            else
            {
                MessageBox.Show("Lỗi ! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mahd = txtMaHD.Text;
            string masp = cbxMaHang.Text;
            string makh = cbxMaKhachHang.Text;
            string manv = cbxMaNhanVien.Text;
            int sl = Convert.ToInt32(number1.Value.ToString());
            int giaban = Convert.ToInt32(txtDonGia.Text);
            int giamgia = Convert.ToInt32(txtGiamgia.Text);
            int thanhtien = (sl * giaban * (100 - giamgia) / 100);
            txtThanhTien.Text = thanhtien.ToString();
            DateTime date = mskNgayThanhToan.Value;
            //[IdHD],[IdSp],[IdKhachHang],[IdNv],[SoLuong],[DonGia],[GiamGia],[ThanhTien],[NgayTaoHD]
            string sql = "UPDATE ChiTietHoaDon SET [IdSp]='" + masp + "',[IdKhachHang]='"+makh+"', [IdNv]='"+manv+"', [SoLuong]='"+sl+"', [DonGia] = '"+giaban+"', [GiamGia] = '"+giamgia+ "', [ThanhTien] = '" + thanhtien + "', [NgayTaoHD] = '" + date+ "'where [IdHD]='" + mahd + "' ";
            Functions cn = new Functions();
            bool ktra = cn.thucthi(sql);
            if (ktra == true)
            {
                MessageBox.Show("Cập nhật thành công ! ");
                getchitiethd();
            }
            else
            {
                MessageBox.Show("Lỗi ! ");
            }
        }

        /*private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int tonkho;
            tonkho = Convert.ToInt16(cbxTon.Text);
            int soluong = Convert.ToInt16(number1.Text);
            int conlai = tonkho - soluong;
            cbxTon.Text = conlai.ToString();
        }*/
    }
}
