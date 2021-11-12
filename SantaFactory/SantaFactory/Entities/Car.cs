using SantaFactory.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaFactory.Entities
{
    class Car : Toy
    {
        protected override void DrawImage(Graphics g)
        {
            var image = Image.FromFile(@"Images\car2.png");
            g.DrawImage(image, 0, 0, Width, Height);
        }

    }
}
