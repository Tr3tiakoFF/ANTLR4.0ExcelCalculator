
namespace OOPFirstLab.Forms
{
    partial class FormExcel
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.btnColumnDel = new System.Windows.Forms.Button();
            this.btnRowAdd = new System.Windows.Forms.Button();
            this.btnRowDel = new System.Windows.Forms.Button();
            this.btnColumnAdd = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.dataGridView);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 426);
            this.mainPanel.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 42);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(800, 384);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.textBox);
            this.panel1.Controls.Add(this.btnColumnDel);
            this.panel1.Controls.Add(this.btnRowAdd);
            this.panel1.Controls.Add(this.btnRowDel);
            this.panel1.Controls.Add(this.btnColumnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 42);
            this.panel1.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(111, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 35);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox.Location = new System.Drawing.Point(4, 4);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 34);
            this.textBox.TabIndex = 5;
            // 
            // btnColumnDel
            // 
            this.btnColumnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColumnDel.Location = new System.Drawing.Point(509, 3);
            this.btnColumnDel.Name = "btnColumnDel";
            this.btnColumnDel.Size = new System.Drawing.Size(98, 36);
            this.btnColumnDel.TabIndex = 2;
            this.btnColumnDel.Text = "Delete column";
            this.btnColumnDel.UseVisualStyleBackColor = true;
            this.btnColumnDel.Click += new System.EventHandler(this.btnColumnDel_Click);
            // 
            // btnRowAdd
            // 
            this.btnRowAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRowAdd.Location = new System.Drawing.Point(226, 3);
            this.btnRowAdd.Name = "btnRowAdd";
            this.btnRowAdd.Size = new System.Drawing.Size(75, 36);
            this.btnRowAdd.TabIndex = 3;
            this.btnRowAdd.Text = "Add row";
            this.btnRowAdd.UseVisualStyleBackColor = true;
            this.btnRowAdd.Click += new System.EventHandler(this.btnRowAdd_Click);
            // 
            // btnRowDel
            // 
            this.btnRowDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRowDel.Location = new System.Drawing.Point(307, 3);
            this.btnRowDel.Name = "btnRowDel";
            this.btnRowDel.Size = new System.Drawing.Size(75, 36);
            this.btnRowDel.TabIndex = 4;
            this.btnRowDel.Text = "Delete row";
            this.btnRowDel.UseVisualStyleBackColor = true;
            this.btnRowDel.Click += new System.EventHandler(this.btnRowDel_Click);
            // 
            // btnColumnAdd
            // 
            this.btnColumnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColumnAdd.Location = new System.Drawing.Point(410, 3);
            this.btnColumnAdd.Name = "btnColumnAdd";
            this.btnColumnAdd.Size = new System.Drawing.Size(93, 36);
            this.btnColumnAdd.TabIndex = 1;
            this.btnColumnAdd.Text = "Add column";
            this.btnColumnAdd.UseVisualStyleBackColor = true;
            this.btnColumnAdd.Click += new System.EventHandler(this.btnColumnAdd_Click);
            // 
            // FormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "FormExcel";
            this.Text = "FormExcel";
            this.Load += new System.EventHandler(this.FormExcel_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnRowDel;
        private System.Windows.Forms.Button btnColumnAdd;
        private System.Windows.Forms.Button btnColumnDel;
        private System.Windows.Forms.Button btnRowAdd;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button btnApply;
    }
}