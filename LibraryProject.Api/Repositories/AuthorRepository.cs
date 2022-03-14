using LibraryProject.Api.Database;
using LibraryProject.Api.Database.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Api.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> SelectAllAuthors();
    }
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryProjectContext _context;

        public AuthorRepository(LibraryProjectContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> SelectAllAuthors()
        {
            return await _context.Author.ToListAsync();
        }
    }
}
