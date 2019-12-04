using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
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
using static Tres_Commas.MainWindow;

namespace Tres_Commas
{
    /// <summary>
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transaction : Page
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void btnAddTrans(object sender, RoutedEventArgs e)
        {
            int user_id = Users.userId;
            string description = txtDesc.Text;
            DateTime trans_date = DateTime.Parse(txtDate.Text);
            
            string cat = category.SelectedItem.ToString();
            string t_type = ExpType.GetValue;
            MessageBox.Show(trans_date.ToString("dd-MM-yyyy"));

            SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO transactions (f_name,l_name,username,password) VALUES('" + firstname + "','" + lastname + "','" + username + "','" + password + "')", con)
            {
                CommandType = CommandType.Text
            };
            cmd.ExecuteNonQuery();
            con.Close();
            Reset();
            successmessage.Text = "You have Registered successfully. Proceed to login page to login.";
            /** Get Values from Form 
             *  and insert into database
             *  **/

        }

        private void NumValidate(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
