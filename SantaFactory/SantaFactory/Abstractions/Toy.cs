using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaFactory.Abstractions
{
    public class Toy : Label
    {
        public Toy()
        {
            AutoSize = false;
            Width = 50;
            //Height = 50;
            Height = Width;
            Paint += Toy_Paint;
            var BallColor = Color.Blue;

        }

        protected void DrawImage(Graphics g)
        {
            var ecset = new SolidBrush(Color.Blue);

            g.FillEllipse(ecset, 0, 0, Width, Height);
        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }
        public void MoveToy()
        {
            Left += 1;
        }
    }
}
