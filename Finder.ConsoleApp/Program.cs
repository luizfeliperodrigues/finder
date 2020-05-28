using System;
using System.Collections.Generic;
using Finder.Application.Services;

namespace Finder.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                Console.Write("Digite a hora que deseja saber? ");
                string horario = Console.ReadLine();

                if(String.IsNullOrEmpty(horario) || String.IsNullOrWhiteSpace(horario))
                {
                    throw new ArgumentNullException("Horario inserido invalido.");
                }

                string filePath = @"C:\Users\Felipe\Desktop\study\Aditum\restaurant-hours.csv";

                IFinderService finderService = new FinderService();

                List<string> openedRestaurantNames = finderService.GetOpenedRestaurants(horario, filePath);

                Console.WriteLine("[{0}]", String.Join(", ", openedRestaurantNames.ToArray()));
            }
            catch(ArgumentNullException error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
            catch (System.Exception error)
            {
                Console.WriteLine($"Error: {error.StackTrace}");
            }
        }
    }
}
