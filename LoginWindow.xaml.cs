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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        Register register = new Register();
        MainPage homepage = new MainPage(); 

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            register.Show();
            this.Close();
        }

        public void btnLogin_Click(object sender, RoutedEventArgs e)
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
                string username = tbUserName.Text;
                string password = pbPwd.Password;
                
                SqlConnection con = new SqlConnection(@"Data Source=wei-abbott.database.windows.net;Initial Catalog=myprject_YW;Persist Security Info=True;User ID=dbadmin;Password=JohnIsGreat2000");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Employees where UserName='" + username + "'  and Password='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    homepage.Show();
                    Close();
                }
                else
                {
                    lblMessage.Content = "Sorry! Please enter existing username/password.";
                }

                homepage.setUserName(username);
                con.Close();
            }
        }
    }
}
