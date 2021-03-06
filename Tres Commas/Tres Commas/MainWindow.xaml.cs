﻿using System;
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
using Tres_Commas.Login;

namespace Tres_Commas 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public static class Users
        {
            public static int userId;
            public static string fname;
            public static string lname;
            public static string name;
            public static string username;
        }
        public MainWindow(int user_id)
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection("Data Source=SUJIT_PC;Initial Catalog=tres_comma;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE user_id='" + user_id + "'", con)
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
                string name = dataSet.Tables[0].Rows[0]["f_name"].ToString() + " " + dataSet.Tables[0].Rows[0]["l_name"].ToString();
                string username = dataSet.Tables[0].Rows[0]["username"].ToString();
                Users.userId = user_id;
                Users.name = name;
                Users.username = username;
                Users.fname = dataSet.Tables[0].Rows[0]["f_name"].ToString();
                Users.lname = dataSet.Tables[0].Rows[0]["l_name"].ToString();
                string welcome = @"Welcome "+Users.name+" to your personal Expense Tracker";
                txtWelcome.Text = welcome;
            }
            else
            {
                Signup signup = new Signup();
                signup.Show();
                Close();
            }

        }
        

        private void BtnMyProfile(object sender, RoutedEventArgs e)
        {
            Main.Content = new MyProfile();
        }

        private void BtnTransaction(object sender, RoutedEventArgs e)
        {
            Main.Content = new Transaction();
        }

        private void BtnBudget(object sender, RoutedEventArgs e)
        {
            Main.Content = new Budget();
        }

        private void BtnReport(object sender, RoutedEventArgs e)
        {
            Main.Content = new Report();
        }

        private void BtnLogout(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            Close();
        }
    }

    
}
