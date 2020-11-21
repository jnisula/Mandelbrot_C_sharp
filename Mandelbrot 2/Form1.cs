using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Mandelbrot m = new Mandelbrot(-2.0, -2.0, 1000, 800, 4.0);

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }          

        private void pbGraph_Paint(object sender, PaintEventArgs e)
        {
            m.Draw(e.Graphics);
        }

        private void pbGraph_MouseClick(object sender, MouseEventArgs e)
        {
            
            Point point = e.Location;
            Console.WriteLine("Picked point: " + e.X);
            m.Limit = int.Parse(txtN.Text);

            m.reCenter(point, double.Parse(txtZoomFactor.Text));
            
            pbGraph.Refresh();
        }

    }           
}
