namespace HovLibrary2.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            BookDetails = new HashSet<BookDetail>();
        }

        public int id { get; set; }

        public int language_id { get; set; }

        public int publisher_id { get; set; }

        [Required]
        [StringLength(200)]
        public string title { get; set; }

        [Required]
        [StringLength(200)]
        public string authors { get; set; }

        [Required]
        [StringLength(20)]
        public string isbn { get; set; }

        [Required]
        [StringLength(20)]
        public string isbn13 { get; set; }

        public int number_of_pages { get; set; }

        [Column(TypeName = "date")]
        public DateTime publication_date { get; set; }

        public int ratings_count { get; set; }

        public double average_rating { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? last_updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

        public virtual Language Language { get; set; }

        public virtual Publisher Publisher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookDetail> BookDetails { get; set; }
    }
}
