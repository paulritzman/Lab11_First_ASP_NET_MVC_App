﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace First_ASP_NET_MVC_App.Models
{
    public class PersonsOfTheYear
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public List<PersonsOfTheYear> GetPersons(int begYear, int endYear)
        {
            List<PersonsOfTheYear> people = new List<PersonsOfTheYear>();
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            string[] myFile = File.ReadAllLines(newPath);

            for (int i = 1; i < myFile.Length; i++)
            {
                string[] fields = myFile[i].Split(',');
                people.Add(new PersonsOfTheYear
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    BirthYear = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8]
                });
            }

            List<PersonsOfTheYear> listOfPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            return listOfPeople;
        }
    }
}
