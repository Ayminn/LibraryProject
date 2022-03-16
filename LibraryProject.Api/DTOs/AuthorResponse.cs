using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Api.DTOs
{
    //Bruges til vores API, så vi sender et objekt ud ved brug af denne "response class"
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
