using LibraryProject.Api.Controllers;
using LibraryProject.Api.DTOs;
using LibraryProject.Api.Services;
using LibraryProject.Api.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Collections.Generic;
using Xunit;
using System;
using LibraryProject.Api.Database.Entites;

namespace LibraryProject.Tests.Service
{
    public class AuthorServiceTests
    {
        private readonly AuthorService _authorService;
        private readonly Mock<IAuthorService> _mockAuthorRepository = new();

        public AuthorServiceTests()
        {
            _authorService = new AuthorService(_mockAuthorRepository.Object);
        }

        [Fact]
        public async void GetAllAuthors_ShouldReturnListOfAuthorResponses_WhenAuthorsExists()
        {
            // Arrange
            List<Author> authors = new();
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
            
            _mockAuthorRepository
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(() => null);

            // Act
            var result = await _authorService.GetAllAuthors();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<AuthorResponse>>(result);
        }
    }
}
