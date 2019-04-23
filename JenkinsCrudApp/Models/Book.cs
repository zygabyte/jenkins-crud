using System;

namespace JenkinsCrudApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArthurFirstName { get; set; }
        public string ArthurLastName { get; set; }
        public string Isbn { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}