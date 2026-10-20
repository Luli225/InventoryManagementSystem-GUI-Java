namespace DailyExpenseTracker.Forms
{
    partial class RegisterForm
    {
        
        private System.ComponentModel.IContainer components = null;

        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

       
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsernameReg = new System.Windows.Forms.TextBox();
            this.txtPasswordReg = new System.Windows.Forms.TextBox();
            this.txtConfirmPasswordReg = new System.Windows.Forms.TextBox();
            this.txtEmailReg = new System.Windows.Forms.TextBox();
            this.txtFirstNameReg = new System.Windows.Forms.TextBox();
            this.txtLastNameReg = new System.Windows.Forms.TextBox();
            this.btnRegisterNew = new System.Windows.Forms.Button();
            this.btnCancelReg = new System.Windows.Forms.Button();
            this.chkShowPasswordReg = new System.Windows.Forms.CheckBox();
            this.lblStatusReg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register New User";
            // 
            // txtUsernameReg
            // 
            this.txtUsernameReg.Location = new System.Drawing.Point(119, 87);
            this.txtUsernameReg.Name = "txtUsernameReg";
            this.txtUsernameReg.Size = new System.Drawing.Size(219, 26);
            this.txtUsernameReg.TabIndex = 1;
            this.txtUsernameReg.Text = "Username";
            this.txtUsernameReg.TextChanged += new System.EventHandler(this.txtUsernameReg_TextChanged_1);
            // 
            // txtPasswordReg
            // 
            this.txtPasswordReg.Location = new System.Drawing.Point(119, 137);
            this.txtPasswordReg.Name = "txtPasswordReg";
            this.txtPasswordReg.Size = new System.Drawing.Size(219, 26);
            this.txtPasswordReg.TabIndex = 2;
            this.txtPasswordReg.Text = "Password";
            this.txtPasswordReg.UseSystemPasswordChar = true;
            this.txtPasswordReg.TextChanged += new System.EventHandler(this.txtPasswordReg_TextChanged_1);
            // 
            // txtConfirmPasswordReg
            // 
            this.txtConfirmPasswordReg.Location = new System.Drawing.Point(119, 189);
            this.txtConfirmPasswordReg.Name = "txtConfirmPasswordReg";
            this.txtConfirmPasswordReg.Size = new System.Drawing.Size(219, 26);
            this.txtConfirmPasswordReg.TabIndex = 3;
            this.txtConfirmPasswordReg.Text = "Confirm Password";
            this.txtConfirmPasswordReg.UseSystemPasswordChar = true;
            this.txtConfirmPasswordReg.TextChanged += new System.EventHandler(this.txtConfirmPasswordReg_TextChanged_1);
            // 
            // txtEmailReg
            // 
            this.txtEmailReg.Location = new System.Drawing.Point(119, 288);
            this.txtEmailReg.Name = "txtEmailReg";
            this.txtEmailReg.Size = new System.Drawing.Size(219, 26);
            this.txtEmailReg.TabIndex = 4;
            this.txtEmailReg.Text = "Email ";
            this.txtEmailReg.TextChanged += new System.EventHandler(this.txtEmailReg_TextChanged_1);
            // 
            // txtFirstNameReg
            // 
            this.txtFirstNameReg.Location = new System.Drawing.Point(119, 334);
            this.txtFirstNameReg.Name = "txtFirstNameReg";
            this.txtFirstNameReg.Size = new System.Drawing.Size(219, 26);
            this.txtFirstNameReg.TabIndex = 5;
            this.txtFirstNameReg.Text = "First Name (Optional)";
            this.txtFirstNameReg.TextChanged += new System.EventHandler(this.txtFirstNameReg_TextChanged);
            // 
            // txtLastNameReg
            // 
            this.txtLastNameReg.Location = new System.Drawing.Point(119, 378);
            this.txtLastNameReg.Name = "txtLastNameReg";
            this.txtLastNameReg.Size = new System.Drawing.Size(219, 26);
            this.txtLastNameReg.TabIndex = 6;
            this.txtLastNameReg.Text = "Last Name (Optional)";
            this.txtLastNameReg.TextChanged += new System.EventHandler(this.txtLastNameReg_TextChanged);
            // 
            // btnRegisterNew
            // 
            this.btnRegisterNew.Location = new System.Drawing.Point(158, 435);
            this.btnRegisterNew.Name = "btnRegisterNew";
            this.btnRegisterNew.Size = new System.Drawing.Size(93, 29);
            this.btnRegisterNew.TabIndex = 7;
            this.btnRegisterNew.Text = "Register";
            this.btnRegisterNew.UseVisualStyleBackColor = true;
            this.btnRegisterNew.Click += new System.EventHandler(this.btnRegisterNew_Click);
            // 
            // btnCancelReg
            // 
            this.btnCancelReg.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelReg.Location = new System.Drawing.Point(158, 482);
            this.btnCancelReg.Name = "btnCancelReg";
            this.btnCancelReg.Size = new System.Drawing.Size(79, 30);
            this.btnCancelReg.TabIndex = 8;
            this.btnCancelReg.Text = "Cancel";
            this.btnCancelReg.UseVisualStyleBackColor = true;
            this.btnCancelReg.Click += new System.EventHandler(this.btnCancelReg_Click);
            // 
            // chkShowPasswordReg
            // 
            this.chkShowPasswordReg.AutoSize = true;
            this.chkShowPasswordReg.Location = new System.Drawing.Point(158, 238);
            this.chkShowPasswordReg.Name = "chkShowPasswordReg";
            this.chkShowPasswordReg.Size = new System.Drawing.Size(156, 24);
            this.chkShowPasswordReg.TabIndex = 9;
            this.chkShowPasswordReg.Text = "Show Passwords";
            this.chkShowPasswordReg.UseVisualStyleBackColor = true;
            this.chkShowPasswordReg.CheckedChanged += new System.EventHandler(this.chkShowPasswordReg_CheckedChanged);
            // 
            // lblStatusReg
            // 
            this.lblStatusReg.AutoSize = true;
            this.lblStatusReg.Location = new System.Drawing.Point(72, 482);
            this.lblStatusReg.Name = "lblStatusReg";
            this.lblStatusReg.Size = new System.Drawing.Size(0, 20);
            this.lblStatusReg.TabIndex = 10;
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.btnRegisterNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelReg;
            this.ClientSize = new System.Drawing.Size(433, 548);
            this.Controls.Add(this.lblStatusReg);
            this.Controls.Add(this.chkShowPasswordReg);
            this.Controls.Add(this.btnCancelReg);
            this.Controls.Add(this.btnRegisterNew);
            this.Controls.Add(this.txtLastNameReg);
            this.Controls.Add(this.txtFirstNameReg);
            this.Controls.Add(this.txtEmailReg);
            this.Controls.Add(this.txtConfirmPasswordReg);
            this.Controls.Add(this.txtPasswordReg);
            this.Controls.Add(this.txtUsernameReg);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Regiter - Daily Expense Tracker";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsernameReg;
        private System.Windows.Forms.TextBox txtPasswordReg;
        private System.Windows.Forms.TextBox txtConfirmPasswordReg;
        private System.Windows.Forms.TextBox txtEmailReg;
        private System.Windows.Forms.TextBox txtFirstNameReg;
        private System.Windows.Forms.TextBox txtLastNameReg;
        private System.Windows.Forms.Button btnRegisterNew;
        private System.Windows.Forms.Button btnCancelReg;
        private System.Windows.Forms.CheckBox chkShowPasswordReg;
        private System.Windows.Forms.Label lblStatusReg;
    }
}