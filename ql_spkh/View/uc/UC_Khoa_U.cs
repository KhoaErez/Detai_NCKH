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
namespace ql_spkh.View.uc
{
    public partial class UC_Khoa_U : UserControl
    {
        public UC_Khoa_U(string ma, string ten, UC_Khoa k)
        {
            InitializeComponent();
            this.ma = ma;
            this.ten = ten;
            this.k = k;
        }
        string ma, ten;
        UC_Khoa k;
        private void btnBack_Click(object sender, EventArgs e)
        {
            txtTen.Text = ten;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa khoa. Chỉ có thể xóa khi tất cả dữ liệu liên quan đã được xóa", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int id = int.Parse(txtMa.Text);
                string sql = "DELETE FROM departments WHERE departmentid = " + id;
                int kq = new database().QuerySQL_No(sql);
                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công", "Xóa thành công");
                    string type = "DELETE";
                    string detail = "Username " + user.username + ", DELETE khoa mới với ID khoa: " + id +", và tên khoa: "+txtTen.Text;
                    new database().ActivityLog(type, detail);
                    k.close_uc();
                    k.load();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Xóa thất bại");
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMa.Text);
            string tenkhoa = txtTen.Text.Trim();
            if(tenkhoa != "")
            {
                string sql = "SELECT COUNT(*) FROM departments WHERE departmentname LIKE N'" + tenkhoa + "'";
                var rs = new database().QuerySQL(sql);
                int rss = -1;
                if (int.TryParse(rs.Rows[0][0].ToString(), out rss) && rss == 0)
                {
                    sql = "UPDATE departments SET departmentname = N'" + tenkhoa + "' WHERE departmentid = " + id;
                    int kq = new database().QuerySQL_No(sql);
                    if (kq == 1)
                    {
                        MessageBox.Show("Cập nhật thành công", "Cập nhật thành công");
                        string type = "UPDATE";
                        string detail = "Username " + user.username + ", UPDATE khoa ID: " + id +", thành tên mới: "+tenkhoa;
                        new database().ActivityLog(type, detail);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Cập nhật thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Tên sử dụng đã tôn tại trong cơ sở dữ liệu", "Cập nhật thất bại");
                }
            }
            else
            {
                MessageBox.Show("Không được để trống dữ liệu", "Cập nhật thất bại");
            }
        }

        private void UC_Khoa_U_Load(object sender, EventArgs e)
        {
            txtMa.Text = ma;
            txtTen.Text = ten;
        }
    }
}
