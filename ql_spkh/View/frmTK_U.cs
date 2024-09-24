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
    public partial class frmTK_U : Form
    {
        public frmTK_U(int id, string us, string fn, string em, string add, string ph, string pass, int rol,int isAD)
        {
            InitializeComponent();
            this.id = id;
            this.us = us;
            this.fn = fn;
            this.em = em;
            this.add = add;
            this.ph = ph;
            this.rol = rol;
            this.pass = pass;
            this.isAD = isAD;
        }
        int id, rol,isAD; string us, fn, em, add, ph, pass;
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa tài khoản, Bao gồm các dữ liệu liên quan", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql1 = "DELETE FROM activitylog WHERE userid = " + id;
                string sql = "DELETE FROM users WHERE userid = " + id;
                new database().QuerySQL_No(sql1);
                if (new database().QuerySQL_No(sql) > 0)
                {
                    MessageBox.Show("Xóa tài khoản thành công, hệ thông sẽ tự động đóng", "Thành công");

                    string type = "DELETE";
                    string detail = "Username " + user.username + ", Xóa tài khoản username: " + us + ", fullname: " + fn + ", role: " + rol;
                    new database().ActivityLog(type, detail);
                    if(isAD == 0)
                    {
                        Application.Exit();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại", "Thất bại1");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string fn, em, add, ph, pass, passN, rol;
            fn=txtFullN.Text.Trim();
            em=txtEmail.Text.Trim();
            add=txtAddress.Text.Trim();
            ph=txtPhone.Text.Trim();

            pass=txtPassW.Text.Trim();

            rol = cbbRole.Text.Trim();

            passN = txtNewP.Text.Trim();
            int rol2 = 0;

            if (rol == "User") rol2 = 1;
            else if (rol == "CTV") rol2 = 2;
            else rol2 = 3;

            if(fn!=""&&em!=""&&add!=""&&ph!=""&&pass!=""&&passN!="")
            {
                if(isAD == 1)
                {
                    string sql = "UPDATE users SET fullname = N'" + fn + "',email = N'"+em+"'," +
                        "address = N'"+add+"',phone = '"+ph+"',password = '"+passN+"', role = "+rol2+" WHERE userid = "+id;
                    if (new database().QuerySQL_No(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công", "Thành công");

                        string type = "UPDATE";
                        string detail = "Username " + user.username + ", Cập nhật tài khoản username: " + this.us + ", fullname: " + this.fn + ", role: " + this.rol;
                        new database().ActivityLog(type, detail);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật tài khoản thất bại", "Thất bại");
                    }
                }
                else
                {
                    if(pass.Equals(this.pass))
                    {
                        string sql = "UPDATE users SET fullname = N'" + fn + "',email = N'" + em + "'," +
                                "address = N'" + add + "',phone = '" + ph + "',password = '" + passN + "', role = " + rol2 + " WHERE userid = " + id;
                        if (new database().QuerySQL_No(sql) > 0)
                        {
                            MessageBox.Show("Cập nhật tài khoản thành công, hệ thống sẽ tự động đóng sau khi cập nhật", "Thành công");
                            string type = "UPDATE";
                            string detail = "Username " + user.username + ", Cập nhật tài khoản username: " + this.us + ", fullname: " + this.fn + ", role: " + this.rol;
                            new database().ActivityLog(type, detail);
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật tài khoản thất bại", "Thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không đúng, kiểm tra lại", "Lỗi");
                    }
                }

            }
            else
            {
                MessageBox.Show("Dữ liệu không đúng, kiểm tra lại", "Lỗi");
            }
        }

        private void frmTK_U_Load(object sender, EventArgs e)
        {
            txtFullN.Text = fn;
            txtEmail.Text = em;
            txtAddress.Text = add;
            txtPhone.Text = ph;
            if(isAD == 1)
            {
                txtPassW.Text = pass;
                txtPassW.UseSystemPasswordChar = false;
                txtPassW.Enabled = false;
            }
            else
            {
                txtPassW.Clear();
                cbbRole.Enabled = false;
                txtPassW.UseSystemPasswordChar = true;
            }
            cbbRole.SelectedIndex = rol -1;
        }
    }
}
