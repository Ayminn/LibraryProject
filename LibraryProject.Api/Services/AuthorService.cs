using LibraryProject.Api.Database.Entites;
using LibraryProject.Api.DTOs;
using LibraryProject.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Api.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorResponse>> GetAllAuthors();
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorResponse>> GetAllAuthors()
        {
            List<Author> authors = await _authorRepository.SelectAllAuthors();
            //authors.Add(new()
            //{
            //    Id = 1,
            //    FirstName = "Test",
            //    LastName = "Test",
            //    MiddleName = "Test",
            //    BirthYear = 2022,
            //    YearOfDeath = 2222
            //});
            //authors.Add(new()
            //{
            //    Id = 2,
            //    FirstName = "Test2",
            //    LastName = "Test2",
            //    MiddleName = "Test2",
            //    BirthYear = 2022,
            //    YearOfDeath = 2222
            //});
            //return authors;


            return authors.Select(author => new AuthorResponse
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                MiddleName = author.MiddleName,
                BirthYear = author.BirthYear,
                YearOfDeath = author.YearOfDeath
            }).ToList();
        }
    }
}
