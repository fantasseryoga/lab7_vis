namespace Lab_7
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Waybill")]
    public partial class Waybill
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public long ProviderId { get; set; }

        public long ProductId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int Amount { get; set; }

        public virtual Product Product { get; set; }

        public virtual Provider Provider { get; set; }
    }
}
