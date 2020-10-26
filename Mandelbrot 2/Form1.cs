using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_2
{           
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Mandelbrot m = new Mandelbrot(-2.0, -2.0, 200);
        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

       public class Mandelbrot
       {
            //private int width, height = 800;
            public int[,] pointMap = new int[800, 800];
            public double startValueX;
            public double startValueY;
            public int limit;
            public double size;
            public int canvasSize;
            public double centerX;
            public double centerY;

            public Mandelbrot(double startX, double startY, int nMax)
            {
                startValueX = startX;
                startValueY = startY;
                limit = nMax;
                centerX = 0.0;
                centerY = 0.0;
                canvasSize = 800;
                size = 4.0;
            }

            private Color getColor(int n)
            {
                int m = n % 150;
                int red = 0, green = 0, blue = 0;

                if (m < 25)
                {
                    red = 0;
                    green = m % 25 * 10;
                    blue = 255;
                }
                else if (m < 50)
                {
                    red = 0;
                    green = 255;
                    blue = 255 - (m % 25) * 10;
                }
                else if (m < 75)
                {
                    red = (m % 25) * 10;
                    green = 255;
                    blue = 0;
                }
                else if (m < 100)
                {
                    red = 255;
                    green = 255 - (m % 25) * 10;
                    blue = 0;
                }
                else if (m < 125)
                {
                    red = 255;
                    green = 0;
                    blue = (m % 25) * 10;
                }
                else if (m < 150)
                {
                    red = 255 - (m % 25) * 10;
                    green = 0;
                    blue = 255;
                }
                return Color.FromArgb(red, green, blue);
            }

            public void Draw(Graphics g)
            {
                //Brush brush;
                Pen pen;
                Iteration mb = new Iteration();
                mb.StartValueX = startValueX;
                mb.StartValueY = startValueY;
                mb.Limit = limit;
                mb.Increment = size / canvasSize;

                Console.WriteLine("Starting...");
                mb.Start(pointMap);
                Console.WriteLine("Printing...");

                for (int i = 0; i < pointMap.GetLength(0); i++)
                {
                    for (int j = 0; j < pointMap.GetLength(0); j++)
                    {
                        int n = pointMap[i, j];
                        if (n >= mb.Limit)
                        {
                            pen = Pens.Black;
                        }
                        else
                        {
                            pen = new Pen(Color.FromArgb(255, getColor(n)));
                        }
                        g.DrawRectangle(pen, i, j, 1, 1);
                    }
                }
                Console.WriteLine("Done!");
            }
        }

    

        private void pbGraph_Paint(object sender, PaintEventArgs e)
        {
            m.Draw(e.Graphics);
        }

        private void pbGraph_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = e.Location;
            Console.WriteLine("Picked point: " + point);
                        
            m.centerX = m.startValueX + (double)point.X / m.canvasSize * m.size;
            m.centerY = m.startValueY + (double)point.Y / m.canvasSize * m.size;
            m.size = m.size / 10.0;
            m.startValueX = m.centerX - m.size / 2.0;
            m.startValueY = m.centerY - m.size / 2.0;
            m.limit *= 2;
            pbGraph.Refresh();
        }
    }           
}
