using DrinkReminder.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkReminder
{
    public partial class FrmMain : Form
    {
        private NotifyIcon trayIcon;

        int timeInterval = 1200000;
        
        public FrmMain()
        {
            InitializeComponent();
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.MainIcon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            timerReminder.Interval = timeInterval;
            timerReminder.Enabled = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            timerReminder.Interval = timeInterval;
            timerReminder.Enabled = true;
        }

        private void timerReminder_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
            timerReminder.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
