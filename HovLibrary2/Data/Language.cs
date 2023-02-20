namespace HovLibrary2.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Language")]
    public partial class Language
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Language()
        {
            Books = new HashSet<Book>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string code { get; set; }

        [Required]
        [StringLength(50)]
        public string long_text { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? last_updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
