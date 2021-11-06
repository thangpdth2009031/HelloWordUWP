using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloWordUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        const string ConnectionString = "SERVER = localhost; DATABASE = universal-crud; USER ID= root; PASSWORD = ";
        
        MySqlConnection connection = new MySqlConnection(ConnectionString);
        MySqlCommand cmd;
        MySqlDataAdapter adpt;
        DataTable dt;

        public Register()
        {
            this.InitializeComponent();
            displayData();
        }        

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            var InserCommand = "INSERT INTO `students`(`student_id`, `firstName`, `lastName`, `address`, `phone`, `avatar`, `email`) " +
                "VALUES ('"+studentId.Text+ "','" + firstName.Text + "','" + lastName.Text + "','" + address.Text + "','" + phone.Text + "','" + avatar.Text + "','" + email.Text + "')";
            connection.Open();            
            cmd = new MySqlCommand(InserCommand, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            displayData();
            Clear();
        }
        public void displayData()
        {
            connection.Open();
            adpt = new MySqlDataAdapter("SELECT * FROM students", connection);
            dt = new DataTable();
            adpt.Fill(dt);
            for(var i = 0; i < dt.Columns.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(dt.Rows[i][0].ToString());
                for(var j = 0; j < dt.Columns.Count; j++)
                {

                }
            }
            connection.Close();
            
        }

        public void Clear()
        {
            studentId.Text = "";
            firstName.Text = "";
            lastName.Text = "";
            phone.Text = "";
            address.Text = "";
            email.Text = "";
            avatar.Text = "";
        }

        private void Btn_Update(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Delete(object sender, RoutedEventArgs e)
        {

        }
       
    }
}
