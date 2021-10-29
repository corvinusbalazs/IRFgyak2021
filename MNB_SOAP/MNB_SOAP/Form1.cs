using MNB_SOAP.Entities;
using MNB_SOAP.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace MNB_SOAP
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new  BindingList<RateData>();
        public Form1()
        {
            InitializeComponent();
          string result =  WebserviceCall();
            ProcessXML(result);
            
            dataGridView1.DataSource = Rates;
            Charting();
        }

        private void Charting()
        {
            chartRateData.DataSource = Rates;
            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;

            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;
           
            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

        }

        public string WebserviceCall()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody();

            request.currencyNames = "EUR";
            request.startDate = "2020-01-01";
            request.endDate = "2020-06-30";



            //var mnbService = new MNBArfolyamServiceSoapClient();

            //var request = new GetExchangeRatesRequestBody()
            //{
            //    currencyNames = "EUR",
            //    startDate = "2020-01-01",
            //    endDate = "2020-06-30"
            //};
            
            
            var response = mnbService.GetExchangeRates(request);

            string result = response.GetExchangeRatesResult;


            //var result = response.GetExchangeRatesResult;

            File.WriteAllText("export.xml", result);
            return result;         
           
        }

        public void ProcessXML(string result)
        {
            //var xml = new XmlDocument();
            XmlDocument xml = new XmlDocument();

            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                RateData r = new RateData();
                r.Date = DateTime.Parse(element.GetAttribute("date"));
                XmlElement child = (XmlElement)element.FirstChild;
                r.Curreny = child.GetAttribute("curr");
                r.Value = decimal.Parse(child.InnerText);

                var childElement = (XmlElement)element.ChildNodes[0];
                int unit = int.Parse(child.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit!=0)
                {
                    r.Value = value / unit;
                }
                Rates.Add(r);
            }
        }
    }
}
