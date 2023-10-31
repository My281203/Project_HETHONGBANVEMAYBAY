namespace BanVeMayBay
{
    partial class frm_DangNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DangNhap));
            this.BorderlessFrm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnl_Login = new Guna.UI2.WinForms.Guna2Panel();
            this.link_Forget = new System.Windows.Forms.LinkLabel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_Login = new Guna.UI2.WinForms.Guna2Button();
            this.txt_Password = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_Username = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Exit = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btn_Minimum = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnl_ResetPassword = new Guna.UI2.WinForms.Guna2Panel();
            this.lb_TitleResetPass = new System.Windows.Forms.Label();
            this.btn_ExitReset = new Guna.UI2.WinForms.Guna2CircleButton();
            this.txt_RetypePassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_SetPassword = new Guna.UI2.WinForms.Guna2Button();
            this.txt_NewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_UserSetPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnl_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.pnl_ResetPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // BorderlessFrm
            // 
            this.BorderlessFrm.BorderRadius = 15;
            this.BorderlessFrm.ContainerControl = this;
            this.BorderlessFrm.DockIndicatorTransparencyValue = 0.6D;
            this.BorderlessFrm.TransparentWhileDrag = true;
            // 
            // pnl_Login
            // 
            this.pnl_Login.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Login.BorderRadius = 15;
            this.pnl_Login.Controls.Add(this.link_Forget);
            this.pnl_Login.Controls.Add(this.guna2CirclePictureBox1);
            this.pnl_Login.Controls.Add(this.btn_Login);
            this.pnl_Login.Controls.Add(this.txt_Password);
            this.pnl_Login.Controls.Add(this.txt_Username);
            this.pnl_Login.FillColor = System.Drawing.Color.Transparent;
            this.pnl_Login.ForeColor = System.Drawing.Color.Transparent;
            this.pnl_Login.Location = new System.Drawing.Point(39, 43);
            this.pnl_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_Login.Name = "pnl_Login";
            this.pnl_Login.Size = new System.Drawing.Size(365, 319);
            this.pnl_Login.TabIndex = 0;
            // 
            // link_Forget
            // 
            this.link_Forget.AutoSize = true;
            this.link_Forget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_Forget.LinkColor = System.Drawing.Color.Gold;
            this.link_Forget.Location = new System.Drawing.Point(75, 217);
            this.link_Forget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.link_Forget.Name = "link_Forget";
            this.link_Forget.Size = new System.Drawing.Size(155, 17);
            this.link_Forget.TabIndex = 5;
            this.link_Forget.TabStop = true;
            this.link_Forget.Text = "Forgoten password?";
            this.link_Forget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Forget_LinkClicked);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.InitialImage = null;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(152, 22);
            this.guna2CirclePictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(67, 62);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 3;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // btn_Login
            // 
            this.btn_Login.BorderColor = System.Drawing.Color.Turquoise;
            this.btn_Login.BorderRadius = 15;
            this.btn_Login.BorderThickness = 2;
            this.btn_Login.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Login.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Login.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_Login.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(103, 261);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(160, 36);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "Login";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_Password.BorderRadius = 15;
            this.txt_Password.BorderThickness = 2;
            this.txt_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Password.DefaultText = "";
            this.txt_Password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Password.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Password.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_Password.ForeColor = System.Drawing.Color.Black;
            this.txt_Password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Password.Location = new System.Drawing.Point(69, 174);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txt_Password.PlaceholderText = "Password";
            this.txt_Password.SelectedText = "";
            this.txt_Password.Size = new System.Drawing.Size(227, 37);
            this.txt_Password.TabIndex = 1;
            // 
            // txt_Username
            // 
            this.txt_Username.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_Username.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_Username.BorderRadius = 15;
            this.txt_Username.BorderThickness = 2;
            this.txt_Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Username.DefaultText = "";
            this.txt_Username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Username.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Username.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_Username.ForeColor = System.Drawing.Color.Black;
            this.txt_Username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Username.Location = new System.Drawing.Point(69, 118);
            this.txt_Username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.PasswordChar = '\0';
            this.txt_Username.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txt_Username.PlaceholderText = "Username";
            this.txt_Username.SelectedText = "";
            this.txt_Username.Size = new System.Drawing.Size(227, 37);
            this.txt_Username.TabIndex = 0;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Exit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Exit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Exit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Exit.FillColor = System.Drawing.Color.Snow;
            this.btn_Exit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Exit.ForeColor = System.Drawing.Color.Black;
            this.btn_Exit.Image = global::BanVeMayBay.Properties.Resources.cross;
            this.btn_Exit.ImageSize = new System.Drawing.Size(10, 10);
            this.btn_Exit.Location = new System.Drawing.Point(779, 11);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_Exit.Size = new System.Drawing.Size(23, 21);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Minimum
            // 
            this.btn_Minimum.BackColor = System.Drawing.Color.Transparent;
            this.btn_Minimum.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Minimum.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Minimum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Minimum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Minimum.FillColor = System.Drawing.Color.Snow;
            this.btn_Minimum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Minimum.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Minimum.Image = global::BanVeMayBay.Properties.Resources.minus;
            this.btn_Minimum.ImageSize = new System.Drawing.Size(10, 10);
            this.btn_Minimum.Location = new System.Drawing.Point(740, 12);
            this.btn_Minimum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Minimum.Name = "btn_Minimum";
            this.btn_Minimum.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_Minimum.Size = new System.Drawing.Size(23, 21);
            this.btn_Minimum.TabIndex = 2;
            this.btn_Minimum.Click += new System.EventHandler(this.btn_Minimum_Click);
            // 
            // pnl_ResetPassword
            // 
            this.pnl_ResetPassword.BackColor = System.Drawing.Color.Transparent;
            this.pnl_ResetPassword.BorderRadius = 15;
            this.pnl_ResetPassword.Controls.Add(this.lb_TitleResetPass);
            this.pnl_ResetPassword.Controls.Add(this.btn_ExitReset);
            this.pnl_ResetPassword.Controls.Add(this.txt_RetypePassword);
            this.pnl_ResetPassword.Controls.Add(this.btn_SetPassword);
            this.pnl_ResetPassword.Controls.Add(this.txt_NewPassword);
            this.pnl_ResetPassword.Controls.Add(this.txt_UserSetPass);
            this.pnl_ResetPassword.CustomBorderColor = System.Drawing.Color.Black;
            this.pnl_ResetPassword.FillColor = System.Drawing.Color.SteelBlue;
            this.pnl_ResetPassword.ForeColor = System.Drawing.Color.Transparent;
            this.pnl_ResetPassword.Location = new System.Drawing.Point(412, 43);
            this.pnl_ResetPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_ResetPassword.Name = "pnl_ResetPassword";
            this.pnl_ResetPassword.Size = new System.Drawing.Size(365, 319);
            this.pnl_ResetPassword.TabIndex = 3;
            this.pnl_ResetPassword.Visible = false;
            // 
            // lb_TitleResetPass
            // 
            this.lb_TitleResetPass.AutoSize = true;
            this.lb_TitleResetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TitleResetPass.ForeColor = System.Drawing.Color.Black;
            this.lb_TitleResetPass.Location = new System.Drawing.Point(72, 37);
            this.lb_TitleResetPass.Name = "lb_TitleResetPass";
            this.lb_TitleResetPass.Size = new System.Drawing.Size(215, 25);
            this.lb_TitleResetPass.TabIndex = 7;
            this.lb_TitleResetPass.Text = "RESET PASSWORD";
            // 
            // btn_ExitReset
            // 
            this.btn_ExitReset.BackColor = System.Drawing.Color.Transparent;
            this.btn_ExitReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ExitReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ExitReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ExitReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ExitReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ExitReset.FillColor = System.Drawing.Color.Silver;
            this.btn_ExitReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_ExitReset.ForeColor = System.Drawing.Color.Transparent;
            this.btn_ExitReset.Image = global::BanVeMayBay.Properties.Resources.cross;
            this.btn_ExitReset.ImageSize = new System.Drawing.Size(10, 10);
            this.btn_ExitReset.Location = new System.Drawing.Point(329, 12);
            this.btn_ExitReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ExitReset.Name = "btn_ExitReset";
            this.btn_ExitReset.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_ExitReset.Size = new System.Drawing.Size(23, 21);
            this.btn_ExitReset.TabIndex = 6;
            this.btn_ExitReset.Click += new System.EventHandler(this.btn_ExitReset_Click);
            // 
            // txt_RetypePassword
            // 
            this.txt_RetypePassword.BackColor = System.Drawing.Color.Transparent;
            this.txt_RetypePassword.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.txt_RetypePassword.BorderRadius = 15;
            this.txt_RetypePassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_RetypePassword.DefaultText = "";
            this.txt_RetypePassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_RetypePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_RetypePassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_RetypePassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_RetypePassword.FillColor = System.Drawing.Color.Black;
            this.txt_RetypePassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_RetypePassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_RetypePassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_RetypePassword.Location = new System.Drawing.Point(69, 197);
            this.txt_RetypePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_RetypePassword.Name = "txt_RetypePassword";
            this.txt_RetypePassword.PasswordChar = '*';
            this.txt_RetypePassword.PlaceholderText = "Retype Your Password";
            this.txt_RetypePassword.SelectedText = "";
            this.txt_RetypePassword.Size = new System.Drawing.Size(227, 37);
            this.txt_RetypePassword.TabIndex = 3;
            // 
            // btn_SetPassword
            // 
            this.btn_SetPassword.BorderRadius = 15;
            this.btn_SetPassword.BorderThickness = 2;
            this.btn_SetPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_SetPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_SetPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_SetPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_SetPassword.FillColor = System.Drawing.Color.Silver;
            this.btn_SetPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn_SetPassword.ForeColor = System.Drawing.Color.Black;
            this.btn_SetPassword.Location = new System.Drawing.Point(103, 261);
            this.btn_SetPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SetPassword.Name = "btn_SetPassword";
            this.btn_SetPassword.Size = new System.Drawing.Size(160, 36);
            this.btn_SetPassword.TabIndex = 2;
            this.btn_SetPassword.Text = "Reset";
            // 
            // txt_NewPassword
            // 
            this.txt_NewPassword.BackColor = System.Drawing.Color.Transparent;
            this.txt_NewPassword.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.txt_NewPassword.BorderRadius = 15;
            this.txt_NewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_NewPassword.DefaultText = "";
            this.txt_NewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_NewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_NewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_NewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_NewPassword.FillColor = System.Drawing.Color.Black;
            this.txt_NewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_NewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_NewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_NewPassword.Location = new System.Drawing.Point(69, 142);
            this.txt_NewPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_NewPassword.Name = "txt_NewPassword";
            this.txt_NewPassword.PasswordChar = '*';
            this.txt_NewPassword.PlaceholderText = "Enter New Password";
            this.txt_NewPassword.SelectedText = "";
            this.txt_NewPassword.Size = new System.Drawing.Size(227, 37);
            this.txt_NewPassword.TabIndex = 1;
            // 
            // txt_UserSetPass
            // 
            this.txt_UserSetPass.BackColor = System.Drawing.Color.Transparent;
            this.txt_UserSetPass.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.txt_UserSetPass.BorderRadius = 15;
            this.txt_UserSetPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_UserSetPass.DefaultText = "";
            this.txt_UserSetPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_UserSetPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_UserSetPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_UserSetPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_UserSetPass.FillColor = System.Drawing.Color.Black;
            this.txt_UserSetPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_UserSetPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_UserSetPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_UserSetPass.Location = new System.Drawing.Point(69, 86);
            this.txt_UserSetPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_UserSetPass.Name = "txt_UserSetPass";
            this.txt_UserSetPass.PasswordChar = '\0';
            this.txt_UserSetPass.PlaceholderText = "Enter Your Username";
            this.txt_UserSetPass.SelectedText = "";
            this.txt_UserSetPass.Size = new System.Drawing.Size(227, 37);
            this.txt_UserSetPass.TabIndex = 0;
            // 
            // frm_DangNhap
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImage = global::BanVeMayBay.Properties.Resources.z4831303870118_e4a4eb093c3853d048eb86470693eda6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btn_Exit;
            this.ClientSize = new System.Drawing.Size(813, 398);
            this.Controls.Add(this.pnl_ResetPassword);
            this.Controls.Add(this.btn_Minimum);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.pnl_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DangNhap";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_DangNhap_Load);
            this.pnl_Login.ResumeLayout(false);
            this.pnl_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.pnl_ResetPassword.ResumeLayout(false);
            this.pnl_ResetPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm BorderlessFrm;
        private Guna.UI2.WinForms.Guna2CircleButton btn_Exit;
        private Guna.UI2.WinForms.Guna2CircleButton btn_Minimum;
        private Guna.UI2.WinForms.Guna2Panel pnl_Login;
        private Guna.UI2.WinForms.Guna2Button btn_Login;
        private Guna.UI2.WinForms.Guna2TextBox txt_Password;
        private Guna.UI2.WinForms.Guna2TextBox txt_Username;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.LinkLabel link_Forget;
        private Guna.UI2.WinForms.Guna2Panel pnl_ResetPassword;
        private Guna.UI2.WinForms.Guna2TextBox txt_RetypePassword;
        private Guna.UI2.WinForms.Guna2Button btn_SetPassword;
        private Guna.UI2.WinForms.Guna2TextBox txt_NewPassword;
        private Guna.UI2.WinForms.Guna2TextBox txt_UserSetPass;
        private Guna.UI2.WinForms.Guna2CircleButton btn_ExitReset;
        private System.Windows.Forms.Label lb_TitleResetPass;
    }
}

