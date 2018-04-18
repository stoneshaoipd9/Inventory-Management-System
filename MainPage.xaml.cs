using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace AutoParts
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        List<Products> productList = new List<Products>();
        List<Purchase> purchaseList = new List<Purchase>();
        List<CustSuppliers> custSupplierList = new List<CustSuppliers>();
        List<OrderDetails> orderDetailsList = new List<OrderDetails>();
        public List<Orders> orderList { get; set; }
        private Database db;

        List<Sale> saleList = new List<Sale>();
        List<Sale> Sales = new List<Sale>();
        internal CustSuppliers Cust { get => Cust; set => Cust = value; }

        public MainPage()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                RefreshProductList();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
        }
        //For Admin Window
        string userName;
        public void setUserName(string _userName)
        {            
            userName = _userName;
        }

  
        private void btnModifyProduct_Click(object sender, RoutedEventArgs e)
        {
            ModifyProduct modifyProduct = new ModifyProduct();

            string user = userName;
            Employees em = db.FindEmployeeByUserName(user);
            if (em.IsAdmin == true)
            {
                modifyProduct.Show();
            }
            else if (em.IsAdmin == false)
            {
                MessageBox.Show("You are not an administor!");
                return;
            }
           
        }

        private void btnModifyCustomer_Click(object sender, RoutedEventArgs e)
        {
            ModifyCustomer modifyCustomer = new ModifyCustomer();

            string user = userName;
            Employees em = db.FindEmployeeByUserName(user);
            if (em.IsAdmin == true)
            {
                modifyCustomer.Show();
            }
            else if (em.IsAdmin == false)
            {
                MessageBox.Show("You are not an administor!");
                return;
            }

        }

        private void btnModifyEmployee_Click(object sender, RoutedEventArgs e)
        {
            ModifyEmployee modifyEmployee = new ModifyEmployee();

            string user = userName;
            Employees em = db.FindEmployeeByUserName(user);
            if (em.IsAdmin == true)
            {
                modifyEmployee.Show();
            }
            else if (em.IsAdmin == false)
            {
                MessageBox.Show("You are not an administor!");
                return;
            }

        }

        private void btnModifySupplier_Click(object sender, RoutedEventArgs e)
        {
            ModifySupplier modifySupplier = new ModifySupplier();

            string user = userName;
            Employees em = db.FindEmployeeByUserName(user);
            if (em.IsAdmin == true)
            {
                modifySupplier.Show();
            }
            else if (em.IsAdmin == false)
            {
                MessageBox.Show("You are not an administor!");
                return;
            }

        }


        //For Purchase Window
        private void RefreshProductList()
        {
            lvProductList.ItemsSource = db.GetAllProducts();
            lvInventoryList.ItemsSource = db.GetAllProducts();
            lvProductList2.ItemsSource = db.GetAllProducts();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            Purchase pc = (Purchase)lvPurchaseList.SelectedItem;
            if (pc == null)
            {
                return;
            }

            int productId = int.Parse(tbkRemoveID.Text);
            string productName = tbkRemoveName.Text;
            int custSupplierId = pc.CustSupplierId;
            decimal costPrice = pc.CostPrice;
            string quantityStr = tbRemoveQty.Text;
            int quantity;
            if (!int.TryParse(quantityStr, out quantity))
            {
                MessageBox.Show("Quantity must be an integer");
                return;
            }
            if (quantity > pc.Quantity)
            {
                MessageBox.Show("Quantity can't more than the quantity in the purchase list");
                return;
            }
            try
            {
                if ((pc.Quantity - quantity) > 0)
                {
                    Purchase pur = new Purchase(0, productId, productName, custSupplierId, costPrice, pc.Quantity - quantity);
                    purchaseList.Remove(pc);
                    purchaseList.Add(pur);
                }
                else if ((pc.Quantity - quantity) == 0)
                {
                    purchaseList.Remove(pc);
                }
                lvPurchaseList.Items.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            lvPurchaseList.ItemsSource = purchaseList;
            lvPurchaseList.SelectedIndex = -1;
            tbkRemoveID.Text = "";
            tbkRemoveName.Text = "";
            tbRemoveQty.Text = "";

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
 
            Products p = (Products)lvProductList.SelectedItem;
            if (p == null)
            {
                return;
            }

            int productId = int.Parse(tbkAddID.Text);
            string productName = tbkAddName.Text;
            int custSupplierId = p.CustSupplierId;
            decimal costPrice = p.CostPrice;
            string quantityStr = tbAddQty.Text;
            int quantity;
            if (!int.TryParse(quantityStr, out quantity))
            {
                MessageBox.Show("Quantity must be an integer");
                return;
            }
            /*
            if (quantity > int.Parse(tbkUnitsOnStock.Text))
            {
                MessageBox.Show("Quantity can't more than the quantity in stock");
                return;
            }
            */
            try
            {
                Purchase pc = new Purchase(0, productId, productName, custSupplierId, costPrice, quantity);

                int index = 0;
                int totalQuantity = 0;
                int count = 0;
                bool exist = purchaseList.Any(p1 => p1.ProductId == pc.ProductId);
                if ((lvPurchaseList != null) && exist)
                {
                    foreach (Purchase p2 in purchaseList)
                    {
                        if (pc.ProductId == p2.ProductId)
                        {
                            totalQuantity = pc.Quantity + p2.Quantity;
                            index = count;
                        }
                        count++;
                    }
                    purchaseList.RemoveAt(index);
                    purchaseList.Add(new Purchase(0, productId, productName, custSupplierId, costPrice, totalQuantity));
                }
                if (!exist)
                {
                    purchaseList.Add(pc);
                }
                lvPurchaseList.Items.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            lvPurchaseList.ItemsSource = purchaseList;
            lvProductList.SelectedIndex = -1;
            tbkUnitsOnOrder.Text = quantity + "";
            tbkAddID.Text = "";
            tbkAddName.Text = "";
            tbAddQty.Text = "";
        }

        private void lvProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
 
            Products p = (Products)lvProductList.SelectedItem;
            if (p == null)
            {
                return;
            }

            CustSuppliers cs = db.FindCustSupplierById(p.CustSupplierId);

            tbkProductID.Text = p.ProductId + "";
            tbkProductName.Text = p.ProductName + "";
            tbkSupplierId.Text = p.CustSupplierId + "";
            tbkQtyPreUnit.Text = p.QuantityPerUnit + "";
            tbkUnitsOnOrder.Text = p.UnitsOnOrder + "";
            tbkUnitsOnStock.Text = p.UnitsOnStock + "";
            if (p.UnitsOnStock <= 5)
            {
                tbkUnitsOnStock.Foreground = Brushes.Red;
                tbkUnitsOnStock.Background = Brushes.Yellow;
            }
            else
            {
                tbkUnitsOnStock.Foreground = Brushes.Black;
                tbkUnitsOnStock.Background = Brushes.LightSteelBlue;
            }

            tbkSupplierID.Text = cs.CustSupplierId + "";
            tbkCompanyName.Text = cs.CompanyName + "";
            tbkContactName.Text = cs.ContactName + "";
            tbkPhone.Text = cs.Phone + "";
            tbkAddress.Text = cs.Address + "";

            tbkAddID.Text = p.ProductId + "";
            tbkAddName.Text = p.ProductName + "";
            tbAddQty.Text = 1 + "";
  
            lvPurchaseList.SelectedIndex = -1;
            tbkRemoveID.Text = "";
            tbkRemoveName.Text = "";
            tbRemoveQty.Text = "";
        }

        private void lvPurchaseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
            Purchase p = (Purchase)lvPurchaseList.SelectedItem;
            if (p == null)
            {
                return;
            }

            Products pd = db.FindProductById(p.ProductId);
            CustSuppliers cs = db.FindCustSupplierById(p.CustSupplierId);

            tbkProductID.Text = pd.ProductId + "";
            tbkProductName.Text = pd.ProductName + "";
            tbkSupplierId.Text = pd.CustSupplierId + "";
            tbkQtyPreUnit.Text = pd.QuantityPerUnit + "";
            tbkUnitsOnOrder.Text = pd.UnitsOnOrder + "";
            tbkUnitsOnStock.Text = pd.UnitsOnStock + "";

            tbkSupplierID.Text = cs.CustSupplierId + "";
            tbkCompanyName.Text = cs.CompanyName + "";
            tbkContactName.Text = cs.ContactName + "";
            tbkPhone.Text = cs.Phone + "";
            tbkAddress.Text = cs.Address + "";

            tbkRemoveID.Text = pd.ProductId + "";
            tbkRemoveName.Text = pd.ProductName + "";
            tbRemoveQty.Text = 1 + "";

            lvProductList.SelectedIndex = -1;
            tbkAddID.Text = "";
            tbkAddName.Text = "";
            tbAddQty.Text = "";
        }

        private void btnPurchaseSave_Click(object sender, RoutedEventArgs e)
        {
            string user = userName;
            Employees em = db.FindEmployeeByUserName(user);

            int employeeID = em.EmployeeId;
            DateTime orderDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            DateTime shippedDate = Convert.ToDateTime(DateTime.Today.AddDays(5).ToString("yyyy-MM-ddTHH:mm:ss"));
            string shippedAddress = "21275 Lakeshore Dr, Sainte-Anne-de-Bellevue, QC H9X 3L9";
            string billAddress = "21275 Lakeshore Dr, Sainte-Anne-de-Bellevue, QC H9X 3L9";

            Orders or = new Orders(0, employeeID, orderDate, shippedDate, shippedAddress, billAddress);
            db.AddPurchaseOrder(or);

            int orderId = db.GetLastOrderId();
            
            foreach (Purchase pur in purchaseList)
            {
                int productId = pur.ProductId;
                int custSupplierID = pur.CustSupplierId;
                decimal unitPrice = pur.CostPrice;
                int quantity = pur.Quantity;
                decimal discount = 0;
                OrderDetails ol = new OrderDetails(orderId, productId, custSupplierID, unitPrice, quantity, discount);
                db.AddProductOrder(ol);

                Products pd = db.FindProductById(productId);
                int unitsOnStock = pd.UnitsOnStock + quantity;

                db.UpdateProduct(new Products(productId, pd.ProductName, pd.CustSupplierId, pd.QuantityPerUnit, pd.CostPrice, unitsOnStock, 0, pd.Discontinued));
            }
            lvProductList.ItemsSource = db.GetAllProducts();
            lvPurchaseList.SelectedIndex = -1;
            lvPurchaseList.ItemsSource = null;
            lvPurchaseList.Items.Clear();
        }


        private void btnPurchaseReset_Click(object sender, RoutedEventArgs e)
        {
            lvProductList.SelectedIndex = -1;
            lvPurchaseList.SelectedIndex = -1;
            lvPurchaseList.ItemsSource = null;
            lvPurchaseList.Items.Clear();
        }
   

        //For Inventory Window

        private bool handle = true;

        private void comboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void comboSortBy_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void Handle()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvInventoryList.ItemsSource);

            switch (comboSortBy.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "ID":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("ProductId", ListSortDirection.Ascending));
                    break;
                case "Product Name":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("ProductName", ListSortDirection.Ascending));
                    break;
                case "SupplierId":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("CustSupplierId", ListSortDirection.Ascending));
                    break;
                case "Price":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("CostPrice", ListSortDirection.Ascending));
                    break;
                case "Units On Stock":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("UnitsOnStock", ListSortDirection.Ascending));
                    break;
                case "Units On Order":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("UnitsOnOrder", ListSortDirection.Ascending));
                    break;
                default:
                    return;
            }
        }

        
        private void btnRibbonPreview_Click(object sender, RoutedEventArgs e)
        {
            Preview previewWindow = new Preview();
            previewWindow.Show();
        }


        private void btnRibbonPrint_Click(object sender, RoutedEventArgs e)
        {
            /*
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
               printDialog.PrintVisual(this, "WPF Print");
            }*/
            
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() != true) return;
            FlowDocument doc = new FlowDocument();

            doc.PageHeight = printDialog.PrintableAreaHeight;
            doc.PageWidth = printDialog.PrintableAreaWidth;
            IDocumentPaginatorSource idocument = doc as IDocumentPaginatorSource;
            printDialog.PrintDocument(idocument.DocumentPaginator, "Printing Flow Document...");
        }

        private void btnRibbonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
             
            if (saveFileDialog.ShowDialog() == true)
            {

            }
                
        }

        private void btnRibbonOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRibbonExit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
        }

        private void comboInvoiceNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //For Sales Window

        private bool handle2 = true;
 
        public object ModalDialog { get; private set; }


        private void DatePicker_SelectedDateChanged(object sender,
              SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                // ... A null object.
                this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                this.Title = date.Value.ToShortDateString();
            }
        }



        private void refreshOrderList()
        {
            lvProductList2.ItemsSource = db.GetAllProducts();
        }


        private void btnAddSale_Click(object sender, RoutedEventArgs e)
        {
            Products p = (Products)lvProductList2.SelectedItem;
            if (p == null)
            {
                return;
            }

            int productId = p.ProductId;
            string productName = p.ProductName;
            int custSupplierId = p.CustSupplierId;
            decimal costPrice = p.CostPrice;
            string quantityStr = tbQty.Text;
            int quantity;
            if (!int.TryParse(quantityStr, out quantity))
            {
                System.Windows.MessageBox.Show("Quantity must be an integer");
                return;
            }
            try
            {
                Purchase pc = new Purchase(0, productId, productName, custSupplierId, costPrice, quantity);
                purchaseList.Add(pc);
                lvSaleList.Items.Refresh();

            }
            catch (ArgumentException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            lvSaleList.ItemsSource = purchaseList;
            lvProductList2.SelectedIndex = -1;
            tbQty.Text = "";

        }

        private void lvProductList2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Products p = (Products)lvProductList2.SelectedItem;

            if (p == null)
            {
                return;
            }

            CustSuppliers cs = db.FindCustSupplierById(p.CustSupplierId);
            Keyboard.Focus(tbCustomerId);

            tbQty.Text = p.QuantityPerUnit + "";
            lblCustomerName.Content = cs.CompanyName + "";
            lblContactName.Content = cs.ContactName + "";
            lvSaleList.SelectedIndex = -1;

        }


        private void tbAddQty_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void btnRemoveSale_Click(object sender, RoutedEventArgs e)
        {
            Purchase pc = (Purchase)lvSaleList.SelectedItem;
            //Sale sa = (Sale)lvSaleList.SelectedItem;
            if (pc == null)
            {
                return;
            }

            //    int productId = int.Parse(tbkRemoveID.Text);
            int productId = pc.ProductId;
            string productName = pc.ProductName;
            int custSupplierId = pc.CustSupplierId;
            decimal costPrice = pc.CostPrice;
            int quantity = pc.Quantity;

            try
            {
                Purchase pur = new Purchase(0, productId, productName, custSupplierId, costPrice, pc.Quantity - quantity);
                purchaseList.Remove(pc);
                purchaseList.Add(pur);
                lvSaleList.Items.Refresh();
            }
            catch (ArgumentException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            lvSaleList.ItemsSource = saleList;
            lvProductList2.SelectedIndex = -1;
            tbQty.Text = "";

        }

        private void comboPayMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox comboPayMeth = sender as System.Windows.Controls.ComboBox;
            handle2 = !comboPayMeth.IsDropDownOpen;
            Handle2();
        }

        private void comboPayMethod_DropDownClosed(object sender, EventArgs e)
        {
            if (handle2) Handle2();
            handle2 = true;
        }

        private void Handle2()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvSaleList.ItemsSource);


        }

        //private void comboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)


  
        private void tbCustomerId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbCustomerId.Select(0, tbCustomerId.Text.Length);
            tbCustomerId.Focus();
            /*
            int custI = int.Parse(tbCustomerId.Text);

            SqlConnection con = new SqlConnection(@"Data Source=wei-abbott.database.windows.net;Initial Catalog=myprject_YW;Persist Security Info=True;User ID=dbadmin;Password=JohnIsGreat2000");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from CustSuppliers where CustSupplierId='" + custI + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);*/

            string custId = tbCustomerId.Text;

            if (custId == null)
            {
                MessageBox.Show("Customer/Supplier ID Missing!");

                return;
            }

            CustSuppliers cs = db.FindCustSupplierById(int.Parse(custId));
            lblCustomerName.Content = cs.CompanyName+"";
            lblContactName.Content = cs.ContactName+"";
            tbBillAddress.Text = cs.Address;
            string od = OrderDate.Text;
            string sa = tbShipAddress.Text;
            string empId = tbEmployeeId.Text;
      
        }

        private void btnSaveSale_Click(object sender, RoutedEventArgs e)
        {
            string user = userName;
            Employees em = db.FindEmployeeByUserName(user);

            int customerId = int.Parse(tbCustomerId.Text);
            CustSuppliers cs = db.FindCustSupplierById(customerId);

            int employeeID = em.EmployeeId;
            DateTime orderDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            DateTime shippedDate = Convert.ToDateTime(DateTime.Today.AddDays(5).ToString("yyyy-MM-ddTHH:mm:ss"));
            string shippedAddress = cs.Address;
            string billAddress = cs.Address;

            Orders or = new Orders(0, employeeID, orderDate, shippedDate, shippedAddress, billAddress);
            db.AddPurchaseOrder(or);

            int orderId = db.GetLastOrderId();

            foreach (Purchase pur in purchaseList)
            {
                int productId = pur.ProductId;
                int custSupplierID = pur.CustSupplierId;
                decimal unitPrice = pur.CostPrice;
                int quantity = pur.Quantity;
                decimal discount = 0;
                OrderDetails ol = new OrderDetails(orderId, productId, custSupplierID, unitPrice, quantity, discount);
                db.AddProductOrder(ol);

                Products pd = db.FindProductById(productId);
                int unitsOnStock = pd.UnitsOnStock + quantity;

                db.UpdateProduct(new Products(productId, pd.ProductName, pd.CustSupplierId, pd.QuantityPerUnit, pd.CostPrice, unitsOnStock, 0, pd.Discontinued));
            }
            lvProductList.ItemsSource = db.GetAllProducts();
            lvPurchaseList.SelectedIndex = -1;
            lvPurchaseList.ItemsSource = null;
            lvPurchaseList.Items.Clear();
        }

    }
}
