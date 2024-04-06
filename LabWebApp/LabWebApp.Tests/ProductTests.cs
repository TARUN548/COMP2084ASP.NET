using LabWebApp.Models;
using Xunit;

namespace LabWebApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }




        [Fact]

        public void Product_PropertiesSetCorrectly()

        {

            // Arrange

            var product = new Product

            {

                Id = 1,

                Name = "Test Product",

                Price = 9.99m,

                Description = "Test product description"

            };

            // Act

            // (No action needed for this test.)

            // Assert

            Assert.Equal(1, product.Id);

            Assert.Equal("Test Product", product.Name);

            Assert.Equal(9.99m, product.Price);

            Assert.Equal("Test product description", product.Description);

        }





        [Fact]
        public void Product_PriceWithinRange()
        {
            // Arrange
            var product = new Product
            {
                Id = 2,
                Name = "Another Test Product",
                Price = 19.99m,
                Description = "Another test product description"
            };

            

            // Assert
            Assert.InRange(product.Price, 10m, 20m); 
        }




    }
}