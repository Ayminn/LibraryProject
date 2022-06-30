using LibraryProject.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Tests.Service
{
    internal class AuthorServiceTests
    {
        private readonly AuthorService _authorService;
        private readonly Mock<IAuthorService> _mockAuthorRepository = new();

        public AuthorServiceTests()
        {                                              //Which one to pick?
            //_authorService = new AuthorService(_mockAuthorRepository.Object);
        }
    }
}
