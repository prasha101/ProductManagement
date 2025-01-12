using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductApplication.Controllers;
using ProductApplication.Models;
using ProductApplication.Repositories;
using ProductApplication.Services;

namespace ProdutTest
{
    public class ProductControllerTests
    {
        private Mock<IProductRepository> _mockProductRepository;
        private ProductController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            var mockProductService = new ProductService(_mockProductRepository.Object);
            _controller = new ProductController(mockProductService);
        }
        [Test]
        public void CreateProduct_ReturnsOkResult_WhenProductIsCreated()
        {
            // Arrange
            var newProduct = new Product { Name = "New Product", StockAvailable = 50 };

            // Act
            var result = _controller.CreateProduct(newProduct);

            // Assert
            Assert.IsInstanceOf<OkResult>(result); // Check if result is Ok (200 OK)
            _mockProductRepository.Verify(repo => repo.Add(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public void GetAllProducts_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var mockProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", StockAvailable = 10 },
                new Product { Id = 2, Name = "Product 2", StockAvailable = 20 }
            };
            _mockProductRepository.Setup(repo => repo.GetAll()).Returns(mockProducts);

            // Act
            var result = _controller.GetAllProducts();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(mockProducts, okResult.Value);
        }

        [Test]
        public void GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            _mockProductRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((Product)null);

            // Act
            var result = _controller.GetProductById(1);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetProductById_ReturnsOkResult_WithProduct()
        {
            // Arrange
            var mockProduct = new Product { Id = 1, Name = "Product 1", StockAvailable = 10 };
            _mockProductRepository.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(mockProduct);

            // Act
            var result = _controller.GetProductById(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(mockProduct, okResult.Value);
        }
    }
}



