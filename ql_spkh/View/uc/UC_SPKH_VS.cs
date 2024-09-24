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
    public partial class UC_SPKH_VS : UserControl
    {
        public UC_SPKH_VS(int id)
        {
            InitializeComponent();
            projectid = id;
        }
        private int projectid;
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_SPKH_VS_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            string sql = "SELECT versionid,versionname,description,datecreate FROM projectversions WHERE projectid = " + projectid;
            dgvData.DataSource = new database().QuerySQL(sql);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvData.Rows.Count - 1)
            {
                int id = Convert.ToInt32(dgvData.CurrentRow.Cells[0].Value);
                string ten = dgvData.CurrentRow.Cells[1].Value.ToString();
                string desc = dgvData.CurrentRow.Cells[2].Value.ToString();
                frmVS_U vsu = new frmVS_U(id,ten,desc);
                vsu.ShowDialog();
                load();
            }
        }
    }
}
