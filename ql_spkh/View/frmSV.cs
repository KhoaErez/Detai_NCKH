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
    public partial class frmSV : Form
    {
        public frmSV(int id)
        {
            InitializeComponent();
            projectid = id;
        }
        private int projectid = -1;
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            
        }
        private void load()
        {
            if(projectid!= -1)
            {
                string sql = "SELECT ps.projectparticipantid, s.studentid,s.studentname,d.departmentname,s.major,s.email, CASE WHEN ps.leader = 1 THEN 'Leader' ELSE 'Member' END AS leader from students s JOIN projectparticipants ps ON ps.studentid = s.studentid JOIN departments d ON s.departmentid = d.departmentid WHERE ps.projectid = " + projectid;
                dgvData.DataSource = new database().QuerySQL(sql);
            }
            else
            {
                MessageBox.Show("Không tìm thấy project thích hợp: "+ projectid, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSV_Load(object sender, EventArgs e)
        {
            if(user.role == 1)
            {
                btnThem.Enabled = false;
                dgvData.Enabled = false;
            }
            load();
            string sql = "SELECT * FROM departments";
            cbbKhoa.DataSource = new database().QuerySQL(sql);
            cbbKhoa.DisplayMember = "departmentname";
            cbbKhoa.ValueMember = "departmentid";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoten, cn, khoa, email;
            hoten = txtTen.Text.Trim();
            cn = txtCN.Text.Trim();
            khoa = cbbKhoa.SelectedValue.ToString();
            email = txtEmail.Text.Trim();

            if(hoten!=""&&cn!=""&&email!="")
            {
                List<parameter> list = new List<parameter>();
                list.Add(new parameter()
                {
                    key = "@studentname",
                    value = hoten
                });
                list.Add(new parameter()
                {
                    key = "@major",
                    value = cn
                });
                list.Add(new parameter()
                {
                    key = "@email",
                    value = email
                });
                list.Add(new parameter()
                {
                    key = "@departmentid",
                    value = khoa
                });
                parameter.kiemTra_Value(list);
                int rs2 = new database().Query_P("ThemSV", list);
                int studentID = int.Parse(new database().QuerySQL("SELECT TOP 1 studentid FROM students ORDER BY studentid DESC").Rows[0][0].ToString());
                string sql = "INSERT INTO projectparticipants VALUES ("+studentID+","+projectid+",0)";
                
                int rs = new database().QuerySQL_No(sql);
                if(rs > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công", "Thành công");

                    string type = "CREATE";
                    string detail = "Username " + user.username + ", Thêm sinh viên họ tên: " + hoten+", email: "+email+", khoa: "+khoa+" , vào đề tài id: "+projectid;
                    new database().ActivityLog(type, detail);

                    load();
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu thất bại", "thất bại");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
            txtEmail.Clear();
            txtCN.Clear();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idgr = Convert.ToInt32(dgvData.CurrentRow.Cells[0].Value);
                int idSV = Convert.ToInt32(dgvData.CurrentRow.Cells[1].Value);
                string hoten = dgvData.CurrentRow.Cells[2].Value.ToString();
                string cn = dgvData.CurrentRow.Cells[3].Value.ToString();
                string k = dgvData.CurrentRow.Cells[4].Value.ToString();
                string em = dgvData.CurrentRow.Cells[5].Value.ToString();
                string l = dgvData.CurrentRow.Cells[6].Value.ToString();
                new frmSV_U(idSV,idgr,hoten,cn,k,em,l).ShowDialog();
                load();
            }
            
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
