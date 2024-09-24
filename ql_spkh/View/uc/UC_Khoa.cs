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
    public partial class UC_Khoa : UserControl
    {
        public UC_Khoa()
        {
            InitializeComponent();
            cbbKey.DataSource = new List<string>() { "Mã","Tên"};
        }
        private int keySearch = 0;
        private void UC_Khoa_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            string sql = "SELECT * FROM departments";
            dgvData.DataSource = new database().QuerySQL(sql);
        }
        private void cbbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbKey.SelectedItem.ToString() == "Mã")
            {
                this.keySearch = 0;
            }
            else
            {
                this.keySearch = 1;
            }
        }
        private void AddUsercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnKhoaMain.Controls.Clear();
            pnKhoaMain.Controls.Add(userControl);
            pnKhoaMain.BringToFront();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                string ma = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
                string ten = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
                UC_Khoa_U u = new UC_Khoa_U(ma,ten,this);
                AddUsercontrol(u);
            }
            
        }
        public void close_uc()
        {
            pnKhoaMain.Controls.Clear();
            pnKhoaMain.Controls.Add(dgvData);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "";
            string key = txtKey.Text.Trim();
            if(this.keySearch == 0 && key!="")
            {
                sql = "SELECT * FROM departments WHERE departmentid = " + key; 
            }
            else if(this.keySearch == 1 && key != "")
            {
                sql = "SELECT * FROM departments WHERE departmentname LIKE '%" + key+"%'";
            }
            else
            {
                sql = "SELECT * FROM departments";
            }
            dgvData.DataSource = new database().QuerySQL(sql);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenkhoa = txtTen.Text.Trim();
            if (tenkhoa != "")
            {
                string sql = "SELECT COUNT(*) FROM departments WHERE departmentname LIKE N'" + tenkhoa + "'";
                var rs = new database().QuerySQL(sql);
                int rss = -1;
                if (int.TryParse(rs.Rows[0][0].ToString(), out rss) && rss == 0)
                {
                    sql = "INSERT INTO departments (departmentname) VALUES (N'" + tenkhoa + "')";
                    //MessageBox.Show(sql);
                    int kq = new database().QuerySQL_No(sql);
                    if (kq == 1)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công", "Thêm dữ liệu thành công");
                        string type = "CREATE";
                        string detail = "Username " + user.username + ", CREATE khoa mới với tên khoa: "+tenkhoa;
                        new database().ActivityLog(type, detail);
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thất bại", "Thêm dữ liệu thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Tên sử dụng đã tôn tại trong cơ sở dữ liệu", "Thêm dữ liệu thất bại");
                }
            }
            else
            {
                MessageBox.Show("Không được để trống dữ liệu", "Cập nhật thất bại");
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
