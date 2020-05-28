using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Finder.Application.Services;

namespace Finder.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                Regex timePattern = new Regex(@"^([0-2][0-3]|[0-1][0-9]):[0-5][0-9]+$") ;

                Console.Write("Digite a hora que deseja saber? ");
                string time = Console.ReadLine();

                Match match = timePattern.Match(time);

                if(String.IsNullOrEmpty(time) || String.IsNullOrWhiteSpace(time) || !match.Success)
                {
                    throw new ArgumentException("Horario inserido invalido.");
                }

                string filePath = @"C:\Users\Felipe\Desktop\study\Aditum\restaurant-hours-erroRestaurante.csv";

                IFinderService finderService = new FinderService();

                List<string> openedRestaurantNames = finderService.GetOpenedRestaurants(time, filePath);

                Console.WriteLine("[{0}]", String.Join(", ", openedRestaurantNames.ToArray()));
            }
            catch(ArgumentException error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
            catch (System.Exception error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
        }
    }
}
