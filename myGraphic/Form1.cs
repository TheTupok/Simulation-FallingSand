using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myGraphic
{
    public partial class Form1 : Form
    {
        static List<Point> listInactivePoints = new List<Point>();
        static List<Point> listActivePoints = new List<Point>();

        const int borderRect = 3;
        const int horizonLineHeight = 200;

        public Form1()
        {
            InitializeComponent();
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Brush blackBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawLine(blackPen, 0, horizonLineHeight, Size.Width, horizonLineHeight);

            foreach(var item in listActivePoints)
            {
                e.Graphics.FillRectangle(blackBrush, item.X, item.Y, borderRect, borderRect);
            }
            foreach(var item in listInactivePoints)
            {
                e.Graphics.FillRectangle(blackBrush, item.X, item.Y, borderRect, borderRect);
            }
        }

        private void Point_drop()
        {
            for (int i = 0; i < listActivePoints.Count; i++)
            {
                int ActivePointX = listActivePoints[i].X;
                int ActivePointY = listActivePoints[i].Y;

                if (!listInactivePoints.Contains(new Point(ActivePointX, ActivePointY + borderRect)))
                {
                    ActivePointY++;
                    listActivePoints[i] = new Point(ActivePointX, ActivePointY);
                }
                else if (!listInactivePoints.Contains(new Point(ActivePointX - borderRect, ActivePointY + borderRect)))
                {
                    ActivePointX -= borderRect;
                    ActivePointY += borderRect;
                    listActivePoints[i] = new Point(ActivePointX, ActivePointY);
                }
                else if (!listInactivePoints.Contains(new Point(ActivePointX + borderRect, ActivePointY + borderRect)))
                {
                    ActivePointX += borderRect;
                    ActivePointY += borderRect;
                    listActivePoints[i] = new Point(ActivePointX, ActivePointY);
                }
                else
                {
                    listInactivePoints.Add(new Point(ActivePointX, ActivePointY));
                    listActivePoints.Remove(new Point(ActivePointX, ActivePointY));
                }

                if (ActivePointY == horizonLineHeight - borderRect)
                {
                    listInactivePoints.Add(new Point(ActivePointX, ActivePointY));
                    listActivePoints.Remove(new Point(ActivePointX, ActivePointY));
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Point_drop();
            Refresh();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            listActivePoints.Add(new Point(Size.Width / 2, 0));
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            listActivePoints.Add(new Point(Size.Width / 2, 0));
        }
    }
}
