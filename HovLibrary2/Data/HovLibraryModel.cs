using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HovLibrary2.Data
{
    public partial class HovLibraryModel : DbContext
    {
        public HovLibraryModel()
            : base("name=hov_library_connection")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookDetail> BookDetails { get; set; }
        public virtual DbSet<Borrowing> Borrowings { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.authors)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.isbn)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.isbn13)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.BookDetails)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.book_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookDetail>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<BookDetail>()
                .HasMany(e => e.Borrowings)
                .WithRequired(e => e.BookDetail)
                .HasForeignKey(e => e.bookdetails_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Borrowing>()
                .Property(e => e.fine)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Employee>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.long_text)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.language_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.BookDetails)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.location_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.city_of_birth)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Borrowings)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.member_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Publisher)
                .HasForeignKey(e => e.publisher_id)
                .WillCascadeOnDelete(false);
        }
    }
}
