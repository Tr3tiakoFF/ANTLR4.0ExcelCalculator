using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPFirstLab
{
    public partial class MainMenu : Form
    {
        private Button currentButton;
        private Form activeForm;

        public MainMenu()
        {
            InitializeComponent();
            Reset();
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private Color SelectThemeColor(int colorIndex)
        {
            string color = ThemeColor.ColorList[colorIndex];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender, int colorIndex)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();

                    ThemeColor.PrimaryColor = SelectThemeColor(colorIndex);
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(ThemeColor.PrimaryColor, -0.3);

                    currentButton = (Button)btnSender;
                    currentButton.BackColor = ThemeColor.PrimaryColor;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    panelTitleBar.BackColor = ThemeColor.PrimaryColor;
                    panelLogo.BackColor = ThemeColor.SecondaryColor;

                    btnCloseApp.BackColor = ThemeColor.PrimaryColor;
                    btnMaximize.BackColor = ThemeColor.PrimaryColor;
                    btnMinimize.BackColor = ThemeColor.PrimaryColor;

                    btnClose.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach(Control previousButton in panelMenu.Controls)
            {
                if(previousButton.GetType() == typeof(Button))
                {
                    previousButton.BackColor = Color.FromArgb(51, 51, 76);
                    previousButton.ForeColor = Color.Gainsboro;
                    previousButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender, int colorIndex)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender, colorIndex);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCalculator(), sender, 0);
        }

        private void btnExcelIn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormExcel(), sender, 1);
        }

        private void btnExcelOut_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormExcelOut(), sender, 2);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormHelp(), sender, 3);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);

            btnCloseApp.BackColor = Color.FromArgb(0, 150, 136);
            btnMaximize.BackColor = Color.FromArgb(0, 150, 136);
            btnMinimize.BackColor = Color.FromArgb(0, 150, 136);

            currentButton = null;

            btnClose.Visible = false;        
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            } 
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
