namespace DailyExpenseTracker.Forms
{
    public partial class ManageCategoriesForm 
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
            this.grpCategoryList = new System.Windows.Forms.GroupBox();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpAddEditCategory = new System.Windows.Forms.GroupBox();
            this.btnSaveCategory = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.btnCloseCategories = new System.Windows.Forms.Button();
            this.lblCategoryStatus = new System.Windows.Forms.Label();
            this.grpCategoryList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.grpAddEditCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCategoryList
            // 
            this.grpCategoryList.Controls.Add(this.dgvCategories);
            this.grpCategoryList.Location = new System.Drawing.Point(78, 46);
            this.grpCategoryList.Name = "grpCategoryList";
            this.grpCategoryList.Size = new System.Drawing.Size(305, 312);
            this.grpCategoryList.TabIndex = 0;
            this.grpCategoryList.TabStop = false;
            this.grpCategoryList.Text = "My Categories";
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToOrderColumns = true;
            this.dgvCategories.AllowUserToResizeColumns = false;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryID,
            this.CategoryName});
            this.dgvCategories.Location = new System.Drawing.Point(17, 25);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersWidth = 62;
            this.dgvCategories.RowTemplate.Height = 28;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(268, 271);
            this.dgvCategories.TabIndex = 1;
            this.dgvCategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellContentClick);
            // 
            // CategoryID
            // 
            this.CategoryID.HeaderText = "ID";
            this.CategoryID.MinimumWidth = 8;
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.ReadOnly = true;
            this.CategoryID.Visible = false;
            this.CategoryID.Width = 150;
            // 
            // CategoryName
            // 
            this.CategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.MinimumWidth = 8;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.Visible = false;
            // 
            // grpAddEditCategory
            // 
            this.grpAddEditCategory.Controls.Add(this.btnSaveCategory);
            this.grpAddEditCategory.Controls.Add(this.btnAddCategory);
            this.grpAddEditCategory.Controls.Add(this.txtCategoryName);
            this.grpAddEditCategory.Controls.Add(this.lblCategoryName);
            this.grpAddEditCategory.Location = new System.Drawing.Point(78, 398);
            this.grpAddEditCategory.Name = "grpAddEditCategory";
            this.grpAddEditCategory.Size = new System.Drawing.Size(305, 134);
            this.grpAddEditCategory.TabIndex = 2;
            this.grpAddEditCategory.TabStop = false;
            this.grpAddEditCategory.Text = "Add/Edit Category";
            // 
            // btnSaveCategory
            // 
            this.btnSaveCategory.Location = new System.Drawing.Point(169, 85);
            this.btnSaveCategory.Name = "btnSaveCategory";
            this.btnSaveCategory.Size = new System.Drawing.Size(127, 30);
            this.btnSaveCategory.TabIndex = 3;
            this.btnSaveCategory.Text = "Save Changes";
            this.btnSaveCategory.UseVisualStyleBackColor = true;
            this.btnSaveCategory.Click += new System.EventHandler(this.btnSaveCategory_Click_1);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(21, 85);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(83, 30);
            this.btnAddCategory.TabIndex = 2;
            this.btnAddCategory.Text = "Add New";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(156, 29);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(100, 26);
            this.txtCategoryName.TabIndex = 1;
            this.txtCategoryName.TextChanged += new System.EventHandler(this.txtCategoryName_TextChanged_1);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(17, 36);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(123, 20);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Category Name:";
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(78, 566);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(140, 33);
            this.btnDeleteCategory.TabIndex = 3;
            this.btnDeleteCategory.Text = "Delete Selected";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click_1);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(233, 566);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(130, 33);
            this.btnClearSelection.TabIndex = 4;
            this.btnClearSelection.Text = "Clear / New";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click_1);
            // 
            // btnCloseCategories
            // 
            this.btnCloseCategories.Location = new System.Drawing.Point(288, 668);
            this.btnCloseCategories.Name = "btnCloseCategories";
            this.btnCloseCategories.Size = new System.Drawing.Size(75, 37);
            this.btnCloseCategories.TabIndex = 5;
            this.btnCloseCategories.Text = "Close";
            this.btnCloseCategories.UseVisualStyleBackColor = true;
            this.btnCloseCategories.Click += new System.EventHandler(this.btnCloseCategories_Click_1);
            // 
            // lblCategoryStatus
            // 
            this.lblCategoryStatus.AutoSize = true;
            this.lblCategoryStatus.Location = new System.Drawing.Point(46, 640);
            this.lblCategoryStatus.Name = "lblCategoryStatus";
            this.lblCategoryStatus.Size = new System.Drawing.Size(0, 20);
            this.lblCategoryStatus.TabIndex = 6;
            // 
            // ManageCategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 717);
            this.Controls.Add(this.lblCategoryStatus);
            this.Controls.Add(this.btnCloseCategories);
            this.Controls.Add(this.btnClearSelection);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.grpAddEditCategory);
            this.Controls.Add(this.grpCategoryList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ManageCategoriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Categories";
            this.Load += new System.EventHandler(this.ManageCategoriesForm_Load);
            this.grpCategoryList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.grpAddEditCategory.ResumeLayout(false);
            this.grpAddEditCategory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCategoryList;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.GroupBox grpAddEditCategory;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Button btnSaveCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.Button btnCloseCategories;
        private System.Windows.Forms.Label lblCategoryStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
    }
}