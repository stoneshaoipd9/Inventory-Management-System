using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts
{
    class Sale
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CustSupplierId { get; set; }
        public decimal CostPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public Sale(int productId, string productName, int custSupplierId, decimal costPrice, int quantity, decimal discount)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.CustSupplierId = custSupplierId;
            this.CostPrice = costPrice;
            this.Quantity = quantity;
            this.Discount = discount;
        }

        public Sale(int productId, string productName, int custSupplierId, decimal costPrice)
        {
            ProductId = productId;
            ProductName = productName;
            CustSupplierId = custSupplierId;
            CostPrice = costPrice;
        }

        public Sale(int productId, string productName, int custSupplierId, decimal costPrice, int quantity) : this(productId, productName, custSupplierId, costPrice)
        {
            Quantity = quantity;
        }

        /*  public Sale(int productId, string productName, int custSupplierId, decimal costPrice, int quantity, decimal discount)
          {
              ProductId = productId;
              ProductName = productName;
              CustSupplierId = custSupplierId;
              CostPrice = costPrice;
              Quantity = quantity;
              Discount = discount;
          }*/
    }
}


