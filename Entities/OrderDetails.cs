using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts
{
    class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustSupplierID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
 

        public OrderDetails(int orderId, int productId, int custSupplierID, decimal unitPrice, int quantity, decimal discount)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.CustSupplierID = custSupplierID;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
            this.Discount = discount;
        }
    }
}
