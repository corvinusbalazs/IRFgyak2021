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
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {

            }
        }
    }
}
