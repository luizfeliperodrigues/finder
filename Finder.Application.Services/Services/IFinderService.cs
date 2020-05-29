using System.Collections.Generic;

namespace Finder.Application.Services
{
    public interface IFinderService
    {
         List<string> GetAvailableRestaurants(string hora, string csvPath);
    }
}