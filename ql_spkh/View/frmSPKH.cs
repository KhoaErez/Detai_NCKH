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
using ql_spkh.View.uc;
namespace ql_spkh.View
{
    public partial class frmSPKH : Form
    {
        public frmSPKH()
        {
            InitializeComponent();
            cbbKey.SelectedIndex = 0;
            List<KeyValuePair<string, string>> dataList = new List<KeyValuePair<string, string>>();

            // Thêm các mục vào danh sách
            dataList.Add(new KeyValuePair<string, string>("0", "Đề tài NCKH CS"));
            dataList.Add(new KeyValuePair<string, string>("1", "Đề tài NCKH SV"));
            dataList.Add(new KeyValuePair<string, string>("2", "Sáng tạo KN"));

            // Đặt danh sách dữ liệu vào ComboBox
            cbbLoaiProject.DisplayMember = "Value"; // Hiển thị dữ liệu này
            cbbLoaiProject.ValueMember = "Key"; // Dữ liệu trả về
            cbbLoaiProject.DataSource = dataList;

            cbbLoaiProject.SelectedIndex = 0;
        }
        private int typeproject = 0;
        private int loadFirst = 0;
        private void frmSPKH_Load(object sender, EventArgs e)
        {
            load();
        }
        public void close_uc()
        {
            pnMainDSSP.Controls.Clear();
            pnMainDSSP.Controls.Add(dgvDataP);
        }
        public async void load()
        {
            pbLoad.Invoke((Action)delegate
            {
                pbLoad.Visible = true;
            });
            await Task.Run(() =>
            {
                string sql = "SELECT projects.projectid,title,departments.departmentname as Khoa,advisors.advisorname as gv, grade FROM projects JOIN departments ON departments.departmentid = projects.departmentid JOIN advisors ON advisors.advisorid = projects.advisorid WHERE typeproject = "+typeproject;
                return new database().QuerySQL(sql);
            }).ContinueWith(task =>
            {
                dgvDataP.Invoke((Action)delegate
                {
                    dgvDataP.DataSource = task.Result;
                });
                pbLoad.Invoke((Action)delegate
                {
                    pbLoad.Visible = false;
                });
            });
            
        }
        int value_key = 0;
        private void dgvDataP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDataP.Columns["colXem"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvDataP.CurrentRow.Cells["projectid"].Value);
                UC_SPKH_DT spdt = new UC_SPKH_DT(id,this);
                AddUsercontrol(spdt);

            }
            else if (e.ColumnIndex == dgvDataP.Columns["colHistory"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvDataP.CurrentRow.Cells["projectid"].Value);
                UC_SPKH_VS spvs = new UC_SPKH_VS(id);
                AddUsercontrol(spvs);
            }
            else
            {
                int id = Convert.ToInt32(dgvDataP.CurrentRow.Cells["projectid"].Value);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string sql = "SELECT projects.projectid,title,departments.departmentname as Khoa,advisors.advisorname as gv, grade FROM projects JOIN departments ON departments.departmentid = projects.departmentid JOIN advisors ON advisors.advisorid = projects.advisorid WHERE typeproject = "+ typeproject;
            switch (value_key)
            {
                case 0:
                    {
                        sql += " AND projects.projectid = " + key;
                    };break;
                case 1:
                    {
                        sql += " AND projects.title like N'%" + key + "%'";
                    };break;
                case 2:
                    {
                        sql += " AND departments.departmentname like N'%" + key + "%'";
                    }; break;
                case 3:
                    {
                        sql += " AND advisors.advisorname like N'%" + key + "%'";
                    }; break;
                case 4:
                    {
                        sql += " AND grade = " + key;
                    }; break;
                default:
                    {
                        load();
                    }
                    break;
                    
            }
            dgvDataP.DataSource = new database().QuerySQL(sql);
        }

        private void cbbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            value_key = cbbKey.SelectedIndex;
        }
        private void AddUsercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnMainDSSP.Controls.Clear();
            pnMainDSSP.Controls.Add(userControl);
            pnMainDSSP.BringToFront();
        }

        private void pbLoad_Click(object sender, EventArgs e)
        {

        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbLoaiProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loadFirst == 0)
            {
                loadFirst = 1;
                return;
            }
            typeproject = int.Parse(cbbLoaiProject.SelectedValue?.ToString());
            load();
        }
    }
}
