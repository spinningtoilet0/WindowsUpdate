using System;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Drawing;

namespace WindowsUpdate
{
    public partial class UpdateForm : Form
    {
        StringBuilder sb = new StringBuilder();
        public static KeyboardHook kh;

        public UpdateForm()
        {
            kh = new KeyboardHook();
            InitializeComponent();
        }

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
            Shared.EnterFullScreen(this);
            LoadingLogo.Anchor = AnchorStyles.None;
            // this can be changed to be fixed or something, its just code that "supposedly" keeps the loading logo in the center
            LoadingLogo.Location = new Point((Width / 2) - (LoadingLogo.Width / 2), ((Height / 2) - (LoadingLogo.Height / 2)) - 100);
            kh.KeyIntercepted += new KeyboardHook.KeyboardHookEventHandler(kh_KeyIntercepted);
        }

        private void kh_KeyIntercepted(KeyboardHook.KeyboardHookEventArgs e)
        {
            sb.Append(e.KeyName);
            if (sb.ToString().Contains("UpUpDownDownLeftRightLeftRight"))
            {
                kh.KeyIntercepted += new KeyboardHook.KeyboardHookEventHandler(Shared.Nothing);
                UpdateLbl.Text = "Finishing updates\r\nDon\'t turn off your computer";
                System.Timers.Timer t = new System.Timers.Timer();
                t.Interval = Shared.rand.Next(10000, 20000); // In milliseconds
                t.AutoReset = false; // Stops it from repeating
                t.Elapsed += new ElapsedEventHandler(Exit);
                t.Start();
            }
        }

        private void Exit(object sender, ElapsedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UpdateForm_Resize(object sender, EventArgs e)
        {
            LoadingLogo.Anchor = AnchorStyles.None;
            // this is for updates in screen size shouldnt happen tho
            LoadingLogo.Location = new Point((Width / 2) - (LoadingLogo.Width / 2), ((Height / 2) - (LoadingLogo.Height / 2)) - 100);
        }
    }
}
