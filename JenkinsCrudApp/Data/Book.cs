namespace JenkinsCrudApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string ArthurFirstName { get; set; }

        [StringLength(50)]
        public string ArthurLastName { get; set; }

        [StringLength(20)]
        public string Isbn { get; set; }

        public DateTime? PublicationDate { get; set; }

        [StringLength(50)]
        public string PublicationPlace { get; set; }
    }
}
