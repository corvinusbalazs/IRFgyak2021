﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
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
            dataGridView1.DataSource = lakasok;

            
        }
        public void LoadData()
        {
            
            lakasok = context.Flats.ToList();
        }
    }
}
