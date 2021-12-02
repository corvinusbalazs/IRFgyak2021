using Mikroszimulácio.Entities;
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

namespace Mikroszimulácio
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<int> Males = new List<int>();
        List<int> Females = new List<int>();

        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        Random rng = new Random(1234);
        public Form1()
        {

            InitializeComponent();
            
            //string BEpopulation_csv = @;
            string TESZTpopulation_csv = @"C:\Temp\nép-teszt.csv";
            string FULLpopulation_csv = @"C:\Temp\nép.csv";
            string birthProbabilities_csv = @"C:\Temp\születés.csv";
            string deathProbabilities_csv = @"C:\Temp\halál.csv";
            //Population = GetPopulation(betextbox);
            BirthProbabilities = GetBirthProbability(birthProbabilities_csv);
            DeathProbabilities = DeathProbability(deathProbabilities_csv);

            //dataGridView1.DataSource = Population;
            richTextBox1.Clear();
            Males.Clear();
            Females.Clear();

        }

        public void Simulation()
        {
            for (int year = 2005; year <= numericUpDown1.Value; year++)
            {

                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();

                Males.Add(nbrOfMales);
                Females.Add(nbrOfFemales);
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
            }
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public List<BirthProbability> GetBirthProbability(string csvpath)
        {
            List<BirthProbability> birthProbability = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthProbability.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        BOdds = double.Parse(line[2])
                    });
                }
            }

            return birthProbability;
        }
        public List<DeathProbability> DeathProbability(string csvpath)
        {
            List<DeathProbability> deathProbability = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathProbability.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        DOdds = double.Parse(line[2])
                    });
                }
            }

            return deathProbability;
        }

        public void SimStep(int year, Person person)
        {
            if (!person.IsAlive) { return; }

            int age = year - person.BirthYear;

            double pD = (from X in DeathProbabilities
                         where X.Gender == person.Gender && X.Age == age
                         select X.DOdds).FirstOrDefault();

            if (rng.NextDouble() <= pD)
                person.IsAlive = false;



            if (person.IsAlive && person.Gender == Gender.Female)
            {

                double pB = (from x in BirthProbabilities
                             where x.Age == age
                             select x.BOdds).FirstOrDefault();

                if (rng.NextDouble() <= pB)
                {
                    Person ujszulott = new Person();
                    ujszulott.BirthYear = year;
                    ujszulott.NbrOfChildren = 0;
                    ujszulott.Gender = (Gender)(rng.Next(1, 3));
                    Population.Add(ujszulott);
                }
            }
        }

       public void DisplayResults()
        {
            

            for (int i = 2005; i <= numericUpDown1.Value; i++)
            {
                richTextBox1.AppendText(String.Format("Szimulációs év : {0} \n\tFiúk : {1} \n\tLányok :{2} \n \n", i, Males[i - 2005], Females[i - 2005]));
            }




        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            string betextbox = @textBox1.Text;
            Population = GetPopulation(betextbox);
            Simulation();
            DisplayResults();
        }

        private void Btn_browse_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            textBox1.Text = fileDialog.FileName;
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < Males.Count; i++)
        //    {
        //        Console.WriteLine(
        //               string.Format("Fiúk:{0}",Males[i] ));
        //    }
            
        //}
    }
}
