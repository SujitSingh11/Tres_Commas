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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tres_Commas
{
    /// <summary>
    /// Interaction logic for Budget.xaml
    /// </summary>
    public partial class Budget : Page
    {
        public Budget()
        {
            InitializeComponent();
        }

        private void btnSearch(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM budget WHERE ", con)
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
                
            }
        }
    }
}
