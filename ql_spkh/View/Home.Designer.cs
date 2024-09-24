namespace ql_spkh.View
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.pnUser = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.txtName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnController = new Guna.UI2.WinForms.Guna2Panel();
            this.pnHuongDan = new Guna.UI2.WinForms.Guna2Panel();
            this.btnHDDG = new Guna.UI2.WinForms.Guna2Button();
            this.btnHDDT = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuongDan = new Guna.UI2.WinForms.Guna2Button();
            this.btnHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnAccount = new Guna.UI2.WinForms.Guna2Button();
            this.btnGV = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhoa = new Guna.UI2.WinForms.Guna2Button();
            this.pnDanhGia = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.btnDanhGia = new Guna.UI2.WinForms.Guna2Button();
            this.pnProject = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSTKN = new Guna.UI2.WinForms.Guna2Button();
            this.btnNCKHSV = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemProject = new Guna.UI2.WinForms.Guna2Button();
            this.btnProject = new Guna.UI2.WinForms.Guna2Button();
            this.pnUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.pnController.SuspendLayout();
            this.pnHuongDan.SuspendLayout();
            this.pnDanhGia.SuspendLayout();
            this.pnProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnUser
            // 
            this.pnUser.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnUser.BorderColor = System.Drawing.Color.Black;
            this.pnUser.Controls.Add(this.btnLogout);
            this.pnUser.Controls.Add(this.txtName);
            this.pnUser.Controls.Add(this.pbAvatar);
            this.pnUser.Location = new System.Drawing.Point(15, 12);
            this.pnUser.Name = "pnUser";
            this.pnUser.Size = new System.Drawing.Size(198, 232);
            this.pnUser.TabIndex = 0;
            this.pnUser.Paint += new System.Windows.Forms.PaintEventHandler(this.pnUser_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.BorderRadius = 10;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(14, 193);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(173, 29);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtName
            // 
            this.txtName.AutoSize = false;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(14, 148);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(173, 39);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Name";
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            // 
            // pbAvatar
            // 
            this.pbAvatar.Image = ((System.Drawing.Image)(resources.GetObject("pbAvatar.Image")));
            this.pbAvatar.ImageRotate = 0F;
            this.pbAvatar.Location = new System.Drawing.Point(3, 1);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAvatar.Size = new System.Drawing.Size(192, 141);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAvatar.TabIndex = 1;
            this.pbAvatar.TabStop = false;
            this.pbAvatar.Click += new System.EventHandler(this.pbAvatar_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.Controls.Add(this.pnMain);
            this.guna2Panel1.Controls.Add(this.pnTitle);
            this.guna2Panel1.Location = new System.Drawing.Point(222, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(705, 638);
            this.guna2Panel1.TabIndex = 1;
            // 
            // pnMain
            // 
            this.pnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMain.AutoScroll = true;
            this.pnMain.BackColor = System.Drawing.SystemColors.Control;
            this.pnMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnMain.BackgroundImage")));
            this.pnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnMain.Location = new System.Drawing.Point(3, 57);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(699, 581);
            this.pnMain.TabIndex = 1;
            this.pnMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnMain_Paint);
            // 
            // pnTitle
            // 
            this.pnTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnTitle.Controls.Add(this.guna2CirclePictureBox1);
            this.pnTitle.Controls.Add(this.lbTitle);
            this.pnTitle.Location = new System.Drawing.Point(3, 3);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(699, 51);
            this.pnTitle.TabIndex = 0;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(608, -2);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(88, 50);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 2;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = false;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(699, 48);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "UNETI";
            this.lbTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnController
            // 
            this.pnController.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnController.AutoScroll = true;
            this.pnController.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnController.BorderColor = System.Drawing.Color.Black;
            this.pnController.Controls.Add(this.pnHuongDan);
            this.pnController.Controls.Add(this.btnHuongDan);
            this.pnController.Controls.Add(this.btnHistory);
            this.pnController.Controls.Add(this.btnAccount);
            this.pnController.Controls.Add(this.btnGV);
            this.pnController.Controls.Add(this.btnKhoa);
            this.pnController.Controls.Add(this.pnDanhGia);
            this.pnController.Controls.Add(this.btnDanhGia);
            this.pnController.Controls.Add(this.pnProject);
            this.pnController.Controls.Add(this.btnProject);
            this.pnController.Location = new System.Drawing.Point(15, 250);
            this.pnController.Name = "pnController";
            this.pnController.Size = new System.Drawing.Size(201, 399);
            this.pnController.TabIndex = 0;
            this.pnController.Paint += new System.Windows.Forms.PaintEventHandler(this.pnController_Paint);
            // 
            // pnHuongDan
            // 
            this.pnHuongDan.Controls.Add(this.btnHDDG);
            this.pnHuongDan.Controls.Add(this.btnHDDT);
            this.pnHuongDan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHuongDan.Location = new System.Drawing.Point(0, 433);
            this.pnHuongDan.Name = "pnHuongDan";
            this.pnHuongDan.Size = new System.Drawing.Size(184, 82);
            this.pnHuongDan.TabIndex = 8;
            this.pnHuongDan.Visible = false;
            // 
            // btnHDDG
            // 
            this.btnHDDG.BorderRadius = 5;
            this.btnHDDG.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHDDG.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHDDG.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHDDG.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHDDG.FillColor = System.Drawing.Color.Red;
            this.btnHDDG.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnHDDG.ForeColor = System.Drawing.Color.White;
            this.btnHDDG.Location = new System.Drawing.Point(52, 35);
            this.btnHDDG.Name = "btnHDDG";
            this.btnHDDG.Size = new System.Drawing.Size(147, 26);
            this.btnHDDG.TabIndex = 5;
            this.btnHDDG.Text = "Đánh giá";
            this.btnHDDG.Click += new System.EventHandler(this.btnHDDG_Click);
            // 
            // btnHDDT
            // 
            this.btnHDDT.BorderRadius = 5;
            this.btnHDDT.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHDDT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHDDT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHDDT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHDDT.FillColor = System.Drawing.Color.Red;
            this.btnHDDT.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnHDDT.ForeColor = System.Drawing.Color.White;
            this.btnHDDT.Location = new System.Drawing.Point(50, 3);
            this.btnHDDT.Name = "btnHDDT";
            this.btnHDDT.Size = new System.Drawing.Size(147, 26);
            this.btnHDDT.TabIndex = 4;
            this.btnHDDT.Text = "Đề tài";
            this.btnHDDT.Click += new System.EventHandler(this.btnHDDT_Click);
            // 
            // btnHuongDan
            // 
            this.btnHuongDan.BorderRadius = 10;
            this.btnHuongDan.BorderThickness = 1;
            this.btnHuongDan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuongDan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuongDan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuongDan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuongDan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHuongDan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnHuongDan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuongDan.ForeColor = System.Drawing.Color.Black;
            this.btnHuongDan.Location = new System.Drawing.Point(0, 392);
            this.btnHuongDan.Name = "btnHuongDan";
            this.btnHuongDan.Size = new System.Drawing.Size(184, 41);
            this.btnHuongDan.TabIndex = 7;
            this.btnHuongDan.Text = " Hướng dẫn";
            this.btnHuongDan.Click += new System.EventHandler(this.btnHuongDan_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BorderRadius = 10;
            this.btnHistory.BorderThickness = 1;
            this.btnHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHistory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHistory.ForeColor = System.Drawing.Color.Black;
            this.btnHistory.Location = new System.Drawing.Point(0, 348);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(184, 44);
            this.btnHistory.TabIndex = 6;
            this.btnHistory.Text = "Lịch sử hoạt động";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.BorderRadius = 10;
            this.btnAccount.BorderThickness = 1;
            this.btnAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAccount.ForeColor = System.Drawing.Color.Black;
            this.btnAccount.Location = new System.Drawing.Point(0, 309);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(184, 39);
            this.btnAccount.TabIndex = 5;
            this.btnAccount.Text = "Quản lý tài khoản";
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnGV
            // 
            this.btnGV.BackColor = System.Drawing.Color.Transparent;
            this.btnGV.BorderRadius = 10;
            this.btnGV.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.btnGV.BorderThickness = 1;
            this.btnGV.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGV.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGV.ForeColor = System.Drawing.Color.Black;
            this.btnGV.Location = new System.Drawing.Point(0, 272);
            this.btnGV.Name = "btnGV";
            this.btnGV.Size = new System.Drawing.Size(184, 37);
            this.btnGV.TabIndex = 4;
            this.btnGV.Text = "Giảng viên";
            this.btnGV.UseTransparentBackground = true;
            this.btnGV.Click += new System.EventHandler(this.btnGV_Click);
            // 
            // btnKhoa
            // 
            this.btnKhoa.BackColor = System.Drawing.Color.Transparent;
            this.btnKhoa.BorderRadius = 10;
            this.btnKhoa.BorderThickness = 1;
            this.btnKhoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnKhoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKhoa.ForeColor = System.Drawing.Color.Black;
            this.btnKhoa.Location = new System.Drawing.Point(0, 235);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(184, 37);
            this.btnKhoa.TabIndex = 3;
            this.btnKhoa.Text = "Khoa";
            this.btnKhoa.UseTransparentBackground = true;
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            // 
            // pnDanhGia
            // 
            this.pnDanhGia.Controls.Add(this.guna2Button2);
            this.pnDanhGia.Controls.Add(this.guna2Button3);
            this.pnDanhGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnDanhGia.Location = new System.Drawing.Point(0, 171);
            this.pnDanhGia.Name = "pnDanhGia";
            this.pnDanhGia.Size = new System.Drawing.Size(184, 64);
            this.pnDanhGia.TabIndex = 6;
            this.pnDanhGia.Visible = false;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 5;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Red;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(55, 31);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(143, 25);
            this.guna2Button2.TabIndex = 4;
            this.guna2Button2.Text = "Đánh giá chi tiết";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderRadius = 5;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.Red;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(55, 3);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(143, 25);
            this.guna2Button3.TabIndex = 3;
            this.guna2Button3.Text = "Đánh giá chung";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // btnDanhGia
            // 
            this.btnDanhGia.BorderRadius = 10;
            this.btnDanhGia.BorderThickness = 1;
            this.btnDanhGia.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDanhGia.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDanhGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDanhGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDanhGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDanhGia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnDanhGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDanhGia.ForeColor = System.Drawing.Color.Black;
            this.btnDanhGia.Location = new System.Drawing.Point(0, 130);
            this.btnDanhGia.Margin = new System.Windows.Forms.Padding(0, 10, 0, 100);
            this.btnDanhGia.Name = "btnDanhGia";
            this.btnDanhGia.Size = new System.Drawing.Size(184, 41);
            this.btnDanhGia.TabIndex = 2;
            this.btnDanhGia.Text = "Đánh giá độ trùng";
            this.btnDanhGia.Click += new System.EventHandler(this.btnDanhGia_Click);
            // 
            // pnProject
            // 
            this.pnProject.Controls.Add(this.btnSTKN);
            this.pnProject.Controls.Add(this.btnNCKHSV);
            this.pnProject.Controls.Add(this.btnThemProject);
            this.pnProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnProject.Location = new System.Drawing.Point(0, 40);
            this.pnProject.Name = "pnProject";
            this.pnProject.Size = new System.Drawing.Size(184, 90);
            this.pnProject.TabIndex = 1;
            this.pnProject.Visible = false;
            // 
            // btnSTKN
            // 
            this.btnSTKN.BorderRadius = 5;
            this.btnSTKN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSTKN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSTKN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSTKN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSTKN.FillColor = System.Drawing.Color.Red;
            this.btnSTKN.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSTKN.ForeColor = System.Drawing.Color.White;
            this.btnSTKN.Location = new System.Drawing.Point(55, 62);
            this.btnSTKN.Name = "btnSTKN";
            this.btnSTKN.Size = new System.Drawing.Size(143, 25);
            this.btnSTKN.TabIndex = 5;
            this.btnSTKN.Text = "Sáng tạo KN";
            this.btnSTKN.Click += new System.EventHandler(this.btnSTKN_Click);
            // 
            // btnNCKHSV
            // 
            this.btnNCKHSV.BorderRadius = 5;
            this.btnNCKHSV.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNCKHSV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNCKHSV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNCKHSV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNCKHSV.FillColor = System.Drawing.Color.Red;
            this.btnNCKHSV.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNCKHSV.ForeColor = System.Drawing.Color.White;
            this.btnNCKHSV.Location = new System.Drawing.Point(55, 31);
            this.btnNCKHSV.Name = "btnNCKHSV";
            this.btnNCKHSV.Size = new System.Drawing.Size(143, 25);
            this.btnNCKHSV.TabIndex = 4;
            this.btnNCKHSV.Text = "Đề tài NCKH SV";
            this.btnNCKHSV.Click += new System.EventHandler(this.btnNCKHSV_Click);
            // 
            // btnThemProject
            // 
            this.btnThemProject.BorderRadius = 5;
            this.btnThemProject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemProject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemProject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemProject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemProject.FillColor = System.Drawing.Color.Red;
            this.btnThemProject.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThemProject.ForeColor = System.Drawing.Color.White;
            this.btnThemProject.Location = new System.Drawing.Point(55, 3);
            this.btnThemProject.Name = "btnThemProject";
            this.btnThemProject.Size = new System.Drawing.Size(143, 25);
            this.btnThemProject.TabIndex = 3;
            this.btnThemProject.Text = "Đề tài NCKH CS";
            this.btnThemProject.Click += new System.EventHandler(this.btnThemProject_Click);
            // 
            // btnProject
            // 
            this.btnProject.BorderRadius = 10;
            this.btnProject.BorderThickness = 1;
            this.btnProject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProject.ForeColor = System.Drawing.Color.Black;
            this.btnProject.Location = new System.Drawing.Point(0, 0);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(184, 40);
            this.btnProject.TabIndex = 0;
            this.btnProject.Text = "Đề tài khoa học";
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(937, 661);
            this.Controls.Add(this.pnController);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.pnUser);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Home_FormClosed);
            this.Load += new System.EventHandler(this.Home_Load);
            this.pnUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.pnController.ResumeLayout(false);
            this.pnHuongDan.ResumeLayout(false);
            this.pnDanhGia.ResumeLayout(false);
            this.pnProject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnUser;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAvatar;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnController;
        private Guna.UI2.WinForms.Guna2Button btnKhoa;
        private Guna.UI2.WinForms.Guna2Panel pnMain;
        private Guna.UI2.WinForms.Guna2Panel pnTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTitle;
        private Guna.UI2.WinForms.Guna2Button btnAccount;
        private Guna.UI2.WinForms.Guna2Button btnDanhGia;
        private Guna.UI2.WinForms.Guna2Panel pnProject;
        private Guna.UI2.WinForms.Guna2Button btnThemProject;
        private Guna.UI2.WinForms.Guna2Button btnProject;
        private Guna.UI2.WinForms.Guna2Button btnHistory;
        private Guna.UI2.WinForms.Guna2Button btnGV;
        private Guna.UI2.WinForms.Guna2Button btnSTKN;
        private Guna.UI2.WinForms.Guna2Button btnNCKHSV;
        private Guna.UI2.WinForms.Guna2Panel pnDanhGia;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button btnHuongDan;
        private Guna.UI2.WinForms.Guna2Panel pnHuongDan;
        private Guna.UI2.WinForms.Guna2Button btnHDDG;
        private Guna.UI2.WinForms.Guna2Button btnHDDT;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}