namespace CreateDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int CustSupplierID { get; set; }

        public int EmployeeID { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal? Discount { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShippedDate { get; set; }

        [StringLength(50)]
        public string ShippedAddress { get; set; }

        public virtual CustSupplier CustSupplier { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Product Product { get; set; }
    }
}
