using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExcelGeneralas
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();

        List<Flat> lakasok;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            
        }
        public void LoadData()
        {
            dataGridView1.DataSource = lakasok;
            lakasok = context.Flats.ToList();
        }
    }
}
