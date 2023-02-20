namespace HovLibrary2.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Borrowing")]
    public partial class Borrowing
    {
        public int id { get; set; }

        public int member_id { get; set; }

        public int bookdetails_id { get; set; }

        public DateTime borrow_date { get; set; }

        public DateTime? return_date { get; set; }

        public decimal? fine { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? last_updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

        public virtual BookDetail BookDetail { get; set; }

        public virtual Member Member { get; set; }
    }
}
