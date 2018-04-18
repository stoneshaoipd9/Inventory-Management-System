using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoParts
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    /// 

    public partial class Register : Window
    {
        private Database db;

        public Register()
        {
            InitializeComponent();
            db = new Database();
        }
        // MainWindow login = new MainWindow();

        public static class NavigationService
        {
            static NavigationService()
            {
                NavigationStack.Push(Application.Current.MainWindow);
            }

            private static readonly Stack<Window> NavigationStack = new Stack<Window>();

            public static void NavigateTo(Window win)
            {
                if (NavigationStack.Count > 0)
                    NavigationStack.Peek().Hide();

                NavigationStack.Push(win);
                win.Show();
            }

            public static bool NavigateBack()
            {
                if (NavigationStack.Count <= 1)
                    return false;

                NavigationStack.Pop().Hide();
                NavigationStack.Peek().Show();
                return true;
            }

            public static bool CanNavigateBack()
            {
                return NavigationStack.Count > 1;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigateTo(new LoginWindow());
            this.Close();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            tbFName.Text = "";
            tbLName.Text = "";
            tbUserName.Text = "";
            pbPwd.Password = "";
            pbCFMPwd.Password = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbUserName.Text.Length == 0)
            {
                lblMessage.Content = "Enter an UserName.";
                tbUserName.Focus();
            }
            else if (!Regex.IsMatch(tbUserName.Text, @"^[a-zA-Z0-9]{2,20}$"))
            {
                lblMessage.Content = "Enter a valid UserName.";
                tbUserName.Select(0, tbUserName.Text.Length);
                tbUserName.Focus();
            }
            else
            {
                string firstname = tbFName.Text;
                string lastname = tbLName.Text;
                string username = tbUserName.Text;
                string password = pbPwd.Password;
                if (pbPwd.Password.Length == 0)
                {
                    lblMessage.Content = "Enter password.";
                    pbPwd.Focus();
                }
                else if (pbCFMPwd.Password.Length == 0)
                {
                    lblMessage.Content = "Enter Confirm password.";
                    pbCFMPwd.Focus();
                }
                else if (pbPwd.Password != pbCFMPwd.Password)
                {
                    lblMessage.Content = "Confirm password must be same as password.";
                    pbCFMPwd.Focus();
                }
                else
                {
                    lblMessage.Content = "";
                    SqlConnection con = new SqlConnection(@"Data Source=wei-abbott.database.windows.net;Initial Catalog=myprject_YW;Persist Security Info=True;User ID=dbadmin;Password=JohnIsGreat2000");
                    con.Open();
                    db.AddUser(new Employees(0, firstname, lastname, username, password, false));
                    con.Close();
                    MessageBox.Show("You have Registered successfully.");
                    Reset();
                }
            } 
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigateTo(new LoginWindow());
            this.Close();
        }
    }
}
