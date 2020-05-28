using System;
using System.Collections.Generic;
using System.Linq;
using Finder.Application.Domain.Entities;

namespace Finder.Application.Domain.Services
{
    public class RestaurantService : IRestaurantService
    {
        public List<Restaurant> GetAvailableRestaurants(TimeSpan time, List<Restaurant> restaurants)
        {
            return restaurants.Where(restaurant => restaurant.IsOpen(time)).ToList();
        }
    }
}