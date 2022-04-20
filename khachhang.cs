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
    public partial class khachhang : Form
    {
        public khachhang()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvKhachHang.Rows[e.RowIndex];
                txtMaKhachHang.Text = row.Cells[0].Value.ToString();
                //cbxPLKH.Text = row.Cells[1].Value.ToString();
                // num2.Value = int.Parse(row.Cells[2].Value.ToString());
                txtHoTen.Text = row.Cells[1].Value.ToString();
                dtpNgaySinh.Text = row.Cells[2].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtSDTKhachHang.Text = row.Cells[3].Value.ToString();


            }
        }

        public void getdata()
        {
            string query = "select * from KhachHang";
            Functions cn = new Functions();
            DataSet ds = cn.laydulieu(query, "KhachHang");

            dgvKhachHang.DataSource = ds.Tables["KhachHang"];
        }
        
        /*public void getplkhachhang()
        {
            string query = "select * form PLKhachHang";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(query, "PLKhachHang");
            cbxPLKH.DataSource = ds.Tables["PLKhachHang"];
            cbxPLKH.DisplayMember = "IdPLKhachHang";
           // cbxPLKH.ValueMember = "IdPLKhachHang";
        }*/

        private void khachhang_Load(object sender, EventArgs e)
        {
            getdata();
            //getplkhachhang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string makh = txtMaKhachHang.Text;
            string tenkh = txtHoTen.Text;
            DateTime ngaysinh = dtpNgaySinh.Value;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDTKhachHang.Text;
            //string plkh = cbxPLKH.Text;

            string query = "insert into KhachHang(IdKhachHang, TenKhachHang, NgaySinh, DiaChi, SDT) values ('" + makh+ "', N'" + tenkh + "', '" + ngaysinh + "', N'" + diachi + "', '" + sdt + "')";
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKhachHang.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDTKhachHang.Text = "";
            //dtpNgaySinh.Text = " / /";
            //txtSDTKhachHang.Text = "";
            getdata();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string makh = txtMaKhachHang.Text;
            string tenkh = txtHoTen.Text;
            DateTime ngaysinh = dtpNgaySinh.Value;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDTKhachHang.Text;
            //string plkh = cbxPLKH.Text;
            // string plkh = cboPLKhachHang.Text;
            // IdKhachHang, IdPLKhachHang, TenKhachHang, NgaySinh, DiaChi, SDT
            string query = "update KhachHang set TenKhachHang=N'" + tenkh + "', NgaySinh='" + ngaysinh + "', DiaChi=N'" + diachi + "', SDT='" + sdt + "' where IdKhachHang='" + makh + "'";
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
            string makh = txtMaKhachHang.Text;
            string sql = "delete from ChiTietHoaDon where IdKhachHang='" + makh + "'";
            string query = "delete from KhachHang where IdKhachHang='" + makh + "'";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimkiem.Text;
            string sql = "select * from KhachHang where [TenKhachHang] like N'%" + timkiem + "%'";
            DataSet ds = new DataSet();
            Functions cn = new Functions();
            ds = cn.laydulieu(sql, "KhachHang");
            dgvKhachHang.DataSource = ds.Tables["KhachHang"];
        }
    }
}
