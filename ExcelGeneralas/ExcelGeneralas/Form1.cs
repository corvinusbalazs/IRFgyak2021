﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System;

namespace ExcelGeneralas

{
    public partial class Form1 : Form
    {

        RealEstateEntities context = new RealEstateEntities();
        List<Flat> lakasok;
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.DataSource = lakasok;
            CreateExcel();


        }
        public void LoadData()
        {

            lakasok = context.Flats.ToList();
        }

        public void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                CreateTable();
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string hiba = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(hiba, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlApp = null;
            }

        }
        private void CreateTable()
        {
            string[] headers = new string[]
            {
            "Kód",
            "Eladó",
               "Oldal",
            "Kerület",
            "Lift",
         "Szobák száma",
         "Alapterület (m2)",
         "Ár (mFt)",
            "Négyzetméter ár (Ft/m2)"

            };
            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i+1] = headers[i];
            }


            object[,] values = new object[lakasok.Count, headers.Length];

            int counter = 0;
            foreach (var lakas in lakasok)
            {
                values[counter, 0] = lakas.Code;
                values[counter, 1] = lakas.Vendor;
                values[counter, 2] = lakas.Side;
                values[counter, 3] = lakas.District;

                if (lakas.Elevator)               
                    values[counter, 4] = "van";                
                else                
                    values[counter, 4] = "nincs";
                
                
                values[counter, 5] = lakas.NumberOfRooms;
                values[counter, 6] = lakas.FloorArea;
                values[counter, 7] = lakas.Price;
                values[counter, 8] = "";
                counter++;
            }

           var range = xlSheet.get_Range(
                GetCell(2, 1),
                GetCell(1 + values.GetLength(0), values.GetLength(1)));
            range.Value2 = values;
        }
        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }
    }
}
