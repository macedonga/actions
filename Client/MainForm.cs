using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Sets link text
            link.Text = "Your link is: " + Data.endpoint + "get?uid=" + Data.UID;
            // Starts the process watcher
            Thread actionThread = new Thread(new ThreadStart(ActionSet.Start));
            actionThread.Start();
        }

        #region Dragging window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

        #region Form stuff
        private void MinimizeWindow(object sender, EventArgs e)
        {
            this.Hide();
            notify.BalloonTipTitle = "The program is still running in the background...";
            notify.BalloonTipText = "To reopen the window click the icon in the system tray.";
            notify.Visible = true;
            notify.ShowBalloonTip(500);
        }

        private void OpenWindow(object sender, MouseEventArgs e)
        {
            this.Show();
            notify.Visible = false;
        }

        private void CopyLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(Data.endpoint + "get?uid=" + Data.UID);
            MessageBox.Show("Copied link to clipboard");
        }

        private void AboutShow(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void ExitWindow(object sender, EventArgs e)
        {
            string message = "Do you want to exit this program?";
            string title = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Requests.Set("idle", "none");
                Application.Exit();
            }
        }

        private void ServStop(object sender, EventArgs e)
        {
            if (ActionSet.isRunning)
            {
                ActionSet.Stop();
                ServStopBTN.Text = "&Start service";
            }
            else
            {
                ActionSet.Start();
                ServStopBTN.Text = "&Stop service";
            }

        }

        private void SetCustomAction(object sender, EventArgs e)
        {
            if (actionIcon.Text != "Action icon" && actionIcon.Text != "")
            {
                if (IsValidImageLink(actionIcon.Text))
                {
                    if (ActionSet.isRunning)
                    {
                        ActionSet.Stop();
                        ServStopBTN.Text = "Start service";
                    }
                    else
                        ActionSet.Stop();
                    Requests.Set(actionText.Text, actionIcon.Text);
                }
            }
            else
            {
                if (ActionSet.isRunning)
                {
                    ActionSet.Stop();
                    ServStopBTN.Text = "Start service";
                }
                else
                    ActionSet.Stop();
                Requests.Set(actionText.Text, "none");
            }
            actionIcon.Text = "Action icon";
            actionText.Text = "Action text";
        }

        private bool IsValidImageLink(string url)
        {
            if (!url.StartsWith("https://cdn.macedon.ga/actions"))
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        if (response.ContentType.Contains("image/png"))
                            return true;
                        else
                        {
                            MessageBox.Show("The action icon has got to be a valid PNG image.\nIf this image has a \".png\" extension, then check if the mime type returned by the server is \"image/png\"");
                            return false;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("The action icon's link you inserted isn't reachable.");
                    return false;
                }
            }
            else
                return true;
        }

        private void RemoveCustomAction(object sender, EventArgs e)
        {
            string message = "Do you want to reset your action?";
            string title = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Requests.Reset();
            }
        }
        #endregion
    }
}