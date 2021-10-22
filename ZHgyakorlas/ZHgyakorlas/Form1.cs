﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZHgyakorlas.Folder;

namespace ZHgyakorlas
{
    public partial class Form1 : Form
    {
        List<Ramen> ramens = new List<Ramen>();
        public Form1()
        {
            InitializeComponent();

            LoadData("ramen-ratings.csv");
            dataGridView1.DataSource = ramens.ToList();
        }

        public void LoadData(string csv)
        {

            using (StreamReader sr = new StreamReader(csv, Encoding.Default))
            {

                string[] fejlec = sr.ReadLine().Split(','); //EL IS LEHETNE DOBNI, TESZTELÉS MIATT MENTETTEM KI
                while (!sr.EndOfStream)
                {

                    string[] sor = sr.ReadLine().Split(',');
                    Ramen r = new Ramen();
                    string atalakit = sor[5].Replace(".", ",");
                    r.Rating = double.Parse(atalakit);
                    r.Name = sor[1];
                    r.Style = sor[3];
                    r.Country = sor[4];


                    ramens.Add(r);

                }
            }
        }
        public void Filtering()
        {

            var r = (from k in ramens
                     orderby k.Style
                     select k.Style).Distinct();


            listBox1.DataSource = r.ToList();
            listBox1.DisplayMember = "Style";

        }
    }
}
