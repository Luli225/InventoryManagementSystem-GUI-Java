using System;
using DailyExpenseTracker.Forms;
using System.Windows.Forms; // To access ManageCategoriesForm
using DailyExpenseTracker.Models;
using DailyExpenseTracker.DataAccess;
using System.Collections.Generic;
using System.Linq; // To access User (already there for constructor)
namespace DailyExpenseTracker
{
    public partial class MainForm : Form // Or your UI library's form base class
    {
        private User _currentUser; 
        private readonly CategoryDataAccess _categoryDataAccess;
        private readonly ExpenseDataAccess _expenseDataAccess; 
        private List<Category> _userCategories;
        private Expense _selectedExpense = null;
        private bool _isEditingExpense = false;

        public MessageBoxIcon Information { get; private set; }
        public MessageBoxIcon Warning { get; private set; }
        public MessageBoxIcon Error { get; private set; }

        public MainForm(User user) // Your existing constructor
        {
            InitializeComponent();
            _currentUser = user;
            _categoryDataAccess = new CategoryDataAccess();
            _expenseDataAccess = new ExpenseDataAccess(); 

            this.Text = $"Daily Expense Tracker - Welcome, {_currentUser.Username}!";
        }

        
        private void CategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if a user is actually logged in (good practice)
            if (_currentUser != null)
            {
                // Create an instance of ManageCategoriesForm, passing the current user
                using (ManageCategoriesForm categoriesForm = new ManageCategoriesForm(_currentUser))
                {
                    
                    categoriesForm.ShowDialog(this);

                   
                }
            }
            else
            {
                
                MessageBox.Show("Error: No user is currently logged in. Please log out and log in again.",
                                "Authentication Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
               
            }
        }

       

        private void dgvExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
        private void LoadUserCategoriesIntoComboBox()
        {
            try
            {
                
                _userCategories = _categoryDataAccess.GetCategoriesByUserId(_currentUser.UserID);

                
                cmbExpenseCategory.DataSource = null; 

                
                cmbExpenseCategory.DataSource = _userCategories; 

                // Tell the ComboBox which property of the Category object to display to the user
                cmbExpenseCategory.DisplayMember = "CategoryName";

                // Tell the ComboBox which property of the Category object to use as the underlying value
                cmbExpenseCategory.ValueMember = "CategoryID";

               
                if (_userCategories != null && _userCategories.Any())
                {
                    cmbExpenseCategory.SelectedIndex = -1; // Or 0 to select the first item
                }
                else
                {
                    cmbExpenseCategory.DataSource = null; // Ensure it's truly empty if no categories
                    cmbExpenseCategory.Items.Clear(); // Additional clear
                    cmbExpenseCategory.Text = "[No Categories Defined]"; // Optional placeholder
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories into ComboBox: {ex.Message}",
                                "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

       

        private void SetupExpenseDataGridView()
        {
            dgvExpenses.AutoGenerateColumns = false; 
            dgvExpenses.Columns.Clear();           

            // Add columns
            dgvExpenses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ExpenseID",
                DataPropertyName = "ExpenseID",
                HeaderText = "ID",
                Visible = false
            });

            dgvExpenses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ExpenseDate",
                DataPropertyName = "ExpenseDate",
                HeaderText = "Date",
                DefaultCellStyle = { Format = "yyyy-MM-dd" } // Or "d" for short date
            });

