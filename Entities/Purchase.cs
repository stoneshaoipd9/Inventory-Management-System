using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts
{
    class Purchase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CustSupplierId { get; set; }
        public decimal CostPrice { get; set; }
        public int Quantity { get; set; }

        public Purchase(int orderId, int productId, string productName, int custSupplierId, decimal costPrice, int quantity)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.ProductName = productName;
            this.CustSupplierId = custSupplierId;
            this.CostPrice = costPrice;
            this.Quantity = quantity;
        }
    }
}
