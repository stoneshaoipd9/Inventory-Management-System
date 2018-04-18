using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts
{
    class Database
    {
        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(@"Data Source=wei-abbott.database.windows.net;Initial Catalog=myprject_YW;Persist Security Info=True;User ID=dbadmin;Password=JohnIsGreat2000");
            conn.Open();
        }

        public List<Products> GetAllProducts()
        {
            List<Products> result = new List<Products>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Products", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int productId = (int)reader["ProductId"];
                    string productName = (string)reader["ProductName"];
                    int custSupplierId = (int)reader["CustSupplierId"];
                    int quantityPerUnit = (int)reader["QuantityPerUnit"];
                    decimal costPrice = (decimal)reader["CostPrice"];
                    int unitsOnStock = (int)reader["UnitsOnStock"];
                    int unitsOnOrder = (int)reader["UnitsOnOrder"];
                    Boolean discontinued = (Boolean)reader["Discontinued"];
                    Products p = new Products(productId, productName, custSupplierId, quantityPerUnit, costPrice, unitsOnStock, unitsOnOrder, discontinued);
                    result.Add(p);
                }
            }
            return result;
        }

        internal List<Employees> GetAllEmployees()
        {
            List<Employees> result = new List<Employees>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Employees", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int employeeId = (int)reader["EmployeeID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string userName = (string)reader["UserName"];
                    string password = (string)reader["Password"];
                    Boolean isAdmin = (Boolean)reader["IsAdmin"];
                    Employees e = new Employees(employeeId, firstName, lastName, userName, password, isAdmin);
                    result.Add(e);
                }
            }
            return result;
        }

        public List<CustSuppliers> GetAllCustSuppliers()
        {
            List<CustSuppliers> result = new List<CustSuppliers>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM CustSuppliers", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int custSupplierId = (int)reader["CustSupplierId"];
                    string companyName = (string)reader["CompanyName"];
                    string contactName = (string)reader["ContactName"];
                    string contactTitle = (string)reader["ContactTitle"];
                    string address = (string)reader["Address"];
                    string phone = (string)reader["Phone"];
                    Boolean isCustomer = (Boolean)reader["IsCustomer"];
                    Boolean isSupplier = (Boolean)reader["IsSupplier"];
                    CustSuppliers c = new CustSuppliers(custSupplierId, companyName, contactName, contactTitle, address, phone, isCustomer, isSupplier);
                    result.Add(c);
                }
            }
            return result;
        }

        public Employees FindEmployeeByUserName(string userName)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE UserName='" + userName + "'", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int employeeID = (int)reader["EmployeeID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string password = (string)reader["Password"];
                    Boolean isAdmin = (Boolean)reader["IsAdmin"];

                    return new Employees(employeeID, firstName, lastName, userName, password, isAdmin);
                }
            }
            return null;
        }


        public Products FindProductById(int ProductId)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE ProductId=" + ProductId, conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string productName = (string)reader["ProductName"];
                    int custSupplierId = (int)reader["CustSupplierId"];
                    int quantityPerUnit = (int)reader["QuantityPerUnit"];
                    decimal costPrice = (decimal)reader["CostPrice"];
                    int unitsOnStock = (int)reader["UnitsOnStock"];
                    int unitsOnOrder = (int)reader["UnitsOnOrder"];
                    Boolean discontinued = (Boolean)reader["Discontinued"];

                    return new Products(ProductId, productName, custSupplierId, quantityPerUnit, costPrice, unitsOnStock, unitsOnOrder, discontinued);
                }
            }
            return null;
        }


        public CustSuppliers FindCustSupplierById(int custSupplierId)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM CustSuppliers WHERE CustSupplierId=" + custSupplierId, conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string companyName = (string)reader["CompanyName"];
                    string contactName = (string)reader["ContactName"];
                    string contactTitle = (string)reader["ContactTitle"];
                    string address = (string)reader["Address"];
                    string phone = (string)reader["Phone"];
                    Boolean isCustomer = (Boolean)reader["IsCustomer"];
                    Boolean isSupplier = (Boolean)reader["IsSupplier"];

                    return new CustSuppliers(custSupplierId, companyName, contactName, contactTitle, address, phone, isCustomer, isSupplier);
                }
            }
            return null;
        }

         public void AddCustSupplier(CustSuppliers c)
        {
            List<CustSuppliers> result = new List<CustSuppliers>();
            string sql = "INSERT INTO CustSuppliers (CompanyName, ContactName, ContactTitle, Address, Phone, IsCustomer, IsSupplier) "
                        + " VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @Phone, @IsCustomer, @IsSupplier)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = c.CompanyName;
            cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = c.ContactName;
            cmd.Parameters.Add("@ContactTitle", SqlDbType.NVarChar).Value = c.ContactTitle;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = c.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = c.Phone;
            cmd.Parameters.Add("@IsCustomer", SqlDbType.Bit).Value = c.IsCustomer;
            cmd.Parameters.Add("@IsSupplier", SqlDbType.Bit).Value = c.IsSupplier;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            result.Add(c);
        }



        internal void AddEmployee(Employees e)
        {
            List<Employees> result = new List<Employees>();
            string sql = "INSERT INTO Employees (FirstName, LastName, UserName, Password, IsAdmin) "
                        + " VALUES (@FirstName, @LastName, @UserName, @Password, @IsAdmin)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = e.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = e.LastName;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = e.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = e.Password;
            cmd.Parameters.Add("@IsAdmin", SqlDbType.NVarChar).Value = e.IsAdmin;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            result.Add(e);
        }

        public void AddProductOrder(OrderDetails o)
        {
            List<OrderDetails> result = new List<OrderDetails>();
            string sql = "INSERT INTO OrderDetails (OrderId, ProductId, CustSupplierId, UnitPrice, Quantity, Discount) "
                        + " VALUES (@OrderId, @ProductId, @CustSupplierId, @UnitPrice, @Quantity, @Discount)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = o.OrderId;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = o.ProductId;
            cmd.Parameters.Add("@CustSupplierId", SqlDbType.Int).Value = o.CustSupplierID;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = o.UnitPrice;
            cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = o.Quantity;
            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = o.Discount;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            result.Add(o);
        }

        public void AddPurchaseOrder(Orders o)
        {
            List<Orders> result = new List<Orders>();
            string sql = "INSERT INTO Orders (EmployeeID, OrderDate, ShippedDate, ShippedAddress, BillAddress) "
                        + " VALUES (@EmployeeID, @OrderDate, @ShippedDate, @ShippedAddress, @BillAddress)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = o.EmployeeID;
            cmd.Parameters.Add("@OrderDate", SqlDbType.Date).Value = o.OrderDate;
            cmd.Parameters.Add("@ShippedDate", SqlDbType.Date).Value = o.ShippedDate;
            cmd.Parameters.Add("@ShippedAddress", SqlDbType.NVarChar).Value = o.ShippedAddress;
            cmd.Parameters.Add("@BillAddress", SqlDbType.NVarChar).Value = o.BillAddress;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            result.Add(o);
        }


        public void AddUser(Employees e)
        {
            List<Employees> result = new List<Employees>();
            
            string sql = "Insert into Employees (FirstName, LastName, UserName, Password, IsAdmin) " +
                        "values(@firstname, @lastname, @username, @password, @isAdmin)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = e.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = e.LastName;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = e.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = e.Password;
            cmd.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = e.IsAdmin;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            result.Add(e);
        }


        public void AddProduct(Products p)
        {
            List<Products> result = new List<Products>();
            string sql = "INSERT INTO Products (ProductName, CustSupplierId, QuantityPerUnit, CostPrice, UnitsOnStock, UnitsOnOrder, Discontinued) "
                        + " VALUES ( @ProductName, @CustSupplierId, @QuantityPerUnit, @CostPrice, @UnitsOnStock, @UnitsOnOrder, @Discontinued)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = p.ProductName;
            cmd.Parameters.Add("@CustSupplierId", SqlDbType.Int).Value = p.CustSupplierId;
            cmd.Parameters.Add("@QuantityPerUnit", SqlDbType.Int).Value = p.QuantityPerUnit;
            cmd.Parameters.Add("@CostPrice", SqlDbType.Decimal).Value = p.CostPrice;
            cmd.Parameters.Add("@UnitsOnStock", SqlDbType.Int).Value = p.UnitsOnStock;
            cmd.Parameters.Add("@UnitsOnOrder", SqlDbType.Int).Value = p.UnitsOnOrder;
            cmd.Parameters.Add("@Discontinued", SqlDbType.Bit).Value = p.Discontinued;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            result.Add(p);
        }

        public void DeleteProductById(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductId=@Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        internal void DeleteCustSupplierById(int custSupplierId)
        {
            string sql = "DELETE FROM CustSuppliers WHERE CustSupplierId=@custSupplierId";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@custSupplierId", SqlDbType.Int).Value = custSupplierId;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        internal void DeleteEmployeeById(int employeeId)
        {
            string sql = "DELETE FROM Employees WHERE EmployeeId=@employeeId";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@employeeId", SqlDbType.Int).Value = employeeId;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        public void UpdateProduct(Products p)
        {
            string sql = "UPDATE Products SET ProductName = @ProductName, CustSupplierId = @CustSupplierId, QuantityPerUnit = @QuantityPerUnit," +
                " CostPrice = @CostPrice, UnitsOnStock = @UnitsOnStock, UnitsOnOrder = @UnitsOnOrder, Discontinued = @Discontinued WHERE ProductId = @ProductId";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = p.ProductId;
            cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = p.ProductName;
            cmd.Parameters.Add("@CustSupplierId", SqlDbType.Int).Value = p.CustSupplierId;
            cmd.Parameters.Add("@QuantityPerUnit", SqlDbType.Int).Value = p.QuantityPerUnit;
            cmd.Parameters.Add("@CostPrice", SqlDbType.Decimal).Value = p.CostPrice;
            cmd.Parameters.Add("@UnitsOnStock", SqlDbType.Int).Value = p.UnitsOnStock;
            cmd.Parameters.Add("@UnitsOnOrder", SqlDbType.Int).Value = p.UnitsOnOrder;
            cmd.Parameters.Add("@Discontinued", SqlDbType.Bit).Value = p.Discontinued;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        internal int GetLastOrderId()
        {
            string sql = "SELECT TOP 1 OrderId FROM Orders ORDER BY OrderId DESC";
            SqlCommand command = new SqlCommand(sql, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int orderId = (int)reader["OrderId"];
                    return orderId;
                }
            }
            return 0;
        }

        public void UpdateCustSupplier(CustSuppliers c)
        {
            string sql = "UPDATE CustSuppliers SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle," +
      " Address = @Address, Phone = @Phone, IsCustomer = @IsCustomer, IsSupplier = @IsSupplier WHERE CustSupplierId = @CustSupplierId";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@CustSupplierId", SqlDbType.Int).Value = c.CustSupplierId;
            cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = c.CompanyName;
            cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = c.ContactName;
            cmd.Parameters.Add("@ContactTitle", SqlDbType.NVarChar).Value = c.ContactTitle;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = c.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = c.Phone;
            cmd.Parameters.Add("@IsCustomer", SqlDbType.Bit).Value = c.IsCustomer;
            cmd.Parameters.Add("@IsSupplier", SqlDbType.Bit).Value = c.IsSupplier;
       
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        internal void UpdateEmployee(Employees em)
        {
            string sql = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, Password = @Password, IsAdmin = @IsAdmin WHERE EmployeeID = @EmployeeID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = em.EmployeeId;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = em.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = em.LastName;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = em.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = em.Password;
            cmd.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = em.IsAdmin;
      
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
    }
}