            dgvExpenses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                DataPropertyName = "CategoryName",
                HeaderText = "Category"
            });

            dgvExpenses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                DataPropertyName = "Amount",
                HeaderText = "Amount",
                DefaultCellStyle = { Format = "N2" } // N2 for number with 2 decimals. Use C2 for currency.
            });

            dgvExpenses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                DataPropertyName = "Description",
                HeaderText = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Set common DataGridView properties
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.MultiSelect = false;
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;
            dgvExpenses.ReadOnly = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            SetupExpenseDataGridView(); 
            LoadUserExpenses();
            LoadUserCategoriesIntoComboBox();
            ClearExpenseInputFields();      

        }

        private void ClearExpenseInputFields()
        {
            dtpExpenseDate.Value = DateTime.Now;
            if (cmbExpenseCategory.Items.Count > 0)
            {
                cmbExpenseCategory.SelectedIndex = -1;
            }
            txtExpenseAmount.Clear();
            txtExpenseDescription.Clear();

            // Reset edit mode state
            _isEditingExpense = false;
            btnAddExpense.Text = "Add Expense";
            grpAddExpense.Text = "Add New Expense";
            _selectedExpense = null; // Clear any reference to an expense being edited

            dtpExpenseDate.Focus();
        }

        private void btnClearExpenseForm_Click(object sender, EventArgs e)
        {
            ClearExpenseInputFields();      

        }

        

        private void LoadUserExpenses()
        {
            try
            {
                
                List<Expense> userExpenses = _expenseDataAccess.GetExpenses(
                    _currentUser.UserID,
                    null, // No start date filter for now
                    null, // No end date filter for now
                    null  // No category filter for now
                );

                // Bind the list of expenses to the DataGridView
                dgvExpenses.DataSource = null;      
                dgvExpenses.DataSource = userExpenses; 
                                                       
                _selectedExpense = null; // Reset selected expense
                btnEditExpense.Enabled = false;
                btnDeleteExpense.Enabled = false;
                
                if (dgvExpenses.Rows.Count > 0)
                {
                    dgvExpenses.ClearSelection();
                }

                
                btnEditExpense.Enabled = false;
                btnDeleteExpense.Enabled = false;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading expenses: {ex.Message}",
                                "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void categorysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                using (ManageCategoriesForm categoriesForm = new ManageCategoriesForm(_currentUser))
                {
                    categoriesForm.ShowDialog(this);
                   
                    LoadUserCategoriesIntoComboBox(); 
                }
            }
            else
            {
                MessageBox.Show("Error: No user is currently logged in.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            
            if (cmbExpenseCategory.SelectedValue == null || Convert.ToInt32(cmbExpenseCategory.SelectedValue) <= 0)
            {
                MessageBox.Show("Please select a category for the expense.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbExpenseCategory.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtExpenseAmount.Text) ||
                !decimal.TryParse(txtExpenseAmount.Text, out decimal amount) ||
                amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount for the expense.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExpenseAmount.Focus();
                txtExpenseAmount.SelectAll();
                return;
            }

            
            Expense expenseToSave;
            if (_isEditingExpense && _selectedExpense != null)
            {
                expenseToSave = _selectedExpense; // Use the existing object for update
            }
            else
            {
                expenseToSave = new Expense();    // Create a new object for adding
                expenseToSave.UserID = _currentUser.UserID; // UserID is set only for new expenses
            }

            // Populate/Update common properties
            expenseToSave.CategoryID = (int)cmbExpenseCategory.SelectedValue;
            expenseToSave.ExpenseDate = dtpExpenseDate.Value.Date;
            expenseToSave.Amount = amount;
            expenseToSave.Description = txtExpenseDescription.Text.Trim();

            
            try
            {
                bool success = false;
                string successMessage = "";

                if (_isEditingExpense) // If we are in edit mode
                {
                    success = _expenseDataAccess.UpdateExpense(expenseToSave);
                    successMessage = "Expense updated successfully!";
                }
                else // We are in add mode
                {
                    int newExpenseId = _expenseDataAccess.AddExpense(expenseToSave);
                    if (newExpenseId > 0)
                    {
                        success = true;
                    }
                    successMessage = "Expense added successfully!";
                }

                if (success)
                {
                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserExpenses();         
                    ClearExpenseInputFields();  
                }
                else
                {
                    MessageBox.Show($"Failed to {(_isEditingExpense ? "update" : "add")} expense. Please try again.", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvExpenses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count > 0)
            {
                
                _selectedExpense = (Expense)dgvExpenses.SelectedRows[0].DataBoundItem;

                if (_selectedExpense != null)
                {
                    btnEditExpense.Enabled = true;
                    btnDeleteExpense.Enabled = true;
                }
                else
                {
                    // Should not happen if a row is selected and DataBoundItem is correctly populated
                    btnEditExpense.Enabled = false;
                    btnDeleteExpense.Enabled = false;
                }
            }
            else
            {
                // No row is selected (or selection was cleared)
                _selectedExpense = null;
                btnEditExpense.Enabled = false;
                btnDeleteExpense.Enabled = false;
            }
        }

       
      

        private void btnDeleteExpense_Click_1(object sender, EventArgs e)
        {
            if (_selectedExpense == null)
            {
                MessageBox.Show("Please select an expense from the list to delete.", "No Expense Selected", MessageBoxButtons.OK, Information);
                return;
            }

            // Confirm deletion with the user
            DialogResult confirmResult = MessageBox.Show(
                $"Are you sure you want to delete the expense dated '{_selectedExpense.ExpenseDate:yyyy-MM-dd}' for amount '{_selectedExpense.Amount:N2}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    bool success = _expenseDataAccess.DeleteExpense(_selectedExpense.ExpenseID, _currentUser.UserID);

                    if (success)
                    {
                        MessageBox.Show("Expense deleted successfully!", "Success", MessageBoxButtons.OK, Information);
                        LoadUserExpenses();         // Refresh the grid
                        ClearExpenseInputFields();  // Clear form and reset any edit state
                                                    
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete expense. It might have already been deleted or an error occurred.", "Deletion Failed", MessageBoxButtons.OK, Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the expense: {ex.Message}", "Error", MessageBoxButtons.OK, Error);
                }
            }
        }

        private void btnEditExpense_Click_1(object sender, EventArgs e)
        {
            if (_selectedExpense == null)
            {
                MessageBox.Show("Please select an expense from the list to edit.", "No Expense Selected", MessageBoxButtons.OK, Information);
                return;
            }

            // Populate the input form fields with data from the selected expense
            dtpExpenseDate.Value = _selectedExpense.ExpenseDate;

            // Ensure cmbExpenseCategory is populated and select the correct category
            if (cmbExpenseCategory.Items.Count > 0)
            {
                cmbExpenseCategory.SelectedValue = _selectedExpense.CategoryID;
                
                if (cmbExpenseCategory.SelectedValue == null || (int)cmbExpenseCategory.SelectedValue != _selectedExpense.CategoryID)
                {
                    MessageBox.Show("The category for this expense could not be found. Please select a new category.", "Category Missing", MessageBoxButtons.OK, Warning);
                    
                    cmbExpenseCategory.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("No categories available. Please add categories first.", "No Categories", MessageBoxButtons.OK, Warning);
                
            }


            txtExpenseAmount.Text = _selectedExpense.Amount.ToString("F2"); // "F2" for fixed 2 decimal places
            txtExpenseDescription.Text = _selectedExpense.Description;

            // Set UI to "Edit Mode"
            _isEditingExpense = true;
            btnAddExpense.Text = "Save Changes";    // Change the "Add Expense" button text
            grpAddExpense.Text = "Edit Expense";    // Change the GroupBox title
                                                    


        }


        
    }
}