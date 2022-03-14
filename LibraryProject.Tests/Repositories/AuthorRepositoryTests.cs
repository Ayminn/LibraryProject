using LibraryProject.Api.Database;
using LibraryProject.Api.Database.Entites;
using LibraryProject.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LibraryProject.Tests.Services
{
    public class AuthorRepositoryTests
    {
        private readonly DbContextOptions<LibraryProjectContext> _options;
        private readonly LibraryProjectContext _context;
        private readonly AuthorRepository _authorRepository;

        public AuthorRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryProjectContext>()
                .UseInMemoryDatabase(databaseName: "H3ProjectAuthor")
                .Options;

            _context = new(_options);

            _authorRepository = new(_context);
        }

        [Fact]
        public async void SelectAllAuthors_ShouldReturnListOfAuthors_WhenAuthorsExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            _context.Author.Add(new()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                MiddleName = "Test",
                BirthYear = 2022,
                YearOfDeath = 2222
            });
            _context.Author.Add(new()
            {
                Id = 2,
                FirstName = "Test1",
                LastName = "Test1",
                MiddleName = "Test2",
                BirthYear = 2022,
                YearOfDeath = 2222
            });

            await _context.SaveChangesAsync();


            //Act
            var result = await _authorRepository.SelectAllAuthors();


            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Author>>(result);
            Assert.Equal(2, result.Count);
        }


        [Fact]
        public async void SelectAllAuthors_ShouldReturnEmptyListOfAuthors_WhenNoAuthorsExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _authorRepository.SelectAllAuthors();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Author>>(result);
            Assert.Empty(result);
        }


        [Fact]
        public async void SelectAuthorById_ShouldReturnAuthor_WhenAuthorExists()
        {

            //Arrange
            int authorId = 1;
            await _context.Database.EnsureDeletedAsync();

            _context.Author.Add(new()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                MiddleName = "Test",
                BirthYear = 2022,
                YearOfDeath = 2222
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _authorRepository.SelectAuthorsById(authorId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Author>(result);
            Assert.Equal(authorId, result.Id);
        }
    }
}
