using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Api.Database.Entites
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MiddleName { get; set; }

        [Column(TypeName = "smallint")]
        public int BirthYear { get; set; }

        [Column(TypeName = "smallint")]
        public int? YearOfDeath { get; set; }
    }
}
