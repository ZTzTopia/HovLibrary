namespace HovLibrary2.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookDetail()
        {
            Borrowings = new HashSet<Borrowing>();
        }

        public int id { get; set; }

        public int book_id { get; set; }

        public int location_id { get; set; }

        [Required]
        [StringLength(30)]
        public string code { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? last_updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

        public virtual Book Book { get; set; }

        public virtual Location Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }
}
