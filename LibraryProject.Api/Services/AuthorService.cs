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
        Task<AuthorResponse> GetAuthorById(int authorId);
        Task<AuthorResponse> CreateAuthor(AuthorRequest newAuthor);
        Task<AuthorResponse> UpdateAuthor(int authorId, AuthorRequest newAuthor);
        Task<AuthorResponse> DeleteAuthor(int authorId);
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

        public async Task<AuthorResponse> GetAuthorById(int authorId)
        {
            Author author = await _authorRepository.SelectAuthorById(authorId);

            if (author != null)
            {
                return new AuthorResponse()
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    BirthYear = author.BirthYear,
                    YearOfDeath = author.YearOfDeath
                };
            }

            return null;
        }

        public async Task<AuthorResponse> CreateAuthor(AuthorRequest newAuthor)
        {
            Author author = new()
            {
                FirstName = newAuthor.FirstName,
                LastName = newAuthor.LastName,
                MiddleName = newAuthor.MiddleName,
                BirthYear = newAuthor.BirthYear,
                YearOfDeath = newAuthor.YearOfDeath
            };

            Author InsertedAuthor = await _authorRepository.InsertNewAuthor(author);

            if (InsertedAuthor != null)
            {
                return new AuthorResponse()
                {
                    Id = InsertedAuthor.Id,
                    FirstName = InsertedAuthor.FirstName,
                    LastName = InsertedAuthor.LastName,
                    BirthYear = InsertedAuthor.BirthYear,
                    YearOfDeath = InsertedAuthor.YearOfDeath
                };
            }

            return null;
        }

        public async Task<AuthorResponse> UpdateAuthor(int authorId, AuthorRequest newAuthor)
        {
            Author author = new()
            {
                FirstName = newAuthor.FirstName,
                LastName = newAuthor.LastName,
                MiddleName = newAuthor.MiddleName,
                BirthYear = newAuthor.BirthYear,
                YearOfDeath = newAuthor.YearOfDeath
            };

            Author UpdatedAuthor = await _authorRepository.UpdateExistingAuthor(authorId, author);

            if (UpdatedAuthor != null)
            {
                return new AuthorResponse()
                {
                    Id = UpdatedAuthor.Id,
                    FirstName = UpdatedAuthor.FirstName,
                    LastName = UpdatedAuthor.LastName,
                    BirthYear = UpdatedAuthor.BirthYear,
                    YearOfDeath = UpdatedAuthor.YearOfDeath
                };
            }

            return null;
        }

        public async Task<AuthorResponse> DeleteAuthor(int authorId)
        {
            Author DeletedAuthor = await _authorRepository.UpdateExistingAuthor(authorId, author);

            if (DeletedAuthor != null)
            {
                return new AuthorResponse()
                {
                    Id = DeletedAuthor.Id,
                    FirstName = DeletedAuthor.FirstName,
                    LastName = DeletedAuthor.LastName,
                    BirthYear = DeletedAuthor.BirthYear,
                    YearOfDeath = DeletedAuthor.YearOfDeath
                };
            }

            return null;
        }
    }
}
