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
namespace ql_spkh
{
    public partial class frmChon : Form
    {
        public frmChon()
        {
            InitializeComponent();
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
        public event EventHandler<DataReadyEventArgs> DataReady;
        private void dgvDataP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDataP.Columns["colXem"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvDataP.CurrentRow.Cells["projectid"].Value);


                frmChonDT form2 = new frmChonDT(id);
                form2.DataReady += Form2_DataReady; 

                form2.ShowDialog();

            }
        }
        private void Form2_DataReady(object sender, DataReadyEventArgs e)
        {
            string titlle = e.title;
            string dataFromForm2 = e.Data;
            DataReady?.Invoke(this, new DataReadyEventArgs(titlle, dataFromForm2));

            this.Close();
            
        }
        private void frmChon_Load(object sender, EventArgs e)
        {
            load();
        }
        public async void load()
        {
            pbLoad.Invoke((Action)delegate
            {
                pbLoad.Visible = true;
            });
            await Task.Run(() =>
            {
                string sql = "SELECT projects.projectid,title,departments.departmentname as Khoa,advisors.advisorname as gv, grade FROM projects JOIN departments ON departments.departmentid = projects.departmentid JOIN advisors ON advisors.advisorid = projects.advisorid WHERE typeproject = " + typeproject;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string sql = "SELECT projects.projectid,title,departments.departmentname as Khoa,advisors.advisorname as gv, grade FROM projects JOIN departments ON departments.departmentid = projects.departmentid JOIN advisors ON advisors.advisorid = projects.advisorid WHERE typeproject = " + typeproject;
            switch (value_key)
            {
                case 0:
                    {
                        sql += " AND projects.projectid = " + key;
                    }; break;
                case 1:
                    {
                        sql += " AND projects.title like '%" + key + "%'";
                    }; break;
                case 2:
                    {
                        sql += " AND departments.departmentname like '%" + key + "%'";
                    }; break;
                case 3:
                    {
                        sql += " AND advisors.advisorname like '%" + key + "%'";
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

        private void cbbLoaiProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadFirst == 0)
            {
                loadFirst = 1;
                return;
            }
            typeproject = int.Parse(cbbLoaiProject.SelectedValue?.ToString());
            load();
        }
    }

}
