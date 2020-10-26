using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Mandelbrot_2
{
    public class Iteration
    {       
        private double increment;
        private double startValueX;
        private double startValueY;
        private int limit;
        
        #region GettersAndSetters

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

        public void Start(int [,] pointMap)
        {
            //double tx = startValueX;

            Parallel.For(0, pointMap.GetLength(0), i =>
            //for (int i = 0; i < pointMap.GetLength(0); i++)
            {
                double tx = startValueX + i * increment;
                //double ty = startValueY;

                for (int j = 0; j < pointMap.GetLength(1); j++)
                {
                    double ty = startValueY + j * increment;
                    Complex c = new Complex(tx, ty);
                    Complex z = new Complex(0.0, 0.0);
                    int n = 0;

                    while (Complex.Abs(z) < 2.0 && n < limit)
                    {
                        z = Complex.Pow(z, 2.0) + c;
                        n++;
                    }

                    if (n > 100)
                    {
                        //Console.WriteLine(n);
                    }
                    pointMap[i, j] = n;
                    //Console.WriteLine(z);

                    //ty = ty + increment;
                }
                //tx = tx + increment;
            });
            
        }
    }
}
