using System;
using System.ComponentModel.DataAnnotations;

namespace JenkinsCrudApp.Models
{
    public class BookVm
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string AuthorFirstName { get; set; }

        [StringLength(50)]
        public string AuthorLastName { get; set; }

        [StringLength(20)]
        public string Isbn { get; set; }

        public string PublicationDate { get; set; }

        [StringLength(50)]
        public string PublicationPlace { get; set; }
    }
}