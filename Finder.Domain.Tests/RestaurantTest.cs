using System;
using Finder.Application.Domain.Entities;
using Xunit;

namespace Finder.Domain.Tests
{
    public class RestaurantTest
    {
        [Fact]
        public void Should_Return_Restaurant_Is_Opened()
        {
            var restaurant = new Restaurant(
                "Restaurante Teste",
                new TimeSpan(10,0,0),
                new TimeSpan(22,0,0)
            );

            var time = new TimeSpan(15,0,0);
            
            var result = restaurant.IsOpen(time);

            Assert.True(result, "Restaurant is opened.");
        }

        [Fact]
        public void Should_Return_Restaurant_Is_Closed()
        {
            var restaurant = new Restaurant(
                "Restaurante Teste",
                new TimeSpan(10,0,0),
                new TimeSpan(22,0,0)
            );

            var time = new TimeSpan(8,0,0);
            
            var result = restaurant.IsOpen(time);

            Assert.False(result, "Restaurant is closed.");
        }
    }
}