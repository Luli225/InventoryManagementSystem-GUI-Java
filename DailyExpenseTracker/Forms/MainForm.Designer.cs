using DailyExpenseTracker.Models;
using System;
using System.Windows.Forms;

namespace DailyExpenseTracker
{
    public partial class MainForm : Form
    {
        //private User _currentUser;
        private System.ComponentModel.IContainer components = null;

        

        private void InitializeComponent()
        {
            this.grpAddExpense = new System.Windows.Forms.GroupBox();
            this.btnClearExpenseForm = new System.Windows.Forms.Button();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.txtExpenseDescription = new System.Windows.Forms.TextBox();
            this.dtpExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.txtExpenseAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbExpenseCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpExpenses = new System.Windows.Forms.GroupBox();
            this.btnEditExpense = new System.Windows.Forms.Button();
            this.btnDeleteExpense = new System.Windows.Forms.Button();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.categorysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpAddExpense.SuspendLayout();
            this.grpExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.menuStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAddExpense
            // 
            this.grpAddExpense.Controls.Add(this.btnClearExpenseForm);
            this.grpAddExpense.Controls.Add(this.btnAddExpense);
            this.grpAddExpense.Controls.Add(this.txtExpenseDescription);
            this.grpAddExpense.Controls.Add(this.dtpExpenseDate);
            this.grpAddExpense.Controls.Add(this.txtExpenseAmount);
            this.grpAddExpense.Controls.Add(this.label4);
            this.grpAddExpense.Controls.Add(this.cmbExpenseCategory);
            this.grpAddExpense.Controls.Add(this.label3);
            this.grpAddExpense.Controls.Add(this.label2);
            this.grpAddExpense.Controls.Add(this.label1);
            this.grpAddExpense.Location = new System.Drawing.Point(32, 34);
            this.grpAddExpense.Name = "grpAddExpense";
            this.grpAddExpense.Size = new System.Drawing.Size(407, 256);
            this.grpAddExpense.TabIndex = 0;
            this.grpAddExpense.TabStop = false;
            this.grpAddExpense.Text = "Add New Expense";
            // 
            // btnClearExpenseForm
            // 
            this.btnClearExpenseForm.Location = new System.Drawing.Point(302, 208);
            this.btnClearExpenseForm.Name = "btnClearExpenseForm";
            this.btnClearExpenseForm.Size = new System.Drawing.Size(75, 29);
            this.btnClearExpenseForm.TabIndex = 5;
            this.btnClearExpenseForm.Text = "Clear";
            this.btnClearExpenseForm.UseVisualStyleBackColor = true;
            this.btnClearExpenseForm.Click += new System.EventHandler(this.btnClearExpenseForm_Click);
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.Location = new System.Drawing.Point(30, 208);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(127, 29);
            this.btnAddExpense.TabIndex = 4;
            this.btnAddExpense.Text = "Add Expense";
            this.btnAddExpense.UseVisualStyleBackColor = true;
            this.btnAddExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
            // 
            // txtExpenseDescription
            // 
            this.txtExpenseDescription.Location = new System.Drawing.Point(141, 159);
            this.txtExpenseDescription.Name = "txtExpenseDescription";
            this.txtExpenseDescription.Size = new System.Drawing.Size(200, 26);
            this.txtExpenseDescription.TabIndex = 3;
            // 
            // dtpExpenseDate
            // 
            this.dtpExpenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpenseDate.Location = new System.Drawing.Point(141, 39);
            this.dtpExpenseDate.Name = "dtpExpenseDate";
            this.dtpExpenseDate.Size = new System.Drawing.Size(200, 26);
            this.dtpExpenseDate.TabIndex = 3;
            // 
            // txtExpenseAmount
            // 
            this.txtExpenseAmount.Location = new System.Drawing.Point(141, 119);
            this.txtExpenseAmount.Name = "txtExpenseAmount";
            this.txtExpenseAmount.Size = new System.Drawing.Size(200, 26);
            this.txtExpenseAmount.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Description:";
            // 
            // cmbExpenseCategory
            // 
            this.cmbExpenseCategory.FormattingEnabled = true;
            this.cmbExpenseCategory.Location = new System.Drawing.Point(141, 73);
            this.cmbExpenseCategory.Name = "cmbExpenseCategory";
            this.cmbExpenseCategory.Size = new System.Drawing.Size(200, 28);
            this.cmbExpenseCategory.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date:";
            // 
            // grpExpenses
            // 
            this.grpExpenses.Controls.Add(this.btnEditExpense);
            this.grpExpenses.Controls.Add(this.btnDeleteExpense);
            this.grpExpenses.Controls.Add(this.dgvExpenses);
            this.grpExpenses.Location = new System.Drawing.Point(465, 49);
            this.grpExpenses.Name = "grpExpenses";
            this.grpExpenses.Size = new System.Drawing.Size(407, 511);
            this.grpExpenses.TabIndex = 1;
            this.grpExpenses.TabStop = false;
            this.grpExpenses.Text = "My Expenses";
            // 
            // btnEditExpense
            // 
            this.btnEditExpense.Enabled = false;
            this.btnEditExpense.Location = new System.Drawing.Point(35, 444);
            this.btnEditExpense.Name = "btnEditExpense";
            this.btnEditExpense.Size = new System.Drawing.Size(114, 38);
            this.btnEditExpense.TabIndex = 2;
            this.btnEditExpense.Text = "Edit Selected";
            this.btnEditExpense.UseVisualStyleBackColor = true;
            this.btnEditExpense.Click += new System.EventHandler(this.btnEditExpense_Click_1);
            // 
            // btnDeleteExpense
            // 
            this.btnDeleteExpense.Enabled = false;
            this.btnDeleteExpense.Location = new System.Drawing.Point(240, 444);
            this.btnDeleteExpense.Name = "btnDeleteExpense";
            this.btnDeleteExpense.Size = new System.Drawing.Size(136, 38);
            this.btnDeleteExpense.TabIndex = 3;
            this.btnDeleteExpense.Text = "Delete Selected";
            this.btnDeleteExpense.UseVisualStyleBackColor = true;
            this.btnDeleteExpense.Click += new System.EventHandler(this.btnDeleteExpense_Click_1);
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenses.Location = new System.Drawing.Point(15, 34);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.RowHeadersWidth = 62;
            this.dgvExpenses.RowTemplate.Height = 28;
            this.dgvExpenses.Size = new System.Drawing.Size(361, 373);
            this.dgvExpenses.TabIndex = 0;
            this.dgvExpenses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpenses_CellContentClick);
            this.dgvExpenses.SelectionChanged += new System.EventHandler(this.dgvExpenses_SelectionChanged);
            // 
            // menuStrip4
            // 
            this.menuStrip4.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip4.Location = new System.Drawing.Point(0, 0);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(997, 33);
            this.menuStrip4.TabIndex = 2;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categorysToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 29);
            this.toolStripMenuItem1.Text = "Manage ";
            // 
            // categorysToolStripMenuItem
            // 
            this.categorysToolStripMenuItem.Name = "categorysToolStripMenuItem";
            this.categorysToolStripMenuItem.Size = new System.Drawing.Size(210, 34);
            this.categorysToolStripMenuItem.Text = "Categories...";
            this.categorysToolStripMenuItem.Click += new System.EventHandler(this.categorysToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(997, 718);
            this.Controls.Add(this.grpExpenses);
            this.Controls.Add(this.grpAddExpense);
            this.Controls.Add(this.menuStrip4);
            this.MainMenuStrip = this.menuStrip4;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpAddExpense.ResumeLayout(false);
            this.grpAddExpense.PerformLayout();
            this.grpExpenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private MenuStrip menuStrip3;
        private ToolStripMenuItem manageToolStripMenuItem;
        private ToolStripMenuItem categoriesToolStripMenuItem;

        
        public MainForm()
        {
            InitializeComponent();
           
            if (_currentUser == null && !this.DesignMode)
            {
                
            }
        }

        private GroupBox grpAddExpense;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpExpenseDate;
        private ComboBox cmbExpenseCategory;
        private TextBox txtExpenseAmount;
        private Button btnClearExpenseForm;
        private Button btnAddExpense;
        private TextBox txtExpenseDescription;
        private GroupBox grpExpenses;
        private DataGridView dgvExpenses;
        private Button btnEditExpense;
        private Button btnDeleteExpense;
        private MenuStrip menuStrip4;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem categorysToolStripMenuItem;
    }
}