namespace JenkinsCrudApp.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JenkinsCrudContext : DbContext
    {
        public JenkinsCrudContext()
            : base("name=JenkinsCrudContext")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
