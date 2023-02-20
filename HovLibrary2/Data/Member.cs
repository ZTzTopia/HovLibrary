namespace HovLibrary2.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Borrowings = new HashSet<Borrowing>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [Required]
        [StringLength(200)]
        public string phone_number { get; set; }

        [Required]
        [StringLength(200)]
        public string email { get; set; }

        [Required]
        [StringLength(200)]
        public string city_of_birth { get; set; }

        public DateTime date_of_birth { get; set; }

        [Required]
        [StringLength(200)]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string gender { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? last_updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }
}
