using System;
using System.Collections.Generic;
using System.IO;
using Finder.Application.Domain.Entities;
using CsvHelper;
using System.Globalization;

namespace Finder.Application.Services
{
    public class CsvService
    {
        public string Path { get; set; }

        public CsvService(string path)
        {
            Path = path;
        }

        public List<string> Content()
        {
            List<string> result = new List<string>();
            string value;

            using (StreamReader fileReader = File.OpenText(Path))
            {
                var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                
                csv.Configuration.HasHeaderRecord = true;
                
                while (csv.Read()) 
                {
                    for(int i=0; csv.TryGetField<string>(i, out value); i++) {
                            result.Add(value);
                        }
                }
            }

            result.RemoveAt(0);

            return result;
        }

        public Restaurant Parse(string restaurant)
        {
            string restaurantName = restaurant.Split(';')[0];
            
            string openingHours = restaurant.Split(';')[1];

            string openingTime = openingHours.Split('-')[0];

            string closingTime = openingHours.Split('-')[1];

            return new Restaurant(restaurantName, TimeSpan.Parse(openingTime), TimeSpan.Parse(closingTime));
        }

        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            foreach (string csvLine in this.Content())
            {
                restaurants.Add(this.Parse(csvLine));
            }

            return restaurants;
        }
    }
}