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
        static List<Point> listPoints = new List<Point>();
        static int x = 0;
        static int y = 0;

        const int borderRect = 3;
        const int horizonLineHeight = 200;
        

        public Form1()
        {
            InitializeComponent();
            x = Size.Width / 2;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Brush blackBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawLine(blackPen, 0, horizonLineHeight, Size.Width, horizonLineHeight);

            Point point = new Point(x, y);
            e.Graphics.FillRectangle(blackBrush, point.X,point.Y, borderRect, borderRect);

            foreach(var item in listPoints)
            {
                e.Graphics.FillRectangle(blackBrush, item.X, item.Y, borderRect, borderRect);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!listPoints.Contains(new Point(x, y + borderRect))){
                y++;
            } else if(!listPoints.Contains(new Point(x - 3, y + borderRect)))
            {
                y += borderRect;
                x -= borderRect;
            } else if(!listPoints.Contains(new Point(x + 3, y + borderRect)))
            {
                y += borderRect;
                x += borderRect;
            } else
            {
                listPoints.Add(new Point(x, y));
                x = Size.Width / 2;
                y = 0;
            }

            if (y == horizonLineHeight - borderRect)
            {
                listPoints.Add(new Point(x, y));
                x = Size.Width / 2;
                y = 0;
            }
            Refresh();
        }
    }
}
