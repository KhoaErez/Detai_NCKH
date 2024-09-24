using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ql_spkh.Model;
namespace ql_spkh.View
{
    public partial class frmTK_N : Form
    {
        public frmTK_N()
        {
            InitializeComponent();
            cbbRole.SelectedIndex = 0;
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string us, fn, em, add, ph; int rol;
            us = txtUserN.Text.Trim();
            fn = txtFullN.Text.Trim();
            em = txtEmail.Text.Trim();
            add = txtAddress.Text.Trim();
            ph = txtPhone.Text.Trim();
            rol = cbbRole.SelectedIndex + 1;

            string checkSQL = "SELECT * FROM users WHERE username = N'"+us+"'";
            if(new database().QuerySQL(checkSQL) == null)
            {
                if (fn != "" && em != "" && add != "" && ph != "" && us != "")
                {
                    string sql = "INSERT INTO users VALUES (N'" + us + "', N'" + fn + "',N'" + em + "',N'" + add + "','" + ph + "','1'," + rol+")";
                    int kq = new database().QuerySQL_No(sql);
                    if (kq == 1)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công", "Thêm dữ liệu thành công");
                        string type = "CREATE";
                        string detail = "Username " + user.username + ", Tạo mới tài khoản username: "+us+", fullname: "+fn+", role: "+rol;
                        new database().ActivityLog(type, detail);
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thất bại", "Thêm dữ liệu thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không đúng, kiểm tra lại", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("USERNAME đã tồn tại", "Lỗi");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtFullN.Clear();
            txtUserN.Clear();
        }
    }
}
