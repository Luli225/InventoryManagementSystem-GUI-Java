using DailyExpenseTracker.DataAccess; // For UserDataAccess
using DailyExpenseTracker.Models;    // For User model
using System;
using System.Windows.Forms;


namespace DailyExpenseTracker.Forms
{
    
    public partial class RegisterForm : Form
    {
        private UserDataAccess _userDataAccess;
        

        public RegisterForm()
        {
            InitializeComponent();
            _userDataAccess = new UserDataAccess();

            
        }

        private void btnRegisterNew_Click(object sender, EventArgs e)
        {
            string username = txtUsernameReg.Text.Trim();
            string password = txtPasswordReg.Text;
            string confirmPassword = txtConfirmPasswordReg.Text;
            string email = txtEmailReg.Text.Trim();
            string firstName = txtFirstNameReg.Text.Trim();
            string lastName = txtLastNameReg.Text.Trim();

            // --- Validations ---
            if (string.IsNullOrWhiteSpace(username))
            {
                lblStatusReg.Text = "Username is required.";
                txtUsernameReg.Focus();
                return;
            }
            if (username.Length < 3) 
            {
                lblStatusReg.Text = "Username must be at least 3 characters long.";
                txtUsernameReg.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                lblStatusReg.Text = "Password is required.";
                txtPasswordReg.Focus();
                return;
            }
            if (password.Length < 6) 
            {
                lblStatusReg.Text = "Password must be at least 6 characters long.";
                txtPasswordReg.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                lblStatusReg.Text = "Passwords do not match.";
                txtConfirmPasswordReg.Focus();
                txtConfirmPasswordReg.SelectAll();
                return;
            }

            // Optional: Email validation (basic)
            if (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
            {
                lblStatusReg.Text = "Please enter a valid email address.";
                txtEmailReg.Focus();
                return;
            }

            // Check if username already exists
            if (_userDataAccess.UsernameExists(username))
            {
                lblStatusReg.Text = "Username already taken. Please choose another.";
                txtUsernameReg.Focus();
                txtUsernameReg.SelectAll();
                
                return;
            }

            lblStatusReg.Text = "Registering...";

            User newUser = new User
            {
                Username = username,
                Email = string.IsNullOrWhiteSpace(email) ? null : email,
                FirstName = string.IsNullOrWhiteSpace(firstName) ? null : firstName,
                LastName = string.IsNullOrWhiteSpace(lastName) ? null : lastName
                
            };

            int newUserId = _userDataAccess.RegisterUser(newUser, password);

            if (newUserId > 0)
            {
                
                MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (newUserId == -1) 
            {
                lblStatusReg.Text = "Username already taken. Please choose another.";
                txtUsernameReg.Focus();
                txtUsernameReg.SelectAll();
            }
            else
            {
                lblStatusReg.Text = "Registration failed. Please try again.";
                
            }
        }

        private void btnCancelReg_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkShowPasswordReg_CheckedChanged(object sender, EventArgs e)
        {
            
            txtPasswordReg.UseSystemPasswordChar = !chkShowPasswordReg.Checked;
            txtConfirmPasswordReg.UseSystemPasswordChar = !chkShowPasswordReg.Checked;
        }

       
       
        private void ClearStatusLabel()
        {
            if (!string.IsNullOrWhiteSpace(lblStatusReg.Text) && lblStatusReg.Text != "Registering...")
            {
                lblStatusReg.Text = "";
            }
        }

        private void txtPasswordReg_TextChanged_1(object sender, EventArgs e)
        {
            ClearStatusLabel();
        }

        private void txtConfirmPasswordReg_TextChanged_1(object sender, EventArgs e)
        {
            ClearStatusLabel();
        }

        private void txtUsernameReg_TextChanged_1(object sender, EventArgs e)
        {
            ClearStatusLabel();
        }

        private void txtEmailReg_TextChanged_1(object sender, EventArgs e)
        {
            ClearStatusLabel();
        }

        private void txtFirstNameReg_TextChanged(object sender, EventArgs e)
        {
            ClearStatusLabel();
        }

        private void txtLastNameReg_TextChanged(object sender, EventArgs e)
        {
            ClearStatusLabel();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}