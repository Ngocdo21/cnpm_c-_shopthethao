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
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tk = txtTK.Text;
            string mk = txtMK.Text;

            string query = "select count(*) from DangNhap where Username='" + tk + "' and Password='" + mk + "'";
            Functions cn = new Functions();
            DataSet ds = cn.laydulieu(query, "DangNhap");

            if ((int)ds.Tables["DangNhap"].Rows[0].ItemArray[0] == 1)
            {
                MessageBox.Show("dang nhap thanh cong");
                main frm = new main();
                frm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("dang nhap that bai");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
