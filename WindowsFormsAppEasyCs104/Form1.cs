using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs104
{
    public partial class Form1 : Form
    {
        private Button bt1, bt2;
        private FlowLayoutPanel flp;
        private Bitmap bmp;
        
        // [STAThread]
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Read And Write Pictures";
            this.Width = 400;
            this.Height = 300;

            bmp = new Bitmap(400, 300);
            
            bt1 = new Button();
            bt2 = new Button();
            bt1.Text = "Read";
            bt2.Text = "Save";

            flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Bottom;

            bt1.Parent = flp;
            bt2.Parent = flp;
            flp.Parent = this;

            bt1.Click += new EventHandler(BtClick);
            bt2.Click += new EventHandler(BtClick);
            this.Paint += new PaintEventHandler(FmPanit);
        }

        public void BtClick(Object sender, EventArgs e)
        {
            if (sender == bt1)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Bitmap File | *.bmp | Jpeg File | *.jpg";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image tmp = (Bitmap)Image.FromFile(ofd.FileName);
                    bmp = new Bitmap(tmp);
                }
            }
            else if (sender == bt2)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Bitmap File | *.bmp | Jpeg File | *.jpg";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FilterIndex == 1)
                    {
                        bmp.Save(sfd.FileName, ImageFormat.Bmp);
                    }
                    else if (sfd.FilterIndex == 2)
                    {
                        bmp.Save(sfd.FileName, ImageFormat.Jpeg);
                    }
                }
            }
            this.Invalidate();
        }

        public void FmPaint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bmp, 0, 0);
        }
    }
}