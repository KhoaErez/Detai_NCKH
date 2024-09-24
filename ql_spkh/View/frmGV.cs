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
    public partial class frmGV : Form
    {
        public frmGV()
        {
            InitializeComponent();
        }

        private void frmGV_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM departments";
            cbbKhoa.DataSource = new database().QuerySQL(sql);
            cbbKhoa.DisplayMember = "departmentname";
            cbbKhoa.ValueMember = "departmentid";
            load();
            cbbKey.SelectedIndex = 0;
        }
        private void load()
        {
            string sql2 = "SELECT a.advisorid,a.advisorname,d.departmentname FROM advisors a JOIN departments d ON d.departmentid = a.departmentid";
            dgvData.DataSource = new database().QuerySQL(sql2);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenkhoa = txtTen.Text.Trim();
            string khoa = cbbKhoa.SelectedValue.ToString();
            if (tenkhoa != "")
            {
                
                    string sql = "INSERT INTO advisors VALUES (N'" + tenkhoa + "', "+khoa+")";
                    //MessageBox.Show(sql);
                    int kq = new database().QuerySQL_No(sql);
                    if (kq == 1)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công", "Thêm dữ liệu thành công");

                        string type = "CREATE";
                        string detail = "Username " + user.username + ", Tạo mới giản viên tên: "+tenkhoa+", khoa: "+khoa;
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
                MessageBox.Show("Không được để trống dữ liệu", "Cập nhật thất bại");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ma = Convert.ToInt32(dgvData.CurrentRow.Cells["advisorid"].Value);
                string ten = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
                string khoa = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();

                frmGV_U gvu = new frmGV_U(ma, ten, khoa);
                gvu.ShowDialog();
                load();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text.Trim();
            string keyS= cbbKey.Text.Trim(); //Id Tên
            if (keyS == "Id")
            {
                string sql2 = "SELECT a.advisorid,a.advisorname,d.departmentname FROM advisors a JOIN departments d ON d.departmentid = a.departmentid WHERE a.advisorid = "+key;
                dgvData.DataSource = new database().QuerySQL(sql2);
            }
            else if(keyS == "Tên")
            {
                string sql2 = "SELECT a.advisorid,a.advisorname,d.departmentname FROM advisors a JOIN departments d ON d.departmentid = a.departmentid WHERE a.advisorname LIKE '%"+key+"%'";
                dgvData.DataSource = new database().QuerySQL(sql2);
            }
            else
            {
                string sql2 = "SELECT a.advisorid,a.advisorname,d.departmentname FROM advisors a JOIN departments d ON d.departmentid = a.departmentid WHERE d.departmentname = N'"+key+"'";
                dgvData.DataSource = new database().QuerySQL(sql2);
            }
        }
    }
}
