namespace Lab_7
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Waybills = new ObservableListSource<Waybill>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [Required]
        public string NutritionalValues { get; set; }

        [Required]
        [StringLength(50)]
        public string Container { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int WeightPerUnit { get; set; }

        public int StorageTerm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableListSource<Waybill> Waybills { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
