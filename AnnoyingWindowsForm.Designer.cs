namespace AnnoyingWindows;
partial class AnnoyingWindowsForm
{
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        e.Cancel = true;
    }
    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            cp.ExStyle |= 0x80;
            return cp;
        }
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        this.FormBorderStyle = FormBorderStyle.None;

    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left)
        {
            this.Capture = false;
            Message msg = Message.Create(this.Handle, 0XA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref msg);
        }
    }
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.TopMost = true;
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ShowInTaskbar = false;
        this.Text = "";
    }

    #endregion
}
