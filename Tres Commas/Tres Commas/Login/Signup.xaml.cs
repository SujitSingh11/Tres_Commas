using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
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

            if (txtFname.Text.Length == 0)
            {
                errormessage.Text = "Enter your first name.";
                txtFname.Focus();
            }
            else if (txtLname.Text.Length == 0)
            {
                errormessage.Text = "Enter your last name.";
                txtLname.Focus();
            }
            else if (txtUsername.Text.Length == 0)
            {
                errormessage.Text = "Enter your user name.";
                txtUsername.Focus();
            }
            else if (txtPassword.Password.Length == 0)
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
                SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                con.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM users WHERE username='" + username + "'", con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataAdapter adapter2 = new SqlDataAdapter
                {
                    SelectCommand = cmd2
                };
                DataSet dataSet2 = new DataSet();
                adapter2.Fill(dataSet2);
                if (dataSet2.Tables[0].Rows.Count > 0)
                {
                    errormessage.Text = "Username is already registered!";
                }
                else
                {
                    errormessage.Text = "";
                    SqlCommand cmd = new SqlCommand("INSERT INTO users (f_name,l_name,username,password) VALUES('" + firstname + "','" + lastname + "','" + username + "','" + password + "')", con)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Reset();
                    successmessage.Text = "You have Registered successfully. Proceed to login page to login.";
                }
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

        private void CharValidate(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
