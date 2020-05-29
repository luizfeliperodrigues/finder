using Xunit;
using Finder.Application.Domain.Services;

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
        public void It_Should_Return_False()
        {
            
        }
    }
}