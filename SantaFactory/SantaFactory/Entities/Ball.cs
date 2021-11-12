using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaFactory.Entities
{
    public class Ball : Label
    {
        public Ball()
        {
            AutoSize = false;
            Width = 50;
            //Height = 50;
            Height = Width;
            Paint += Ball_Paint;
            var BallColor = Color.Blue;

        }

        protected void DrawImage(Graphics g)
        {
            var ecset = new SolidBrush(Color.Blue);

            g.FillEllipse(ecset, 0, 0, Width, Height);
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }
        public void MoveBall()
        {
            Left += 1;
        }
    }
}
