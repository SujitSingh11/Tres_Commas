using System;
using System.Collections.Generic;
using System.Data;
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

namespace Tres_Commas.Login
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void btnSubmit(object sender, RoutedEventArgs e)
        {
            string firstname = txtFname.Text;
            string lastname = txtLname.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            if (txtPassword.Password.Length == 0)
            {
                //errormessage.Text = "Enter password.";
                txtPassword.Focus();
            }
            else if (txtPasswordconf.Password.Length == 0)
            {
                //errormessage.Text = "Enter Confirm password.";
                txtPasswordconf.Focus();
            }
            else if (txtPassword.Password != txtPasswordconf.Password)
            {
                //errormessage.Text = "Confirm password must be same as password.";
                txtPassword.Focus();
            }
            else
            {
                //errormessage.Text = "";
                SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO users (f_name,l_name,username,password) VALUES('" + firstname + "','" + lastname + "','" + username + "','" + password + "')", con)
                {
                    CommandType = CommandType.Text
                };
                cmd.ExecuteNonQuery();
                con.Close();
                //errormessage.Text = "You have Registered successfully.";
                Reset();
            }
        }

        private void Reset()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtUsername.Text = "";
            txtPassword.Password = "";
            txtPasswordconf.Password = "";
        }

        private void btnReset(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void btnLogin(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
    }
}
