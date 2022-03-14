using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Api.DTOs;
using LibraryProject.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Api.Controllers
{
    [Route("api/Author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<AuthorResponse> authors = await _authorService.GetAllAuthors();

                if (authors == null)
                {
                    return Problem("Got no data");
                }
                else if (authors.Count == 0)
                {
                    return NoContent();
                }


                return Ok(authors);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
