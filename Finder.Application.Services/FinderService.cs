using System;
using System.Collections.Generic;
using System.Linq;
using Finder.Application.Domain;
using Finder.Application.Domain.Entities;
using Finder.Application.Domain.Services;

namespace Finder.Application.Services
{
    public class FinderService : IFinderService
    {
        private readonly IRestaurantService restaurantService;

        public FinderService()
        {
            this.restaurantService = new RestaurantService();
        }

        public List<string> GetOpenedRestaurants(string time, string csvPath)
        {
            CsvService csvService = new CsvService(csvPath);

            List<Restaurant> restaurants = csvService.GetRestaurants();

            List<Restaurant> availableRestaurants = this.restaurantService.GetAvailableRestaurants(TimeSpan.Parse(time), restaurants);

            return availableRestaurants.Select(restaurant => restaurant.Name).ToList();;
        }
    }
}