using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Api.DTOs
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int BirthYear { get; set; }
        public int? YearOfDeath { get; set; }

    }
}
