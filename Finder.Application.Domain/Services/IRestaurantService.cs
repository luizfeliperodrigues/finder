using System;
using System.Collections.Generic;
using Finder.Application.Domain.Entities;

namespace Finder.Application.Domain.Services
{
    public interface IRestaurantService
    {
         List<Restaurant> GetAvailableRestaurants(TimeSpan time, List<Restaurant> restaurants);
    }
}