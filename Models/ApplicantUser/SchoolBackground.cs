using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IAO.Models.ApplicantUser
{
    public class SchoolBackground
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public SubjectAndMarks[] SubjectAndMarks { get; set; }
    }
}