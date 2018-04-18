using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShippedAddress { get; set; }
        public string BillAddress { get; set; }


        public Orders(int orderId, int employeeID, DateTime orderDate, DateTime shippedDate, string shippedAddress, string billAddress)
        {
            this.OrderId = orderId;
            this.EmployeeID = employeeID;
            this.OrderDate = orderDate;
            this.ShippedDate = shippedDate;
            this.ShippedAddress = shippedAddress;
            this.BillAddress = billAddress;
        }
    }
}
