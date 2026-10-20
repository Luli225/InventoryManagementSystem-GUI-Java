// In Program.cs
using DailyExpenseTracker.Forms;
using DailyExpenseTracker.Models; // For User model
using System;
using System.Windows.Forms;

namespace DailyExpenseTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            User loggedInUser = null;

            // Show Login Form
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login was successful, get the logged-in user
                    loggedInUser = loginForm.LoggedInUser;
                }
                else
                {
                    // Login failed or was cancelled, exit the application
                    Application.Exit();
                    return; // Important to return here
                }
            }

            // If login was successful, proceed to MainForm
            if (loggedInUser != null)
            {
                // Pass the loggedInUser to MainForm (MainForm will need a constructor to accept it)
                Application.Run(new MainForm(loggedInUser));
            }
            // else // This case is handled by Application.Exit() above
            // {
            //    Application.Exit();
            // }
        }
    }
}