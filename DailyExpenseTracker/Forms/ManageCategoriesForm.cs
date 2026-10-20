using DailyExpenseTracker.DataAccess;
using DailyExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient; // For SqlException
using System.Windows.Forms;

namespace DailyExpenseTracker.Forms
{
    
    public partial class ManageCategoriesForm : Form
    {
        private readonly CategoryDataAccess _categoryDataAccess;
        private readonly User _currentUser;
        private Category _selectedCategory = null; // To store the currently selected category for editing

        public ManageCategoriesForm(User currentUser)
        {
            InitializeComponent();
            _categoryDataAccess = new CategoryDataAccess();
            _currentUser = currentUser;

            
        }

        
        private void ManageCategoriesForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCategories();
            ClearForm(); // Initial state for buttons and text box
        }

        private void SetupDataGridView()
        {
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.Columns.Clear();

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryID",
                DataPropertyName = "CategoryID",
                HeaderText = "ID",
                Visible = false // Hide the ID column from the user
            });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                DataPropertyName = "CategoryName",
                HeaderText = "Category Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Standard properties
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.ReadOnly = true;
        }

        private void LoadCategories()
        {
            try
            {
                List<Category> categories = _categoryDataAccess.GetCategoriesByUserId(_currentUser.UserID);
                dgvCategories.DataSource = categories; // Bind the list to the DataGridView
                if (dgvCategories.Rows.Count > 0)
                {
                    dgvCategories.ClearSelection(); // Clear any previous selection
                }
                ClearForm(); // Reset form state
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void ClearForm()
        {
            txtCategoryName.Clear();
            _selectedCategory = null;
            dgvCategories.ClearSelection();
            btnAddCategory.Enabled = true;
            btnSaveCategory.Enabled = false;
            btnDeleteCategory.Enabled = false;
            lblCategoryStatus.Text = "";
            txtCategoryName.Focus();
        }

       

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                lblCategoryStatus.Text = "Category name cannot be empty.";
                txtCategoryName.Focus();
                return;
            }

            Category newCategory = new Category
            {
                UserID = _currentUser.UserID,
                CategoryName = categoryName
            };

            try
            {
                int newCategoryId = _categoryDataAccess.AddCategory(newCategory);
                if (newCategoryId > 0)
                {
                    lblCategoryStatus.Text = $"Category '{categoryName}' added successfully.";
                    LoadCategories(); // Refresh the list
                   
                }
                else if (newCategoryId == -1)
                {
                    lblCategoryStatus.Text = $"Category '{categoryName}' already exists.";
                    txtCategoryName.Focus();
                    txtCategoryName.SelectAll();
                }
                else
                {
                    lblCategoryStatus.Text = "Failed to add category.";
                }
            }
            catch (Exception ex)
            {
                lblCategoryStatus.Text = "Error adding category.";
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log ex
            }
        }

       

      

       
        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                _selectedCategory = (Category)dgvCategories.SelectedRows[0].DataBoundItem;
                if (_selectedCategory != null)
                {
                    txtCategoryName.Text = _selectedCategory.CategoryName;
                    btnAddCategory.Enabled = false; // Disable Add when editing
                    btnSaveCategory.Enabled = true;
                    btnDeleteCategory.Enabled = true;
                }
            }
            else
            {

                if (_selectedCategory == null) // Ensure this doesn't conflict with ClearForm
                {
                    txtCategoryName.Clear();
                    btnAddCategory.Enabled = true;
                    btnSaveCategory.Enabled = false;
                    btnDeleteCategory.Enabled = false;
                }
            }
        }

        private void btnSaveCategory_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Save Button Clicked!"); // <<< ADD THIS LINE FIRST
             {
                 if (_selectedCategory == null)
                 {
                     lblCategoryStatus.Text = "No category selected to update.";
                     return; // EXIT POINT: Nothing happens if no category is selected
                 }

                 string newCategoryName = txtCategoryName.Text.Trim();
                 if (string.IsNullOrWhiteSpace(newCategoryName))
                 {
                     lblCategoryStatus.Text = "Category name cannot be empty.";
                     txtCategoryName.Focus();
                     return; // EXIT POINT: Nothing happens if name is empty
                 }

                 if (newCategoryName.Equals(_selectedCategory.CategoryName, StringComparison.OrdinalIgnoreCase))
                 {
                     lblCategoryStatus.Text = "No changes made to the category name.";
                     return; // EXIT POINT: Nothing happens if name is unchanged
                 }

                 Category updatedCategory = new Category
                 {
                     CategoryID = _selectedCategory.CategoryID,
                     UserID = _currentUser.UserID,
                     CategoryName = newCategoryName
                 };

                 try
                 {
                     bool success = _categoryDataAccess.UpdateCategory(updatedCategory);
                     if (success)
                     {
                         lblCategoryStatus.Text = $"Category updated to '{newCategoryName}'.";
                         LoadCategories(); // This should refresh the grid and clear the form
                     }
                     else
                     {
                         // This could mean duplicate name or other DAL failure
                         lblCategoryStatus.Text = $"Failed to update category. The name '{newCategoryName}' might already exist.";
                         txtCategoryName.Focus();
                         txtCategoryName.SelectAll();
                     }
                 }
                 catch (Exception ex)
                 {
                     lblCategoryStatus.Text = "Error updating category.";
                     MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
        }

        private void btnDeleteCategory_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Button Clicked!"); // <<< ADD THIS LINE FIRST
             {
                 if (_selectedCategory == null)
                 {
                     lblCategoryStatus.Text = "No category selected to delete.";
                     return; // EXIT POINT: Nothing happens if no category selected
                 }

                 var confirmResult = MessageBox.Show($"Are you sure you want to delete '{_selectedCategory.CategoryName}'?",
                                          "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                 if (confirmResult == DialogResult.Yes) // Only proceed if user confirms
                 {
                     try
                     {
                         // _categoryDataAccess.DeleteCategory should return false if category is in use
                         bool success = _categoryDataAccess.DeleteCategory(_selectedCategory.CategoryID, _currentUser.UserID);
                         if (success)
                         {
                             lblCategoryStatus.Text = $"Category '{_selectedCategory.CategoryName}' deleted.";
                             LoadCategories(); // Refresh grid and clear form
                         }
                         else
                         {
                             // DAL returned false, likely because category is in use
                             lblCategoryStatus.Text = $"Cannot delete '{_selectedCategory.CategoryName}'. It is in use by expenses or budgets.";
                             MessageBox.Show($"Cannot delete '{_selectedCategory.CategoryName}'. It is in use. Please re-assign or delete associated items first.", "Deletion Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         }
                     }
                     // ... (catch blocks for SqlException, general Exception as previously discussed) ...
                     catch (Exception ex) // General catch for other errors
                     {
                         lblCategoryStatus.Text = "Error deleting category.";
                         MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
             }
        }

        private void btnClearSelection_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCloseCategories_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCategoryName_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblCategoryStatus.Text))
            {
                lblCategoryStatus.Text = "";
            }
        }
    }
}