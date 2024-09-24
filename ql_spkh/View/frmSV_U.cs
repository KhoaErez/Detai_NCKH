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
    public partial class frmSV_U : Form
    {
        public frmSV_U(int idsv,int sdpr, string hoten, string cn, string k, string em, string l)
        {
            InitializeComponent();
            this.idsv = idsv;
            this.idgr = sdpr;
            this.hoten = hoten;
            this.cn = k;
            this.k = cn; 
            this.em = em;
            this.l = l;
        }
        int idsv, idgr;
        string hoten, cn, k, em, l;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM projectparticipants WHERE projectparticipantid= " + idgr;
            string sql2 = "DELETE FROM students WHERE studentid = " + idsv; 
            if(new database().QuerySQL_No(sql) > 0)
            {
                if(new database().QuerySQL_No(sql2) > 0)
                {
                    MessageBox.Show("Xóa thành công", "Thành công");
                    string type = "DELETE";
                    string detail = "Username " + user.username + ", Xóa dữ liệu cho sinh viên id: " + idsv + "có họ tên: " + this.hoten + ", chuyên ngành: " + this.cn + ", khoa: " + this.k + ", trong projectparticipants có id: " + idgr;
                    new database().ActivityLog(type, detail);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại 1", "thất bại");
                }
            }
            else
            {
                MessageBox.Show("Xóa thất bại 2", "thất bại");
            }
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string h = txtTen.Text.Trim();
            string cn = txtCN.Text.Trim();
            string email = txtEmail.Text.Trim();
            string khoa = cbbKhoa.SelectedValue.ToString();
            string l = cbbMember.Text.Trim();
            int isL = 0;
            if(l == "Leader")
            {
                isL = 1;
            }
            if(h!=""&&cn!="")
            {
                 string sql = "UPDATE students SET " +
                    "studentname=N'"+h+ "', major=N'" +cn+"'," +
                    "email=N'"+email+ "',departmentid = "+khoa+" WHERE studentid = "+idsv;
                int rs = new database().QuerySQL_No(sql);
                if(rs > 0)
                {
                    string sql2 = "UPDATE projectparticipants SET leader = " + isL + " WHERE projectparticipantid= " + idgr;
                    int rs2 = new database().QuerySQL_No(sql2);
                    if(rs2 > 0)
                    {
                        MessageBox.Show("Thành công", "Thành công");

                        string type = "UPDATE";
                        string detail = "Username " + user.username + ", Cập nhật dữ liệu cho sinh viên id: "+idsv+ "có họ tên: " + this.hoten + ", chuyên ngành: " + this.cn + ", khoa: " + this.k + ", trong projectparticipants có id: " + idgr;
                        new database().ActivityLog(type, detail);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại", "Thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Thất bại", "Thất bại");
                }
            }
            
        }

        private void frmSV_U_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM departments";
            cbbKhoa.DataSource = new database().QuerySQL(sql);
            cbbKhoa.DisplayMember = "departmentname";
            cbbKhoa.ValueMember = "departmentid";

            
            foreach (var item in cbbKhoa.Items)
            {
                DataRowView row = item as DataRowView;
                if (row != null && row["departmentname"].ToString() == k)
                {
                    cbbKhoa.SelectedValue = row["departmentid"];
                    break;
                }
            }
            foreach (var item in cbbMember.Items)
            {
                string displayValue = item.ToString();
                if (displayValue == l)
                {
                    cbbMember.SelectedItem = item;
                    break;
                }
            }

            txtTen.Text = hoten;
            txtCN.Text = cn;
            txtEmail.Text = em;
        }
    }
}
