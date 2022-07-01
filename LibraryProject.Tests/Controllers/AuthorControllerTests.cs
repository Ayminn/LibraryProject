using LibraryProject.Api.Controllers;
using LibraryProject.Api.DTOs;
using LibraryProject.Api.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Collections.Generic;
using Xunit;
using System;

namespace LibraryProject.Tests.Controllers
{
    public class AuthorControllerTests
    {
        private readonly AuthorController _authorController;
        private readonly Mock<IAuthorService> _mockAuthorService = new();

        public AuthorControllerTests()
        {
            _authorController = new(_mockAuthorService.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenAuthorsExist()
        {
            // Arrange
            List<AuthorResponse> authors = new();
            authors.Add(new()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                MiddleName = "Test",
                BirthYear = 2022,
                YearOfDeath = 2222
            });
            authors.Add(new()
            {
                Id = 2,
                FirstName = "Test2",
                LastName = "Test2",
                MiddleName = "Test2",
                BirthYear = 2022,
                YearOfDeath = 2222
            });

            _mockAuthorService
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(authors);

            // Act
            var result = await _authorController.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoAuthorsExist()
        {
            // Arrange
            List<AuthorResponse> authors = new();

            _mockAuthorService
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(authors);

            // Act
            var result = await _authorController.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            _mockAuthorService
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(() => throw new Exception("This is an exception"));

            // Act
            var result = await _authorController.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNULLAuthorsExist()
        {
            List<AuthorResponse> authors = new();

            // Arrange
            _mockAuthorService
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(() => null);

            // Act
            var result = await _authorController.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
