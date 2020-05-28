using System.Collections.Generic;

namespace Finder.Application.Services
{
    public interface IFinderService
    {
         List<string> GetOpenedRestaurants(string hora, string csvPath);
    }
}