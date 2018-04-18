using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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

namespace AutoParts
{
    /// <summary>
    /// Interaction logic for ModifyProduct.xaml
    /// </summary>
    public partial class ModifyProduct : Window
    {
        private Database db;

        public ModifyProduct()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                lvModifyProductList.ItemsSource = db.GetAllProducts();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
        }

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
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvModifyProductList.ItemsSource);

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

        private void btnMPAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string productName = tbMPProductName.Text;
                int supplierId = int.Parse(tbMPSupplierId.Text);
                int qtyPerUnit = int.Parse(tbMPQtyPerUnit.Text);
                decimal price = decimal.Parse(tbMPPrice.Text);
                int unitsOnStock = int.Parse(tbMPUnitsOnStock.Text);
                int unitsOnOrder = int.Parse(tbMPUnitsOnOrder.Text);
                bool discontinued = bool.Parse(tbMPDiscontinued.Text);
                Products p = new Products(0, productName, supplierId, qtyPerUnit, price, unitsOnStock, unitsOnOrder, discontinued);
                db.AddProduct(p);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
            Reset();
        }

        private void btnMPRemove_Click(object sender, RoutedEventArgs e)
        {
            int index = lvModifyProductList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Products p = (Products)lvModifyProductList.Items[index];
            try
            {
                db.DeleteProductById(p.ProductId);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
            Reset();

        }

        private void btnMPUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index = lvModifyProductList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Products p = (Products)lvModifyProductList.Items[index];
            try
            {
                p.ProductName = tbMPProductName.Text;
                p.CustSupplierId = int.Parse(tbMPSupplierId.Text);
                p.QuantityPerUnit = int.Parse(tbMPQtyPerUnit.Text);
                p.CostPrice = decimal.Parse(tbMPPrice.Text);
                p.UnitsOnStock = int.Parse(tbMPUnitsOnStock.Text);
                p.UnitsOnOrder = int.Parse(tbMPUnitsOnOrder.Text);
                p.Discontinued = bool.Parse(tbMPDiscontinued.Text);
                db.UpdateProduct(p);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
            Reset();
        }

        private void btnMPRefresh_Click(object sender, RoutedEventArgs e)
        {
            lvModifyProductList.ItemsSource = db.GetAllProducts();
   
        }

        private void btnMPReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvModifyProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lvModifyProductList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Products p = (Products)lvModifyProductList.Items[index];
            lblMPId.Content = p.ProductId + "";
            tbMPProductName.Text = p.ProductName;
            tbMPSupplierId.Text = p.CustSupplierId + "";
            tbMPPrice.Text = p.CostPrice + "";
            tbMPQtyPerUnit.Text = p.QuantityPerUnit + "";
            tbMPUnitsOnOrder.Text = p.UnitsOnOrder + "";
            tbMPUnitsOnStock.Text = p.UnitsOnStock + "";
            tbMPDiscontinued.Text = p.Discontinued + "";
        }

        public void Reset()
        {
            lblMPId.Content = "";
            tbMPProductName.Text = "";
            tbMPSupplierId.Text = "";
            tbMPPrice.Text = "";
            tbMPQtyPerUnit.Text = "";
            tbMPUnitsOnOrder.Text = "";
            tbMPUnitsOnStock.Text = "";
            tbMPDiscontinued.Text = "";

        }
    }
}
