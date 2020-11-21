using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace Mandelbrot_2
{
    public class Mandelbrot
    {       
        private double increment;
        private double startValueX;
        private double startValueY;
        private int limit;
        private int[,] pointMap = new int[800, 800];
        private double calcArea;
        private int canvasSize;
        private double centerX;
        private double centerY;

        #region GettersAndSetters

        public Mandelbrot(double startX, double startY, int nMax, int canvSize, double area)
        {
            startValueX = startX;
            startValueY = startY;
            limit = nMax;
            centerX = 0.0;
            centerY = 0.0;
            canvasSize = canvSize;
            calcArea = area;
        }

        public double Increment
        {
            get { return increment; }
            set { increment = value; }
        }

        public double StartValueX
        {
            get { return startValueX; }
            set { startValueX = value; }
        }

        public double StartValueY
        {
            get { return startValueY; }
            set { startValueY = value; }
        }

        public int Limit
        {
            get { return limit; }
            set { limit = value; }
        }
        #endregion 

        public void reCenter(Point point, double zoomFactor)
        {
            centerX = startValueX + (double)point.X / canvasSize * calcArea;
            centerY = startValueY + (double)point.Y / canvasSize * calcArea;
            if (Math.Abs(zoomFactor) < 0.00001)
            {
                zoomFactor = 1.0;
            }
            calcArea = calcArea / zoomFactor;
            startValueX = centerX - calcArea / 2.0;
            startValueY = centerY - calcArea / 2.0;
            limit = (int) (limit * 1.1);
        }

        public void Iterate(int [,] pointMap)
        {
            Parallel.For(0, pointMap.GetLength(0), new ParallelOptions { MaxDegreeOfParallelism = 13 }, i =>
            {
                double tx = startValueX + i * increment;

                for (int j = 0; j < pointMap.GetLength(1); j++)
                {
                    double ty = startValueY + j * increment;
                    Complex c = new Complex(tx, ty);
                    Complex z = new Complex(0.0, 0.0);
                    int n = 0;
                    bool cont = true;
                    int matchLimit = 20;
                    Complex[] previous = new Complex[matchLimit];             

                    while (Complex.Abs(z) < 2.0 && n < limit && cont)
                    {
                        Complex z1 = Complex.Pow(z, 2.0) + c;
                        n++;
                        if (n > 20)
                        {
                            previous[n % matchLimit] = z;
                            
                            if (Array.IndexOf(previous, z1) >= 0)
                            {
                                cont = false;
                            }
                        }
                        z = z1;
                    }

                    pointMap[i, j] = cont ? n : limit;
                }
            });
            
        }

        private Color getColor(int n)
        {
            int m = n % 350;
            int red = 0, green = 0, blue = 0;

            if (m < 50)
            {
                red = 0;
                green = m % 50 * 5;
                blue = 255;
            }
            else if (m < 100)
            {
                red = 0;
                green = 255;
                blue = 255 - (m % 50) * 5;
            }
            else if (m < 150)
            {
                red = (m % 50) * 5;
                green = 255;
                blue = 0;
            }
            else if (m < 200)
            {
                red = 255;
                green = 255 - (m % 50) * 5;
                blue = 0;
            }
            else if (m < 250)
            {
                red = 255;
                green = 0;
                blue = (m % 50) * 5;
            }
            else if (m < 300)
            {
                red = 255 - (m % 50) * 5;
                green = 0;
                blue = 255;
            }
            return Color.FromArgb(red, green, blue);
        }

        public void Draw(Graphics g)
        {
            //Brush brush;
            Pen pen;

            StartValueX = startValueX;
            StartValueY = startValueY;
            Limit = limit;
            Increment = calcArea / canvasSize;

            Console.WriteLine("Starting...");
            Iterate(pointMap);
            Console.WriteLine("Printing...");

            for (int i = 0; i < pointMap.GetLength(0); i++)
            {
                for (int j = 0; j < pointMap.GetLength(0); j++)
                {
                    int n = pointMap[i, j];
                    if (n >= Limit)
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
}

