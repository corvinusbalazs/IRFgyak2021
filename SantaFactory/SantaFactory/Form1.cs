using SantaFactory.Abstractions;
using SantaFactory.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaFactory
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();
       

        private IToyFactory _toyFactory;

        public IToyFactory ToyFactory
        {
            get { return _toyFactory; }
            set { _toyFactory = value; }
        }


        public Form1()
        {
            InitializeComponent();
            ToyFactory = new BallFactory();

            var b = ToyFactory.CreateNew();
            Controls.Add(b);
            
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = (Car)ToyFactory.CreateNew();
            _toys.Add(toy);
            toy.Left = -toy.Width;
            mainPanel.Controls.Add(toy);
            
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var lastPosition=0;
           
            foreach (var item in _toys)
            {
                item.MoveToy();
                if (item.Left>lastPosition)
                {
                    lastPosition = item.Left;
                }
            }
            if (lastPosition>=1000)
            {
                var oldestBall = _toys[0];
                _toys.Remove(oldestBall);
                mainPanel.Controls.Remove(oldestBall);
            }
        }
    }
}
