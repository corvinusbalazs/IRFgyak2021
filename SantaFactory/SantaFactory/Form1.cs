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
        Toy _nextToy;

        public IToyFactory ToyFactory
        {
            get { return _toyFactory; }
            set 
                {
                _toyFactory = value;
                DisplayNext();
            }
        }


        public Form1()
        {
            InitializeComponent();
            ToyFactory = new BallFactory();

            
            
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = ToyFactory.CreateNew();
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
            if (lastPosition > 1000)
            {
                var oldestToy = _toys[0];                
                mainPanel.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void SelectCar_Click(object sender, EventArgs e)
        {
            ToyFactory = new CarFactory();
            //toyPanel.Controls.Clear();
            //var valami = ToyFactory.CreateNew();
            //toyPanel.Controls.Add(valami);
        }

        private void SelectBall_Click(object sender, EventArgs e)
        {
            ToyFactory = new BallFactory()
            {
                BallColor = btnColor.BackColor
            };
            //((BallFactory)ToyFactory).BallColor = btnColor.BackColor;
            //toyPanel.Controls.Clear();
            //var valami = ToyFactory.CreateNew();
            //toyPanel.Controls.Add(valami);
        }
        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = ToyFactory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }
        //private void DisplayNext()
        //{

        //    if (_nextToy != null)
        //    {
        //        toyPanel.Controls.Remove(_nextToy);
               
        //        //this.Controls.Remove(_nextToy);
        //        _nextToy = ToyFactory.CreateNew();
        //        toyPanel.Controls.Add(_nextToy);
        //        //_nextToy.Top = this.label1.Top;
        //        //_nextToy.Left = this.label1.Left + this.label1.Top;
        //        //Controls.Add(_nextToy);
        //    }
        
        //}

        private void btnColor_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();

            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorPicker.Color;
        }
    }
}
