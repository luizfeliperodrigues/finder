using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Finder.Application.Services;

namespace Finder.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                Console.Write("Digite a hora que deseja saber? ");
                string time = Console.ReadLine();

                Console.Write("Digite o caminho do arquivo CSV? ");
                string filePath = Console.ReadLine();

                Regex timePattern = new Regex(@"^([0-2][0-3]|[0-1][0-9]):[0-5][0-9]+$");
                Match match = timePattern.Match(time);

                if(!File.Exists(filePath))
                    throw new FileNotFoundException("Arquivo não encontrado ou caminho invalido.");
                
                if(String.IsNullOrEmpty(time) || String.IsNullOrWhiteSpace(time) || !match.Success)
                    throw new ArgumentException("Horario inserido invalido.");

                IFinderService finderService = new FinderService();

                List<string> avaiableRestaurantNames = finderService.GetAvailableRestaurants(time, filePath);

                Console.WriteLine("[{0}]", String.Join(", ", avaiableRestaurantNames.ToArray()));
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
