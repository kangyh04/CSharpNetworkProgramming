using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mook_ShapeDraw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
                clsLineRectangle.checkflags = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsLineRectangle im = new clsLineRectangle();
            this.panel1.MouseDown +=
                new MouseEventHandler(im.clsLineRectangle_OnMouseDown);
            this.panel1.MouseMove +=
                new MouseEventHandler(im.clsLineRectangle_OnMouseMove);
            this.panel1.MouseUp +=
                new MouseEventHandler(im.clsLineRectangle_OnMouseUp);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked == true)
                clsLineRectangle.checkflags = false;
        }
    }

    public class clsLineRectangle
    {
        public static bool checkflags = true;
        Rectangle selectRect = new Rectangle();
        Point ps = new Point();
        Point pe = new Point();

        public void clsLineRectangle_OnMouseDown(Object sender, MouseEventArgs e)
        {
            selectRect.Width = 0;
            selectRect.Height = 0;
            selectRect.X = e.X;
            selectRect.Y = e.Y;
            ps.X = e.X;
            ps.Y = e.Y;
            pe = ps;
        }

        public void clsLineRectangle_OnMouseMove(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel paintform = (Panel)sender;
                if (checkflags)
                {
                    ControlPaint.DrawReversibleLine(paintform.PointToScreen(ps),
                        paintform.PointToScreen(pe),
                        Color.Black);

                    pe = new Point(e.X, e.Y);

                    ControlPaint.DrawReversibleLine(paintform.PointToScreen(ps),
                        paintform.PointToScreen(pe), Color.Black);
                }
                else
                {
                    ControlPaint.DrawReversibleFrame(paintform.RectangleToScreen(selectRect),
                        Color.Black, FrameStyle.Dashed);
                    selectRect.Width = e.X - selectRect.X;
                    selectRect.Height = e.Y - selectRect.Y;
                    ControlPaint.DrawReversibleFrame(paintform.RectangleToScreen(selectRect),
                        Color.Black, FrameStyle.Dashed);
                }
            }
        }

        public void clsLineRectangle_OnMouseUp(Object sender, MouseEventArgs e)
        {
            Panel paintform = (Panel)sender;
            Graphics g = paintform.CreateGraphics();
            Pen p = new Pen(Color.Blue, 2);
            if (checkflags)
            {
                ControlPaint.DrawReversibleLine(paintform.PointToScreen(ps),
                    paintform.PointToScreen(pe), Color.Black);
                g.DrawLine(p, ps, pe);
            }
            else
            {
                ControlPaint.DrawReversibleFrame(paintform.RectangleToScreen(selectRect),
                    Color.Black, FrameStyle.Dashed);
                g.DrawRectangle(p, selectRect);
            }
            g.Dispose();
        }
    }
}
