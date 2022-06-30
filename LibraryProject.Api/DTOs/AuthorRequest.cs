using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Api.DTOs
{
    public class AuthorRequest
    {

        [Required]
        [StringLength(32, ErrorMessage = "Firstname must not containt more than 32 chars")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Lastname must not containt more than 32 chars")]
        public string LastName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Middlename must not containt more than 32 chars")]
        public string MiddleName { get; set; }

        [Required]
        [Range(1, 2500, ErrorMessage = "Birthyear must not containt more than 32 chars")]
        public int BirthYear { get; set; }

        [Required]
        [Range(1, 2500, ErrorMessage = "Year of death must not containt more than 32 chars")]
        public int? YearOfDeath { get; set; }
    }
}
