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
            try
            {
                List<Restaurant> restaurants = new List<Restaurant>();
                string lineContent;
                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
                csvConfiguration.HasHeaderRecord = true;
                csvConfiguration.BadDataFound = null;

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
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Arquivo não encontrado.");
            }
            catch(System.Exception)
            {
                throw new Exception("Problema no parse do csv para restaurante.");
            }
        }

        public Restaurant MapToRestaurant(string restaurant)
        {
            try
            {
                string restaurantName = restaurant.Split(';')[0];
            
                string openingHours = restaurant.Split(';')[1];

                string openingTime = openingHours.Split('-')[0];

                string closingTime = openingHours.Split('-')[1];

                return new Restaurant(restaurantName, TimeSpan.Parse(openingTime), TimeSpan.Parse(closingTime));
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Um dos registros do csv está corrompido.");
            }
            catch(System.Exception)
            {
                throw new Exception("Problema em mapear o restaurante.");
            }
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