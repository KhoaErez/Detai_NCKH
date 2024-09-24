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
    public partial class frmVS_U : Form
    {
        public frmVS_U(int vsid, string ten, string desc)
        {
            InitializeComponent();
            this.vsid = vsid;
            this.ten = ten;
            this.desc = desc;
        }
        private int vsid;
        string ten, desc;

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string t, d;
            t = txtTen.Text.Trim();
            d = txtTen.Text.Trim();
            if(t!=""&&d!="")
            {
                string sql = "UPDATE projectversions SET versionname = N'" + t + "', description = N'" + d + "' WHERE versionid = " + vsid;
                if(new database().QuerySQL_No(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thành công");

                    string type = "UPDATE";
                    string detail = "Username " + user.username + ", Cập nhật version id: "+vsid+", title: "+this.ten+", description: "+this.desc;
                    new database().ActivityLog(type, detail);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thất bại");
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa version này", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "DELETE FROM projectversions WHERE versionid = " + vsid;
                if (new database().QuerySQL_No(sql) > 0)
                {
                    MessageBox.Show("Xóa thành công", "Thành công");
                    string type = "DELETE";
                    string detail = "Username " + user.username + ", XÓA version id: " + vsid + ", title: " + this.ten + ", description: " + this.desc;
                    new database().ActivityLog(type, detail);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thất bại");
                }
            }

        }

        private void frmVS_U_Load(object sender, EventArgs e)
        {
            txtTen.Text = ten;
            txtMieuTa.Text = desc; 
        }
    }
}
