namespace BanVeMayBay
{
    partial class frm_DSPhieuDatCho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Them = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_NgayDat = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txt_MaHangVe = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_MaKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_MaChuyenBay = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_TimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Sua = new Guna.UI2.WinForms.Guna2Button();
            this.txt_SoGhe = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_MaPhieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnl_ThongTinKH = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnMCB = new Guna.UI2.WinForms.Guna2Button();
            this.btn_ChonMKH = new Guna.UI2.WinForms.Guna2Button();
            this.txt_HangGhe = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Xoa = new Guna.UI2.WinForms.Guna2Button();
            this.dgv_PDC = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txt_Search = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnl_ThongTinKH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PDC)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Them
            // 
            this.btn_Them.AutoRoundedCorners = true;
            this.btn_Them.BorderRadius = 22;
            this.btn_Them.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Them.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Them.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Them.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Them.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.Color.Black;
            this.btn_Them.Image = global::BanVeMayBay.Properties.Resources.add;
            this.btn_Them.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_Them.Location = new System.Drawing.Point(9, 514);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(180, 46);
            this.btn_Them.TabIndex = 27;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 28);
            this.label1.TabIndex = 25;
            this.label1.Text = "Mã hạng vé";
            // 
            // dtp_NgayDat
            // 
            this.dtp_NgayDat.AutoRoundedCorners = true;
            this.dtp_NgayDat.BackColor = System.Drawing.Color.White;
            this.dtp_NgayDat.BorderRadius = 14;
            this.dtp_NgayDat.Checked = true;
            this.dtp_NgayDat.FillColor = System.Drawing.Color.White;
            this.dtp_NgayDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_NgayDat.ForeColor = System.Drawing.Color.Black;
            this.dtp_NgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayDat.Location = new System.Drawing.Point(358, 98);
            this.dtp_NgayDat.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_NgayDat.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_NgayDat.Name = "dtp_NgayDat";
            this.dtp_NgayDat.Size = new System.Drawing.Size(271, 30);
            this.dtp_NgayDat.TabIndex = 44;
            this.dtp_NgayDat.Value = new System.DateTime(2022, 10, 26, 13, 48, 11, 128);
            // 
            // txt_MaHangVe
            // 
            this.txt_MaHangVe.AutoRoundedCorners = true;
            this.txt_MaHangVe.BorderColor = System.Drawing.Color.Black;
            this.txt_MaHangVe.BorderRadius = 14;
            this.txt_MaHangVe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MaHangVe.DefaultText = "";
            this.txt_MaHangVe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MaHangVe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MaHangVe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaHangVe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaHangVe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaHangVe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaHangVe.ForeColor = System.Drawing.Color.Black;
            this.txt_MaHangVe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaHangVe.Location = new System.Drawing.Point(358, 377);
            this.txt_MaHangVe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaHangVe.Name = "txt_MaHangVe";
            this.txt_MaHangVe.PasswordChar = '\0';
            this.txt_MaHangVe.PlaceholderText = "";
            this.txt_MaHangVe.SelectedText = "";
            this.txt_MaHangVe.Size = new System.Drawing.Size(280, 30);
            this.txt_MaHangVe.TabIndex = 25;
            // 
            // txt_MaKH
            // 
            this.txt_MaKH.AutoRoundedCorners = true;
            this.txt_MaKH.BorderColor = System.Drawing.Color.Black;
            this.txt_MaKH.BorderRadius = 14;
            this.txt_MaKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MaKH.DefaultText = "";
            this.txt_MaKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MaKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MaKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaKH.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaKH.ForeColor = System.Drawing.Color.Black;
            this.txt_MaKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaKH.Location = new System.Drawing.Point(358, 326);
            this.txt_MaKH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaKH.Name = "txt_MaKH";
            this.txt_MaKH.PasswordChar = '\0';
            this.txt_MaKH.PlaceholderText = "";
            this.txt_MaKH.SelectedText = "";
            this.txt_MaKH.Size = new System.Drawing.Size(280, 30);
            this.txt_MaKH.TabIndex = 21;
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.AutoSize = false;
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(13, 327);
            this.guna2HtmlLabel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(290, 57);
            this.guna2HtmlLabel7.TabIndex = 20;
            this.guna2HtmlLabel7.Text = "Mã khách hàng";
            // 
            // txt_MaChuyenBay
            // 
            this.txt_MaChuyenBay.AutoRoundedCorners = true;
            this.txt_MaChuyenBay.BorderColor = System.Drawing.Color.Black;
            this.txt_MaChuyenBay.BorderRadius = 14;
            this.txt_MaChuyenBay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MaChuyenBay.DefaultText = "";
            this.txt_MaChuyenBay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MaChuyenBay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MaChuyenBay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaChuyenBay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaChuyenBay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaChuyenBay.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaChuyenBay.ForeColor = System.Drawing.Color.Black;
            this.txt_MaChuyenBay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaChuyenBay.Location = new System.Drawing.Point(358, 262);
            this.txt_MaChuyenBay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaChuyenBay.Name = "txt_MaChuyenBay";
            this.txt_MaChuyenBay.PasswordChar = '\0';
            this.txt_MaChuyenBay.PlaceholderText = "";
            this.txt_MaChuyenBay.SelectedText = "";
            this.txt_MaChuyenBay.Size = new System.Drawing.Size(271, 30);
            this.txt_MaChuyenBay.TabIndex = 19;
            this.txt_MaChuyenBay.TextChanged += new System.EventHandler(this.txt_MaChuyenBay_TextChanged);
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.AutoSize = false;
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(13, 262);
            this.guna2HtmlLabel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(253, 44);
            this.guna2HtmlLabel9.TabIndex = 18;
            this.guna2HtmlLabel9.Text = "Mã chuyến bay";
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.AutoRoundedCorners = true;
            this.btn_TimKiem.BorderRadius = 22;
            this.btn_TimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_TimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_TimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_TimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_TimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TimKiem.ForeColor = System.Drawing.Color.Black;
            this.btn_TimKiem.Image = global::BanVeMayBay.Properties.Resources.search;
            this.btn_TimKiem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_TimKiem.Location = new System.Drawing.Point(9, 577);
            this.btn_TimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(180, 46);
            this.btn_TimKiem.TabIndex = 30;
            this.btn_TimKiem.Text = "Tìm kiếm";
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.AutoRoundedCorners = true;
            this.btn_Sua.BorderRadius = 22;
            this.btn_Sua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Sua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Sua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Sua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Sua.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.ForeColor = System.Drawing.Color.Black;
            this.btn_Sua.Image = global::BanVeMayBay.Properties.Resources.pencil;
            this.btn_Sua.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_Sua.Location = new System.Drawing.Point(383, 514);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(180, 46);
            this.btn_Sua.TabIndex = 29;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // txt_SoGhe
            // 
            this.txt_SoGhe.AutoRoundedCorners = true;
            this.txt_SoGhe.BorderColor = System.Drawing.Color.Black;
            this.txt_SoGhe.BorderRadius = 14;
            this.txt_SoGhe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_SoGhe.DefaultText = "";
            this.txt_SoGhe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_SoGhe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_SoGhe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_SoGhe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_SoGhe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_SoGhe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoGhe.ForeColor = System.Drawing.Color.Black;
            this.txt_SoGhe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_SoGhe.Location = new System.Drawing.Point(358, 151);
            this.txt_SoGhe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SoGhe.Name = "txt_SoGhe";
            this.txt_SoGhe.PasswordChar = '\0';
            this.txt_SoGhe.PlaceholderText = "";
            this.txt_SoGhe.SelectedText = "";
            this.txt_SoGhe.Size = new System.Drawing.Size(271, 30);
            this.txt_SoGhe.TabIndex = 17;
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.AutoSize = false;
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(13, 10);
            this.guna2HtmlLabel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(552, 66);
            this.guna2HtmlLabel8.TabIndex = 16;
            this.guna2HtmlLabel8.Text = "Danh Sách Thông Tin Giao Dịch";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.AutoSize = false;
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(13, 207);
            this.guna2HtmlLabel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(253, 60);
            this.guna2HtmlLabel5.TabIndex = 12;
            this.guna2HtmlLabel5.Text = "Hạng ghế";
            this.guna2HtmlLabel5.Click += new System.EventHandler(this.guna2HtmlLabel5_Click);
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.AutoSize = false;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(13, 147);
            this.guna2HtmlLabel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(151, 49);
            this.guna2HtmlLabel4.TabIndex = 6;
            this.guna2HtmlLabel4.Text = "Số ghế";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(13, 100);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(253, 50);
            this.guna2HtmlLabel3.TabIndex = 4;
            this.guna2HtmlLabel3.Text = "Ngày đặt";
            // 
            // txt_MaPhieu
            // 
            this.txt_MaPhieu.AutoRoundedCorners = true;
            this.txt_MaPhieu.BorderColor = System.Drawing.Color.Black;
            this.txt_MaPhieu.BorderRadius = 14;
            this.txt_MaPhieu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MaPhieu.DefaultText = "";
            this.txt_MaPhieu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MaPhieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MaPhieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaPhieu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaPhieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaPhieu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaPhieu.ForeColor = System.Drawing.Color.Black;
            this.txt_MaPhieu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaPhieu.Location = new System.Drawing.Point(358, 54);
            this.txt_MaPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaPhieu.Name = "txt_MaPhieu";
            this.txt_MaPhieu.PasswordChar = '\0';
            this.txt_MaPhieu.PlaceholderText = "";
            this.txt_MaPhieu.SelectedText = "";
            this.txt_MaPhieu.Size = new System.Drawing.Size(271, 30);
            this.txt_MaPhieu.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(13, 54);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(253, 49);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Mã phiếu";
            // 
            // pnl_ThongTinKH
            // 
            this.pnl_ThongTinKH.Controls.Add(this.btnMCB);
            this.pnl_ThongTinKH.Controls.Add(this.btn_ChonMKH);
            this.pnl_ThongTinKH.Controls.Add(this.label1);
            this.pnl_ThongTinKH.Controls.Add(this.dtp_NgayDat);
            this.pnl_ThongTinKH.Controls.Add(this.txt_MaHangVe);
            this.pnl_ThongTinKH.Controls.Add(this.txt_MaKH);
            this.pnl_ThongTinKH.Controls.Add(this.guna2HtmlLabel7);
            this.pnl_ThongTinKH.Controls.Add(this.txt_MaChuyenBay);
            this.pnl_ThongTinKH.Controls.Add(this.guna2HtmlLabel9);
            this.pnl_ThongTinKH.Controls.Add(this.txt_SoGhe);
            this.pnl_ThongTinKH.Controls.Add(this.guna2HtmlLabel8);
            this.pnl_ThongTinKH.Controls.Add(this.txt_HangGhe);
            this.pnl_ThongTinKH.Controls.Add(this.guna2HtmlLabel5);
            this.pnl_ThongTinKH.Controls.Add(this.guna2HtmlLabel4);
            this.pnl_ThongTinKH.Controls.Add(this.guna2HtmlLabel3);
            this.pnl_ThongTinKH.Controls.Add(this.txt_MaPhieu);
            this.pnl_ThongTinKH.Controls.Add(this.guna2HtmlLabel1);
            this.pnl_ThongTinKH.Location = new System.Drawing.Point(3, 43);
            this.pnl_ThongTinKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_ThongTinKH.Name = "pnl_ThongTinKH";
            this.pnl_ThongTinKH.Size = new System.Drawing.Size(700, 428);
            this.pnl_ThongTinKH.TabIndex = 26;
            // 
            // btnMCB
            // 
            this.btnMCB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMCB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMCB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMCB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMCB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMCB.ForeColor = System.Drawing.Color.White;
            this.btnMCB.Location = new System.Drawing.Point(229, 149);
            this.btnMCB.Name = "btnMCB";
            this.btnMCB.Size = new System.Drawing.Size(110, 37);
            this.btnMCB.TabIndex = 47;
            this.btnMCB.Text = "Chọn";
            this.btnMCB.Click += new System.EventHandler(this.btnMCB_Click);
            // 
            // btn_ChonMKH
            // 
            this.btn_ChonMKH.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ChonMKH.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ChonMKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ChonMKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ChonMKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_ChonMKH.ForeColor = System.Drawing.Color.White;
            this.btn_ChonMKH.Location = new System.Drawing.Point(229, 327);
            this.btn_ChonMKH.Name = "btn_ChonMKH";
            this.btn_ChonMKH.Size = new System.Drawing.Size(110, 36);
            this.btn_ChonMKH.TabIndex = 46;
            this.btn_ChonMKH.Text = "Chọn ";
            this.btn_ChonMKH.Click += new System.EventHandler(this.btn_ChonMKH_Click);
            // 
            // txt_HangGhe
            // 
            this.txt_HangGhe.AutoRoundedCorners = true;
            this.txt_HangGhe.BorderColor = System.Drawing.Color.Black;
            this.txt_HangGhe.BorderRadius = 14;
            this.txt_HangGhe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_HangGhe.DefaultText = "";
            this.txt_HangGhe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_HangGhe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_HangGhe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_HangGhe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_HangGhe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_HangGhe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HangGhe.ForeColor = System.Drawing.Color.Black;
            this.txt_HangGhe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_HangGhe.Location = new System.Drawing.Point(358, 207);
            this.txt_HangGhe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_HangGhe.Name = "txt_HangGhe";
            this.txt_HangGhe.PasswordChar = '\0';
            this.txt_HangGhe.PlaceholderText = "";
            this.txt_HangGhe.SelectedText = "";
            this.txt_HangGhe.Size = new System.Drawing.Size(271, 30);
            this.txt_HangGhe.TabIndex = 13;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.AutoRoundedCorners = true;
            this.btn_Xoa.BorderRadius = 22;
            this.btn_Xoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Xoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Xoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Xoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Xoa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.Color.Black;
            this.btn_Xoa.Image = global::BanVeMayBay.Properties.Resources.trash;
            this.btn_Xoa.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_Xoa.Location = new System.Drawing.Point(196, 514);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(180, 46);
            this.btn_Xoa.TabIndex = 28;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // dgv_PDC
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_PDC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PDC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PDC.ColumnHeadersHeight = 25;
            this.dgv_PDC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PDC.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_PDC.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_PDC.Location = new System.Drawing.Point(730, 43);
            this.dgv_PDC.Name = "dgv_PDC";
            this.dgv_PDC.RowHeadersVisible = false;
            this.dgv_PDC.RowHeadersWidth = 51;
            this.dgv_PDC.RowTemplate.Height = 24;
            this.dgv_PDC.Size = new System.Drawing.Size(1012, 922);
            this.dgv_PDC.TabIndex = 31;
            this.dgv_PDC.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_PDC.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_PDC.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_PDC.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_PDC.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_PDC.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_PDC.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_PDC.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_PDC.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_PDC.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_PDC.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_PDC.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_PDC.ThemeStyle.HeaderStyle.Height = 25;
            this.dgv_PDC.ThemeStyle.ReadOnly = false;
            this.dgv_PDC.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_PDC.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_PDC.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_PDC.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_PDC.ThemeStyle.RowsStyle.Height = 24;
            this.dgv_PDC.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_PDC.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_PDC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PDC_CellClick);
            this.dgv_PDC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PDC_CellContentClick);
            // 
            // txt_Search
            // 
            this.txt_Search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Search.DefaultText = "";
            this.txt_Search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Search.Location = new System.Drawing.Point(230, 587);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.PasswordChar = '\0';
            this.txt_Search.PlaceholderText = "";
            this.txt_Search.SelectedText = "";
            this.txt_Search.Size = new System.Drawing.Size(333, 36);
            this.txt_Search.TabIndex = 32;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // frm_DSPhieuDatCho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1732, 844);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.dgv_PDC);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.btn_TimKiem);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.pnl_ThongTinKH);
            this.Controls.Add(this.btn_Xoa);
            this.Name = "frm_DSPhieuDatCho";
            this.Text = "frm_DSPhieuDatCho";
            this.Load += new System.EventHandler(this.frm_DSPhieuDatCho_Load);
            this.pnl_ThongTinKH.ResumeLayout(false);
            this.pnl_ThongTinKH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PDC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_Them;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_NgayDat;
        private Guna.UI2.WinForms.Guna2TextBox txt_MaHangVe;
        private Guna.UI2.WinForms.Guna2TextBox txt_MaKH;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2TextBox txt_MaChuyenBay;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2Button btn_TimKiem;
        private Guna.UI2.WinForms.Guna2Button btn_Sua;
        private Guna.UI2.WinForms.Guna2TextBox txt_SoGhe;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox txt_MaPhieu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnl_ThongTinKH;
        private Guna.UI2.WinForms.Guna2TextBox txt_HangGhe;
        private Guna.UI2.WinForms.Guna2Button btn_Xoa;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_PDC;
        private Guna.UI2.WinForms.Guna2TextBox txt_Search;
        private Guna.UI2.WinForms.Guna2Button btn_ChonMKH;
        private Guna.UI2.WinForms.Guna2Button btnMCB;
    }
}