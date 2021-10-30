
namespace OOPFirstLab.Forms
{
    partial class FormCalculator
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
            this.lblEvaluateButton = new System.Windows.Forms.Label();
            this.tbExpression = new System.Windows.Forms.TextBox();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.lbResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEvaluateButton
            // 
            this.lblEvaluateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEvaluateButton.AutoSize = true;
            this.lblEvaluateButton.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblEvaluateButton.Location = new System.Drawing.Point(164, 178);
            this.lblEvaluateButton.Name = "lblEvaluateButton";
            this.lblEvaluateButton.Size = new System.Drawing.Size(236, 13);
            this.lblEvaluateButton.TabIndex = 1;
            this.lblEvaluateButton.Text = "Put expression to evaluate, and press the button!";
            // 
            // tbExpression
            // 
            this.tbExpression.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbExpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbExpression.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbExpression.Location = new System.Drawing.Point(164, 224);
            this.tbExpression.Name = "tbExpression";
            this.tbExpression.Size = new System.Drawing.Size(310, 34);
            this.tbExpression.TabIndex = 2;
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnEvaluate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEvaluate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvaluate.FlatAppearance.BorderSize = 2;
            this.btnEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEvaluate.Location = new System.Drawing.Point(294, 307);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(196, 46);
            this.btnEvaluate.TabIndex = 3;
            this.btnEvaluate.Text = "EVALUATE";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // lbResult
            // 
            this.lbResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lbResult.Location = new System.Drawing.Point(481, 227);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(170, 28);
            this.lbResult.TabIndex = 4;
            this.lbResult.Text = "Result will be here";
            // 
            // FormCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.btnEvaluate);
            this.Controls.Add(this.tbExpression);
            this.Controls.Add(this.lblEvaluateButton);
            this.Name = "FormCalculator";
            this.Text = "FormCalculator";
            this.Load += new System.EventHandler(this.FormCalculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEvaluateButton;
        private System.Windows.Forms.TextBox tbExpression;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.Label lbResult;
    }
}