using System.Data;
using System.Data.SqlClient;
using System.Windows;


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
        }

        private void btnSubmit(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                //errormessage.Text = "Enter an email.";
                txtUsername.Focus();
            }
            else
            {
                string username = txtUsername.Text;
                string password = txtPassword.Password;
                MainWindow main = new MainWindow();
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
                    string user = dataSet.Tables[0].Rows[0]["f_name"].ToString() + " " + dataSet.Tables[0].Rows[0]["l_name"].ToString();
                    //Sending value from one form to another form.
                    main.Show();
                    Close();
                }
                else
                {
                    //errormessage.Text = "Sorry! Please enter existing emailid/password.";
                }
                con.Close();
            }
        }

        private void btnReset(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
        }

        private void btnRegister(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            Close();
        }
    }
}
