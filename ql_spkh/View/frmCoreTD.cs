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
using ql_spkh.Levenshtein;
namespace ql_spkh.View
{
    public partial class frmCoreTD : Form
    {
        public frmCoreTD(string t,int p)
        {
            InitializeComponent();
            this.t = t;
            this.p = p;
        }
        private List<KeyValuePair<string, int>> danhSach = new List<KeyValuePair<string, int>>();
        private string t;
        private int p;
        private void frmCoreTD_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = null;
            load(t, p);
        }
        private void load(string title,int typeproject)
        {
            string sql = "SELECT title FROM projects WHERE typeproject = " + typeproject;

            System.Data.DataTable rs = new System.Data.DataTable();
            rs = new database().QuerySQL(sql);
            pbLoad.Visible = true;
            //guna2Button1.Enabled = false;
            System.Threading.Tasks.Task.Run(() =>
            {
                foreach (DataRow row in rs.Rows)
                {
                    string ten = row["title"].ToString();
                    int giaTri = int.Parse(LevenshteinRun.run(title, ten));

                    danhSach.Add(new KeyValuePair<string, int>(ten, giaTri));
                }
                danhSach.Sort((x, y) => y.Value.CompareTo(x.Value));
                this.Invoke((MethodInvoker)delegate
                {
                    dgvData.DataSource = danhSach;
                    pbLoad.Visible = false;
                    //guna2Button1.Enabled = true;
                });
            });
        }
    }
}
