using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;

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
            IBaseTheme baseTheme = Theme.Light;
        }

        private void btnSubmit(object sender, RoutedEventArgs e)
        {
            string firstname = txtFname.Text;
            string lastname = txtLname.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            if (txtPassword.Password.Length == 0)
            {
                errormessage.Text = "Enter password.";
                txtPassword.Focus();
            }
            else if (txtPasswordconf.Password.Length == 0)
            {
                errormessage.Text = "Enter Confirm password.";
                txtPasswordconf.Focus();
            }
            else if (txtPassword.Password != txtPasswordconf.Password)
            {
                errormessage.Text = "Confirm password must be same as password.";
                txtPassword.Focus();
            }
            else
            {
                
                errormessage.Text = "";
                SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO users (f_name,l_name,username,password) VALUES('" + firstname + "','" + lastname + "','" + username + "','" + password + "')", con)
                {
                    CommandType = CommandType.Text
                };
                cmd.ExecuteNonQuery();
                con.Close();
                errormessage.Text = "You have Registered successfully.";
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
            errormessage.Text = "";
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
