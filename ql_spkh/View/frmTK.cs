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
    public partial class frmTK : Form
    {
        public frmTK()
        {
            InitializeComponent();
        }

        private void frmTK_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            string sql = "SELECT * FROM users";
            dgvData.DataSource = new database().QuerySQL(sql);
            cbbKey.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = cbbKey.Text;
            string keyS = txtKey.Text.Trim();
            string sql = "SELECT * FROM users";
            switch (key)
            {
                case "Username":
                    {
                        sql = "SELECT * FROM users WHERE username = '"+keyS+"'";
                    };break;
                case "Fullname":
                    {
                        sql = "SELECT * FROM users WHERE fullname = N'" + keyS+"'";
                    }; break;
                case "Address":
                    {
                        sql = "SELECT * FROM users WHERE address = N'" + keyS+"'";
                    }; break;
                case "Email":
                    {
                        sql = "SELECT * FROM users WHERE email = N'" + keyS + "'";

                    }; break;
                case "Phone":
                    {
                        sql = "SELECT * FROM users WHERE phone = N'" + keyS + "'";


                    }; break;
                case "Role":
                    {
                        sql = "SELECT * FROM users WHERE role = " + keyS;

                    }; break;
            }
            dgvData.DataSource = new database().QuerySQL(sql);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new frmTK_N().ShowDialog();
            load();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvData.CurrentRow.Cells[0].Value);
                string username = dgvData.CurrentRow.Cells[1].Value.ToString();
                string fullname = dgvData.CurrentRow.Cells[2].Value.ToString();
                string email = dgvData.CurrentRow.Cells[3].Value.ToString();
                string address = dgvData.CurrentRow.Cells[4].Value.ToString();
                string phone = dgvData.CurrentRow.Cells[5].Value.ToString();
                string password = dgvData.CurrentRow.Cells[6].Value.ToString();
                int role = Convert.ToInt32(dgvData.CurrentRow.Cells[7].Value);

                frmTK_U tku = new frmTK_U(id,username,fullname,email,address,phone,password,role,1);
                tku.ShowDialog();
                load();
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
