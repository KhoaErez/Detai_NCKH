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
    public partial class frmGV_U : Form
    {
        public frmGV_U(int gvid, string ten,string khoa)
        {
            InitializeComponent();
            this.gvid = gvid;
            this.ten = ten;
            this.khoa = khoa;
        }
        private int gvid;
        string ten, khoa;

        private void btnThem_Click(object sender, EventArgs e)
        {
            string t = txtTen.Text.Trim();
            string k = cbbKhoa.SelectedValue.ToString();
            if(t!="")
            {
                string sql = "UPDATE advisors SET advisorname = N'" + t + "', departmentid = " + k + " WHERE advisorid = " + gvid;
                int kq = new database().QuerySQL_No(sql);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Cập nhật thành công");
                    string type = "UPDATE";
                    string detail = "Username " + user.username + ", Cập nhật giản viên tên: " + this.ten + ", khoa: " + this.khoa;
                    new database().ActivityLog(type, detail);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Cập nhật thất bại");
                }
            }
            else
            {
                MessageBox.Show("Điền đầy đủ dữ liệu", "Cập nhật thất bại");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa giảng viên.Chỉ có thể xóa khi tất cả các project liên quan đã xóa", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "DELETE FROM advisors WHERE advisorid = " + gvid;
                int kq = new database().QuerySQL_No(sql);
                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công", "Thành công");
                    string type = "DELETE";
                    string detail = "Username " + user.username + ", Xóa giản viên tên: " + this.ten + ", khoa: " + this.khoa;
                    new database().ActivityLog(type, detail);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thất bại");
                }
            }


        }

        private void frmGV_U_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM departments";
            cbbKhoa.DataSource = new database().QuerySQL(sql);
            cbbKhoa.DisplayMember = "departmentname";
            cbbKhoa.ValueMember = "departmentid";

            txtTen.Text = ten;
            foreach (var item in cbbKhoa.Items)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null && rowView["departmentname"].ToString() == khoa)
                {
                    cbbKhoa.SelectedValue = rowView["departmentid"];
                    break;
                }
            }
        }
    }
}
