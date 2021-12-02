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
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        Random rng = new Random(1234);
        public Form1()
        {

            InitializeComponent();

            string population_csv = @"C:\Temp\nép-teszt.csv";
            string birthProbabilities_csv = @"C:\Temp\születés.csv";
            string deathProbabilities_csv = @"C:\Temp\halál.csv";
            Population =GetPopulation(population_csv);
            BirthProbabilities = GetBirthProbability(birthProbabilities_csv);
            DeathProbabilities = DeathProbability(deathProbabilities_csv);

            dataGridView1.DataSource = Population;


            for (int year = 2005; year <= 2024; year++)
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

    }
}
