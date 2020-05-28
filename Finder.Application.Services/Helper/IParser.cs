using Finder.Application.Domain.Entities;
using System.Collections.Generic;

namespace Finder.Application.Services
{
    public interface IParser
    {
        List<Restaurant> Parse(string filePath);
    }
}