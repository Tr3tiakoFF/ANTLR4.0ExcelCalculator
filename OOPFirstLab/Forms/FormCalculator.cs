using OOPFirstLab.ANTLR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPFirstLab.Forms
{
    public partial class FormCalculator : Form
    {
        public FormCalculator()
        {
            InitializeComponent();
        }

        private void FormCalculator_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            
            lblEvaluateButton.ForeColor = ThemeColor.SecondaryColor;
            lbResult.ForeColor = ThemeColor.SecondaryColor;

            /*
            tbExpression.BackColor = ThemeColor.SecondaryColor;
            tbExpression.ForeColor = Color.White;
            tbExpression.BorderStyle = BorderStyle.None;
            */
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            lbResult.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

            var result = Calculator.Evaluate(tbExpression.Text);

            lbResult.Text = result.ToString();
        }
    }
}