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
    /// Interaction logic for ModifySupplier.xaml
    /// </summary>
    public partial class ModifySupplier : Window
    {
        private Database db;

        public ModifySupplier()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                Filter();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
        }

        public void Filter()
        {
            List<CustSuppliers> list = db.GetAllCustSuppliers();
            var customerList = from c in list
                               where c.IsSupplier == true
                               select c;
            lvModifyCustomerList.ItemsSource = customerList;

        }

        private bool handle = true;

        private void comboMCSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void comboMCSortBy_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }


        private void Handle()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvModifyCustomerList.ItemsSource);

            switch (comboMCSortBy.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "ID":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("CustSupplierId", ListSortDirection.Ascending));
                    break;
                case "Company Name":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("CompanyName", ListSortDirection.Ascending));
                    break;
                case "Contact Name":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("ContactName", ListSortDirection.Ascending));
                    break;
                case "Contact Title":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("ContactTitle", ListSortDirection.Ascending));
                    break;
                case "Address":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Address", ListSortDirection.Ascending));
                    break;
                case "Phone":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Phone", ListSortDirection.Ascending));
                    break;
                default:
                    return;
            }
        }

        private void lvModifyCustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lvModifyCustomerList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            CustSuppliers c = (CustSuppliers)lvModifyCustomerList.Items[index];
            lblMCId.Content = c.CustSupplierId + "";
            tbMCCompanyName.Text = c.CompanyName;
            tbMCContactName.Text = c.ContactName;
            tbMCContactTitle.Text = c.ContactTitle;
            tbMCAddress.Text = c.Address;
            tbMCPhone.Text = c.Phone;
        }

        public void Reset()
        {
            lblMCId.Content = "";
            tbMCCompanyName.Text = "";
            tbMCContactName.Text = "";
            tbMCContactTitle.Text = "";
            tbMCAddress.Text = "";
            tbMCPhone.Text = "";
        }

        private void btnMCAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string companyName = tbMCCompanyName.Text;
                string contactName = tbMCContactName.Text;
                string contactTitle = tbMCContactTitle.Text;
                string address = tbMCAddress.Text;
                string phone = tbMCPhone.Text;
                Boolean isCustomer = false;
                Boolean isSupplier = true;

                CustSuppliers c = new CustSuppliers(0, companyName, contactName, contactTitle, address, phone, isCustomer, isSupplier);
                db.AddCustSupplier(c);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
            Reset();
        }

        private void btnMCRemove_Click(object sender, RoutedEventArgs e)
        {
            int index = lvModifyCustomerList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            CustSuppliers c = (CustSuppliers)lvModifyCustomerList.Items[index];
            try
            {
                db.DeleteCustSupplierById(c.CustSupplierId);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
            Reset();
        }

        private void btnMCUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index = lvModifyCustomerList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            CustSuppliers c = (CustSuppliers)lvModifyCustomerList.Items[index];
            try
            {
                c.CompanyName = tbMCCompanyName.Text;
                c.ContactName = tbMCContactName.Text;
                c.ContactTitle = tbMCContactTitle.Text;
                c.Address = tbMCAddress.Text;
                c.Phone = tbMCPhone.Text;

                db.UpdateCustSupplier(c);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
            Reset();
        }

        private void btnMCRefresh_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void btnMCReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
