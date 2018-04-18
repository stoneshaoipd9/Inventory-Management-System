using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts
{
    class CustSuppliers
    {
        public int CustSupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Boolean IsCustomer { get; set; }
        public Boolean IsSupplier { get; set; }

        public CustSuppliers(int custSupplierId, string companyName, string contactName,
        string contactTitle, string address, string phone, Boolean isCustomer, Boolean isSupplier)
        {
            this.CustSupplierId = custSupplierId;
            this.CompanyName = companyName;
            this.ContactName = contactName;
            this.ContactTitle = contactTitle;
            this.Address = address;
            this.Phone = phone;
            this.IsCustomer = isCustomer;
            this.IsSupplier = isSupplier;
        }
    }
}

