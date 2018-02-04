using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mook_LineRect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5);
            g.Clear(Color.AntiqueWhite);
            Point pt1 = new Point(0, 40);
            Point pt2 = new Point(300, 40);
            PointF ptF1 = new PointF(0f, 80f);
            PointF ptF2 = new PointF(300f, 80f);
            g.DrawLine(pen, pt1, pt2);
            g.DrawLine(pen, ptF1, ptF2);
            g.DrawLine(pen, 0, 120, 300, 120);
            g.DrawLine(pen, 0F, 160F, 300F, 160F);
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 5);
            g.Clear(Color.White);
            Rectangle rectC = new Rectangle(50, 50, 50, 50);
            Rectangle rectR = new Rectangle(105, 105, 50, 50);
            g.DrawArc(p, rectC, 0, 360);
            g.DrawRectangle(p, rectR);
        }
    }
}
