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
    /// Interaction logic for ModifyEmployee.xaml
    /// </summary>
    public partial class ModifyEmployee : Window
    {
        private Database db;

        public ModifyEmployee()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                lvModifyEmployeeList.ItemsSource = db.GetAllEmployees();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
        }

        private bool handle = true;

        private void comboMESortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void comboMESortBy_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }


        private void Handle()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvModifyEmployeeList.ItemsSource);

            switch (comboMESortBy.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "ID":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("EmployeeId", ListSortDirection.Ascending));
                    break;
                case "First Name":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
                    break;
                case "Last Name":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("LastName", ListSortDirection.Ascending));
                    break;
                case "User Name":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("UserName", ListSortDirection.Ascending));
                    break;
                case "Password":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
                    break;
                case "Is Admin":
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("IsAdmin", ListSortDirection.Ascending));
                    break;
                default:
                    return;
            }
        }

        public void Reset()
        {
            lblMEId.Content = "";
            tbMEFirstName.Text = "";
            tbMELastName.Text = "";
            tbMEUserName.Text = "";
            tbMEPassword.Text = "";
            tbMEIsAdmin.Text = "";
        }

        private void btnMCAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string firstName = tbMEFirstName.Text;
                string lastName = tbMELastName.Text;
                string userName = tbMEUserName.Text;
                string password = tbMEPassword.Text;
                Boolean isAdmin = false;

                Employees em = new Employees(0, firstName, lastName, userName, password, isAdmin);
                db.AddEmployee(em);
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
            int index = lvModifyEmployeeList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Employees em = (Employees)lvModifyEmployeeList.Items[index];
            try
            {
                db.DeleteEmployeeById(em.EmployeeId);
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
            int index = lvModifyEmployeeList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Employees em = (Employees)lvModifyEmployeeList.Items[index];
            try
            {
                em.FirstName = tbMEFirstName.Text;
                em.LastName = tbMELastName.Text;
                em.UserName = tbMEUserName.Text;
                em.Password = tbMEPassword.Text;

                db.UpdateEmployee(em);
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
            lvModifyEmployeeList.ItemsSource = db.GetAllEmployees();
        }

        private void btnMCReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void lvModifyEmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lvModifyEmployeeList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Employees em = (Employees)lvModifyEmployeeList.Items[index];
            lblMEId.Content = em.EmployeeId + "";
            tbMEFirstName.Text = em.FirstName;
            tbMELastName.Text = em.LastName;
            tbMEUserName.Text = em.UserName;
            tbMEPassword.Text = em.Password;
            tbMEIsAdmin.Text = em.IsAdmin + "";

        }
    }
}
