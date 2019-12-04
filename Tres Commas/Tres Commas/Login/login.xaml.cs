using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;

namespace Tres_Commas.Login
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            IBaseTheme baseTheme = Theme.Light;

        }

        private void btnSubmit(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                errormessage.Text = "Please enter Username";
                txtUsername.Focus();
            }
            else if( txtPassword.Password.Length == 0)
            {
                errormessage.Text = "Please enter Password";
                txtUsername.Focus();
            }
            else
            {
                string username = txtUsername.Text;
                string password = txtPassword.Password;
                SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username='" + username + "'  AND password='" + password + "'", con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string id = dataSet.Tables[0].Rows[0]["user_id"].ToString();
                    int user_id = int.Parse(id);
                    //Sending value from one form to another form.
                    MainWindow main = new MainWindow(user_id);
                    main.Show();
                    Close();
                }
                else
                {
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
                        errormessage.Text = "Incorrect Password";
                    }
                    else
                    {
                        errormessage.Text = "No user registered with the given username";
                    }
                }
                con.Close();
            }
        }

        private void btnReset(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
            errormessage.Text = "";
        }

        private void btnRegister(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            Close();
        }
    }
}
