using System;
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

        // Creates a list of PersonsOfTheYear objects
        public List<PersonsOfTheYear> GetPersons(int begYear, int endYear)
        {
            // Declare the PersonsOfTheYear list
            List<PersonsOfTheYear> people = new List<PersonsOfTheYear>();
            // Store the directory that this method is being called in
            string path = Environment.CurrentDirectory;
            // Combine the previously defined path, with the location on the personOfTheYear.csv file
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            // Create a string array, where each element is a separate line from the personOfTheYear.csv file
            string[] myFile = File.ReadAllLines(newPath);

            // Iterate through the elements in the myFile string array
            for (int i = 1; i < myFile.Length; i++)
            {
                // Create a string array, where each element is a portion of the line from myFile
                // elements are separated where commas occur
                string[] fields = myFile[i].Split(',');
                // Instantiate a new PersonsOfTheYear object, and add it to the people List
                people.Add(new PersonsOfTheYear
                {
                    // Grab the first element from the fields array, and store it in the PersonsOfTheYear.Year property
                    Year = Convert.ToInt32(fields[0]),
                    // Grab the second element from the fields array, and store it in the PersonsOfTheYear.Honor property
                    Honor = fields[1],
                    // Grab the third element from the fields array, and store it in the PersonsOfTheYear.Name property
                    Name = fields[2],
                    // Grab the fourth element from the fields array, and store it in the PersonsOfTheYear.Country property
                    Country = fields[3],
                    // Grab the fifth element from the fields array, and store it in the PersonsOfTheYear.BirthYear property
                    // If no value is provided in this field, store 0 in the property for later conditional handling
                    BirthYear = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    // Grab the sixth element from the fields array, and store it in the PersonsOfTheYear.DeathYear property
                    // If no value is provided in this field, store 0 in the property for later conditional handling
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    // Grab the seventh element from the fields array, and store it in the PersonsOfTheYear.Title property
                    Title = fields[6],
                    // Grab the eighth element from the fields array, and store it in the PersonsOfTheYear.Category property
                    Category = fields[7],
                    // Grab the ninth element from the fields array, and store it in the PersonsOfTheYear.Context property
                    Context = fields[8]
                });
            }

            // Create another PersonsOfTheYear list, using a LAMBDA expression to filter results based on the years input by the user
            List<PersonsOfTheYear> listOfPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            // Return the filtered PersonsOfTheYear list
            return listOfPeople;
        }
    }
}
