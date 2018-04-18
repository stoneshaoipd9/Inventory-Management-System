using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts
{
    class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CustSupplierId { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal CostPrice { get; set; }
        public int UnitsOnStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public Boolean Discontinued { get; set; }

        public Products(int productId, string productName, int custSupplierId, int quantityPerUnit,
            decimal costPrice, int unitsOnStock, int unitsOnOrder, Boolean discontinued)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.CustSupplierId = custSupplierId;
            this.QuantityPerUnit = quantityPerUnit;
            this.CostPrice = costPrice;
            this.UnitsOnStock = unitsOnStock;
            this.UnitsOnOrder = unitsOnOrder;
            this.Discontinued = discontinued;
        }
    }
}
