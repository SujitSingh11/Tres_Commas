using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using System.Data.SqlClient;
using System.Data;
using static Tres_Commas.MainWindow;

namespace Tres_Commas
{
    /// <summary>
    /// Interaction logic for MyProfile.xaml
    /// </summary>
    public partial class MyProfile : Page
    {
        public MyProfile()
        {
            InitializeComponent();
            IBaseTheme baseTheme = Theme.Light;
            
            string fname = Users.fname;
            string lname = Users.lname;
            string username = Users.username;
            int user_id = Users.userId;
            txtFirstName.Text = fname;
            txtLastName.Text = lname;
            txtUsername.Text = username;
            
        }

        private void btnUpdate(object sender, System.Windows.RoutedEventArgs e)
        {
            int user_id = Users.userId;
            string firstname = txtFirstName.Text;
            string lastname = txtLastName.Text;
            string username = txtUsername.Text;
            string OldPassword = txtOldPass.Password;
            string NewPassword = txtNewPass.Password;

            if (firstname != Users.fname)
            {
                errormessage.Text = "";
                SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE users SET f_name = '"+firstname+"' Where user_id = '"+user_id+"'", con)
                {
                    CommandType = CommandType.Text
                };
                cmd.ExecuteNonQuery();
                con.Close();
                Users.fname = firstname;
                errormessage.Text = "First Name Changed Successfull !";
            }
            if (lastname != Users.lname)
            {
                errormessage.Text = "";
                SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE users SET l_name = '"+lastname+"' Where user_id = '"+user_id+"'", con)
                {
                    CommandType = CommandType.Text
                };
                Users.lname = lastname;
                cmd.ExecuteNonQuery();
                con.Close();
                
                errormessage.Text = "Last Name Changed Successfull !";
            }
            if (username != Users.username)
            {

                errormessage.Text = "";
                SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE users SET username = '"+username+"' Where user_id = '"+user_id+"'", con)
                {
                    CommandType = CommandType.Text
                };
                cmd.ExecuteNonQuery();
                con.Close();
                Users.username = username;
                errormessage.Text = "Username Changed Successfull !";
            }
            if (txtNewPass.Password.Length != 0)
            {
                if (txtOldPass.Password.Length != 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username='" + username + "'  AND password='" + OldPassword + "'", con)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataAdapter adapter = new SqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    con.Close();
                    if (dataSet.Tables[0].Rows.Count == 0)
                    {
                        errormessage.Text = "Old Password dosen't match the existing password Changed Successfull !";
                    }
                    else
                    {

                        errormessage.Text = "";
                        SqlConnection conn = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                        con.Open();
                        SqlCommand cmmd = new SqlCommand("UPADATE users SET password = '" + NewPassword + "' WHERE user_id = '" + user_id + "'", conn)
                        {
                            CommandType = CommandType.Text
                        };
                        cmmd.ExecuteNonQuery();
                        conn.Close();
                        errormessage.Text = "Password Changed Successfull !";

                    }
                }
                errormessage.Text = "Please Enter Old Password";
            }
            else if (txtOldPass.Password.Length != 0)
            {
                if (txtNewPass.Password.Length != 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username='" + username + "'  AND password='" + OldPassword + "'", con)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataAdapter adapter = new SqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    con.Close();
                    if (dataSet.Tables[0].Rows.Count == 0)
                    {
                        errormessage.Text = "Old Password dosen't match the existing password Changed Successfull !";
                    }
                    else
                    {

                        errormessage.Text = "";
                        SqlConnection conn = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
                        con.Open();
                        SqlCommand cmmd = new SqlCommand("UPADATE users SET password = '" + NewPassword + "' WHERE user_id = '" + user_id + "'", conn)
                        {
                            CommandType = CommandType.Text
                        };
                        cmmd.ExecuteNonQuery();
                        conn.Close();
                        errormessage.Text = "Password Changed Successfull !";

                    }
                }
                errormessage.Text = "Please Enter New Password";
            }
            
            
        }

        private void btnReset(object sender, System.Windows.RoutedEventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            string fname = Users.fname;
            string lname = Users.lname;
            string username = Users.username;
            txtFirstName.Text = fname;
            txtLastName.Text = lname;
            txtUsername.Text = username;
            errormessage.Text = "";
            txtNewPass.Password = "";
            txtOldPass.Password = "";
        }
    }
}
