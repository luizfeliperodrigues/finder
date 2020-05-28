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
                    throw new ArgumentNullException();
                }

                string filePath = @"C:\Users\Felipe\Desktop\study\Aditum\restaurant-hours - Populated.csv";

                FinderService finderService = new FinderService();

                List<string> result = finderService.GetOpenedRestaurants(horario, filePath);

                foreach (var restaurant in result)
                {
                    Console.WriteLine(restaurant);
                }

                // Console.WriteLine(result.Count);

            }
            catch(ArgumentNullException error)
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
