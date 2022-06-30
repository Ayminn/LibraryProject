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
q    }
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryProjectContext _context;

        public AuthorRepository(LibraryProjectContext context)
        {
            _context = context;
        }

        public async Task<Author> DeleteAuthor(int authorId)
        {
            Author deleteAuthor = await _context.Author
                .FirstOrDefaultAsync(author => author.Id == authorId);

            if (deleteAuthor != null)
            {
                _context.Author.Remove(deleteAuthor);
                await _context.SaveChangesAsync();
            }
            return deleteAuthor;
        }

        public async Task<Author> InsertNewAuthor(Author author)
        {
            _context.Author.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<List<Author>> SelectAllAuthors()
        {
            return await _context.Author.ToListAsync();
        }
    }


}
