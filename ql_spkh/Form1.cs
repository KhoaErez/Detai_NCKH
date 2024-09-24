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
using ql_spkh.View;

namespace ql_spkh
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtpass.UseSystemPasswordChar = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void cbAnHien_CheckedChanged(object sender, EventArgs e)
        {

            if (cbAnHien.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text.Trim();
            string passWord = txtpass.Text.Trim();
            if (userName.Length > 0 && passWord.Length > 0)
            {
                lbLoad.Visible = true;
                txtpass.Enabled = false;
                txtUser.Enabled = false;
                btnDangNhap.Enabled = false;
                string sql = "sp_UserLogin";
                List<parameter> lst = new List<parameter>();
                lst.Add(new parameter()
                {
                    key = "@Username",
                    value = userName
                });
                lst.Add(new parameter()
                {
                    key = "@Password",
                    value = passWord
                });
                parameter.kiemTra_Value(lst);
                database db = new database();
                var rs = db.Login(sql, lst);
                lbLoad.Visible = false;
                txtpass.Enabled = true;
                txtUser.Enabled = true;
                btnDangNhap.Enabled = true;
                if (rs != null)
                {
                    DataTable dt = rs;
                    user.userid = int.Parse(rs.Rows[0][0].ToString());
                    user.username = rs.Rows[0][1].ToString();
                    user.fullname = rs.Rows[0][2].ToString();
                    user.email = rs.Rows[0][3].ToString();
                    user.address = rs.Rows[0][4].ToString();
                    user.phone = rs.Rows[0][5].ToString();
                    user.password = rs.Rows[0][6].ToString();
                    user.role = int.Parse(rs.Rows[0][7].ToString());
                    string type = "LOGIN";
                    string detail = "Username " + user.username + ", LOGIN";
                    new database().ActivityLog(type, detail);
                    this.Hide();
                    new Home().Show();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpass.Clear();
                    txtpass.Focus();
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
