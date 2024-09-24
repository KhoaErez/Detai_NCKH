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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            if(user.userid == -1)
            {
                this.Close();
                new Login().Show();
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            txtName.Text = user.fullname;
            if(user.role == 1)
            {
                btnKhoa.Visible = false;
                btnGV.Visible = false;
                btnAccount.Visible = false;
                btnHistory.Visible = false;
                pnProject.Visible = false;
            }
            else if(user.role == 2)
            {
                btnAccount.Visible = false;
                btnHistory.Visible = false;
            }
        }
        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            user.clearUser();
            new Login().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string type = "LOGOUT";
            string detail = "Username " + user.username + ", LOGOUT";
            new database().ActivityLog(type, detail);
            this.Close();
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "KHOA";
            UC_Khoa khoa = new UC_Khoa();
            AddUsercontrol(khoa);
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            if (pnProject.Visible == false && user.role > 1)
            {
                pnProject.Visible = true;  
            }   
            lbTitle.Text = "ĐỀ TÀI KHOA HỌC";
            frmSPKH spkh = new frmSPKH();
            AddFormcontrol(spkh);
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            if (pnDanhGia.Visible == false)
            {
                pnDanhGia.Visible = true;
            }
            else
            {
                pnDanhGia.Visible = false;
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "DANH SÁCH TÀI KHOẢN";
            frmTK spkh = new frmTK();
            AddFormcontrol(spkh);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "LỊCH SỬ HỆ THỐNG";
            frmHTR h = new frmHTR();
            AddFormcontrol(h);
        }

        private void pnUser_Paint(object sender, PaintEventArgs e)
        {

        }
        public void AddFormcontrol(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnMain.Controls.Clear();
            pnMain.Controls.Add(form);
            pnMain.Tag = form;
            form.BringToFront();
            form.Show();
        }
        private void AddUsercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnMain.Controls.Clear();
            pnMain.Controls.Add(userControl);
            pnMain.BringToFront();
        }

        private void btnThemProject_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "ĐỀ TÀI NGHIÊN CỨU KHOA HỌC CƠ SỞ";
            UC_SPKH_N spkh = new UC_SPKH_N(0);
            AddUsercontrol(spkh);
        }

        private void pnController_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGV_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "GIẢNG VIÊN";
            frmGV frmGV = new frmGV();
            AddFormcontrol(frmGV);
        }

        private void pbAvatar_Click(object sender, EventArgs e)
        {
            uploadACC();
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            uploadACC();
        }
        private void uploadACC()
        {
            frmTK_U tk = new frmTK_U(user.userid,user.username,user.fullname,user.email,user.address,user.phone,user.password,user.role,0);
            tk.ShowDialog();
        }
        private void btnNCKHSV_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "ĐỀ TÀI NGHIÊN CỨU KHOA HỌC SINH VIÊN";
            UC_SPKH_N spkh = new UC_SPKH_N(1);
            AddUsercontrol(spkh);
        }

        private void btnSTKN_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "SÁNG TẠO KHỞI NGHIỆP";
            UC_SPKH_N spkh = new UC_SPKH_N(2);
            AddUsercontrol(spkh);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "ĐÁNH GIÁ ĐỘ TRÙNG LẶP";
            UC_DG_C uC_DG_C = new UC_DG_C();
            AddUsercontrol(uC_DG_C);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "ĐÁNH GIÁ ĐỘ TRÙNG LẶP";
            UC_DG_DT uC_DG_DT = new UC_DG_DT();
            AddUsercontrol(uC_DG_DT);
        }

        private void btnHDDT_Click(object sender, EventArgs e)
        {
            UC_HD hd = new UC_HD(0);
            AddUsercontrol(hd);
        }

        private void btnHDDG_Click(object sender, EventArgs e)
        {
            UC_HD hd = new UC_HD(1);
            AddUsercontrol(hd);
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            if(pnHuongDan.Visible == true)
            {
                pnHuongDan.Visible = false;
            }
            else
            {
                pnHuongDan.Visible = true;
            }    
        }
    }
}
