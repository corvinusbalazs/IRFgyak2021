using SantaFactory.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaFactory.Entities
{
    public class Ball : Toy
    {

        public SolidBrush BallColor { get; private set; }

        public Ball(Color color)
        {
            BallColor = new SolidBrush(color);   
        }
      

        protected override void DrawImage(Graphics g)
        {
            //var ecset = new SolidBrush(Color.Blue);

            g.FillEllipse(BallColor, 0, 0, Width, Height);
        }

       
        
    }
}
