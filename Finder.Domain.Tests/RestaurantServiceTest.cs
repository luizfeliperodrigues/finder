using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using Finder.Application.Domain.Services;
using Finder.Application.Domain.Entities;

namespace Finder.Domain.Tests
{
    public class RestaurantServiceTest
    {
        private readonly RestaurantService restaurantService;

        public RestaurantServiceTest()
        {
            this.restaurantService = new RestaurantService();
        }

        [Fact]
        public void Should_Return_An_Empty_List()
        {
            List<Restaurant> restaurants = new List<Restaurant>
            {
                new Restaurant( 
                    "Restaurante 1",
                    new TimeSpan(9,0,0),
                    new TimeSpan(18,0,0)
                ),
                new Restaurant( 
                    "Restaurante 2",
                    new TimeSpan(11,0,0),
                    new TimeSpan(22,0,0)
                ),
                new Restaurant( 
                    "Restaurante 3",
                    new TimeSpan(7,0,0),
                    new TimeSpan(15,0,0)
                ),
                new Restaurant( 
                    "Restaurante 4",
                    new TimeSpan(14,0,0),
                    new TimeSpan(23,0,0)
                ),
                new Restaurant( 
                    "Restaurante 5",
                    new TimeSpan(10,0,0),
                    new TimeSpan(22,0,0)
                ),
            };

            TimeSpan timeTest = new TimeSpan(6,0,0);

            var result = this.restaurantService.GetAvailableRestaurants(timeTest, restaurants);

            Assert.Empty(result);
        }

        [Fact]
        public void Should_Return_The_Correct_List_Size()
        {
            List<Restaurant> restaurantsTested = new List<Restaurant>
            {
                new Restaurant( 
                    "Restaurante 1",
                    new TimeSpan(9,0,0),
                    new TimeSpan(18,0,0)
                ),
                new Restaurant( 
                    "Restaurante 2",
                    new TimeSpan(11,0,0),
                    new TimeSpan(22,0,0)
                ),
                new Restaurant( 
                    "Restaurante 3",
                    new TimeSpan(7,0,0),
                    new TimeSpan(15,0,0)
                ),
                new Restaurant( 
                    "Restaurante 4",
                    new TimeSpan(14,0,0),
                    new TimeSpan(23,0,0)
                ),
                new Restaurant( 
                    "Restaurante 5",
                    new TimeSpan(10,0,0),
                    new TimeSpan(22,0,0)
                )
            };

            TimeSpan timeTest = new TimeSpan(12,0,0);

            var actual = this.restaurantService.GetAvailableRestaurants(timeTest, restaurantsTested);

            Assert.Equal(4, actual.Count);
        }

        [Fact]
        public void Should_Return_An_Expected_List_Of_Restaurants()
        {
            List<Restaurant> restaurantsTested = new List<Restaurant>
            {
                new Restaurant( 
                    "Restaurante 1",
                    new TimeSpan(9,0,0),
                    new TimeSpan(18,0,0)
                ),
                new Restaurant( 
                    "Restaurante 2",
                    new TimeSpan(11,0,0),
                    new TimeSpan(22,0,0)
                ),
                new Restaurant( 
                    "Restaurante 3",
                    new TimeSpan(7,0,0),
                    new TimeSpan(15,0,0)
                ),
                new Restaurant( 
                    "Restaurante 4",
                    new TimeSpan(14,0,0),
                    new TimeSpan(23,0,0)
                ),
                new Restaurant( 
                    "Restaurante 5",
                    new TimeSpan(10,0,0),
                    new TimeSpan(22,0,0)
                )
            };

            List<Restaurant> expected = new List<Restaurant>
            {
                new Restaurant( 
                    "Restaurante 1",
                    new TimeSpan(9,0,0),
                    new TimeSpan(18,0,0)
                ),
                new Restaurant( 
                    "Restaurante 2",
                    new TimeSpan(11,0,0),
                    new TimeSpan(22,0,0)
                ),
                new Restaurant( 
                    "Restaurante 3",
                    new TimeSpan(7,0,0),
                    new TimeSpan(15,0,0)
                ),
                new Restaurant( 
                    "Restaurante 5",
                    new TimeSpan(10,0,0),
                    new TimeSpan(22,0,0)
                )
            };

            TimeSpan timeTest = new TimeSpan(11,30,0);

            var actual = this.restaurantService.GetAvailableRestaurants(timeTest, restaurantsTested);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}