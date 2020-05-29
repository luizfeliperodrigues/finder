using System;
using System.Collections.Generic;
using System.Linq;
using Finder.Application.Domain.Entities;
using Finder.Application.Domain.Services;

namespace Finder.Application.Services
{
    public class FinderService : IFinderService
    {
        private readonly IRestaurantService restaurantService;
        private readonly IParser csvParser;

        public FinderService()
        {
            this.restaurantService = new RestaurantService();
            this.csvParser = new CsvParser();
        }

        public List<string> GetAvailableRestaurants(string time, string csvPath)
        {
            List<Restaurant> restaurants = csvParser.Parse(csvPath);

            List<Restaurant> availableRestaurants = this.restaurantService.GetAvailableRestaurants(TimeSpan.Parse(time), restaurants);

            return availableRestaurants.Select(restaurant => restaurant.Name).ToList();
        }
    }
}