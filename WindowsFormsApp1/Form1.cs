using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class HeartPictureBox : PictureBox
        {
            protected override void OnPaint(PaintEventArgs pe)
            {
                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddBezier(this.Width >> 1,
                                    this.Height >> 2,
                                    this.Width * 1.25f, 0f,
                                    this.Width,
                                    this.Height * 0.75f,
                                    this.Width >> 1,
                                    this.Height);
                    path.AddBezier(this.Width >> 1,
                                    this.Height >> 2,
                                    -this.Width * .25f, 0f,
                                    0f,
                                    this.Height * 0.75f,
                                    this.Width >> 1,
                                    this.Height);

                    this.Region = new Region(path);
                }
            }
        }



    }
}
