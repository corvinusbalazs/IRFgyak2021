using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week05.Entities;

namespace week05
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticks;
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();
        List<decimal> nyereségekRendezve;
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();
            dataGridView1.DataSource = Ticks;
            CreatePortfolio();
            //NewMethod();

            List<decimal> Nyereségek = new List<decimal>();

            int intervalum = 30;
            DateTime kezdőDátum = (from x in Ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30);


            TimeSpan z = záróDátum - kezdőDátum;


            for (int i = 0; i < z.Days - intervalum; i++)
            {
                DateTime ablakZaro = kezdőDátum.AddDays(i + intervalum);//30 nappal későbbinek kell lennie
                DateTime ablakNyito = kezdőDátum.AddDays(i);


                decimal ny = GetPortfolioValue(ablakZaro)
                           - GetPortfolioValue(ablakNyito);
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            nyereségekRendezve = (from x in Nyereségek
                                  orderby x
                                  select x)
                                       .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString());
        }

        private void NewMethod()
        {
            int elemszam = Portfolio.Count();
            decimal reszvenyekSzama = (from x in Portfolio
                                       select x.Volume).Sum();

            var otp = from x in Ticks
                      where x.Index.Trim().Equals("OTP")
                      select new
                      {
                          x.Index,
                          x.Price


                      };

            Console.WriteLine("OTP DARABSZAM: " + otp.Count().ToString());

            var Top = from o in otp
                      where o.Price > 500
                      select o;
            Console.WriteLine("OTP DARABSZAM nagyobb 7000: " + Top.Count().ToString());

            var topsum = (from t in Top
                          select t.Price).Sum();

            DateTime minDátum = (from x in Ticks select x.TradingDay).Min();
            DateTime maxDátum = (from x in Ticks select x.TradingDay).Max();
            int elteltNapokSzáma = (maxDátum - minDátum).Days;
            Console.WriteLine((elteltNapokSzáma).ToString());

            //g. Össze is lehet kapcsolni dolgokat, ez már bonyolultabb:
            var kapcsolt =
                            from x in Ticks
                            join y in Portfolio
                            on x.Index equals y.Index
                            select new
                            {
                                Index = x.Index,
                                Date = x.TradingDay,
                                Value = x.Price,
                                Volume = y.Volume
                            };
            dataGridView1.DataSource = kapcsolt.ToList();
        }

        private void CreatePortfolio()
        {

            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;

        }
        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in Ticks
                            where item.Index == x.Index.Trim()
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

    }
}
