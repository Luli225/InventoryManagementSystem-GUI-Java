using DailyExpenseTracker.DataAccess; // For UserDataAccess
using DailyExpenseTracker.Models;    // For User model
using System;
using System.Windows.Forms;

namespace DailyExpenseTracker.Forms
{
    public partial class LoginForm : Form
    {
        private UserDataAccess _userDataAccess;
        public User LoggedInUser { get; private set; } // Property to hold the successfully logged-in user

        public LoginForm()
        {
            InitializeComponent();
            _userDataAccess = new UserDataAccess();
            this.AcceptButton = btnLogin; // Ensure Enter key triggers login
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Basic validation
            if (string.IsNullOrWhiteSpace(username))
            {
                lblStatus.Text = "Username cannot be empty.";
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Password cannot be empty.";
                txtPassword.Focus();
                return;
            }

            lblStatus.Text = "Logging in..."; // Provide feedback

            User user = _userDataAccess.GetUserByUsername(username);

            if (user != null)
            {
                // User found, now verify password
                if (_userDataAccess.VerifyPassword(password, user.Salt, user.PasswordHash))
                {
                    lblStatus.Text = "Login successful!";
                    LoggedInUser = user; // Store the logged-in user
                    this.DialogResult = DialogResult.OK; // Indicate successful login
                    this.Close(); // Close the login form
                }
                else
                {
                    lblStatus.Text = "Invalid username or password.";
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            else
            {
                lblStatus.Text = "Invalid username or password.";
                txtUsername.Focus();
                txtUsername.SelectAll();
            }
        }

        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (RegisterForm registerForm = new RegisterForm())
            {
                DialogResult result = registerForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    lblStatus.Text = "Registration successful! Please log in.";
                    txtPassword.Clear(); // Clear password field
                    
                    txtUsername.Focus(); // Focus username to encourage login
                }
               
            }
        }
        

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        
        

     

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblStatus.Text) && lblStatus.Text != "Logging in...")
            {
                lblStatus.Text = "";
            }
        }

        private void txtUsername_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblStatus.Text) && lblStatus.Text != "Logging in...")
            {
                lblStatus.Text = "";
            }
        }
    }
}