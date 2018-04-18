using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts
{
    class Employees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean IsAdmin { get; set; }


        public Employees(int employeeId, string firstName,
            string lastName, string userName, string password, Boolean isAdmin)
        {
            this.EmployeeId = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = userName;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }
    }
}
