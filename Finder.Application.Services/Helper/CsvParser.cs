using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using System.Threading.Tasks;
using Finder.Application.Domain.Entities;

namespace Finder.Application.Services
{
    public class CsvParser : IParser
    {
        public List<Restaurant> Parse(string filePath)
        {
            if(!File.Exists(filePath))
            {
                throw new FileNotFoundException("Arquivo não encontrado.");
            }

            List<Restaurant> restaurants = new List<Restaurant>();
            string lineContent;
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
            csvConfiguration.HasHeaderRecord = true;

            using (StreamReader fileReader = File.OpenText(filePath))
            {
                using(var csvFile = new CsvReader(fileReader, csvConfiguration))
                {
                    while(csvFile.Read()) 
                    {
                        for(int i=0; csvFile.TryGetField<string>(i, out lineContent); i++)
                        {
                            if (IsHeader(lineContent))
                            {
                                continue;
                            }
                            var restaurant = this.MapToRestaurant(lineContent);
                            restaurants.Add(restaurant);
                        }
                    }
                }
            }

            return restaurants;
        }

        public Restaurant MapToRestaurant(string restaurant)
        {
            string restaurantName = restaurant.Split(';')[0];
            
            string openingHours = restaurant.Split(';')[1];

            string openingTime = openingHours.Split('-')[0];

            string closingTime = openingHours.Split('-')[1];

            return new Restaurant(restaurantName, TimeSpan.Parse(openingTime), TimeSpan.Parse(closingTime));
        }

        public static bool IsHeader(string content)
        {
            if(content.ToLower().Contains("restaurantname") && content.ToLower().Contains("openhours"))
            {
                return true;
            }

            return false;
        }
    }
}