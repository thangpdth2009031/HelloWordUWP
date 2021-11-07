using HelloWordUWP.Entities;
using HelloWordUWP.Model;
using HelloWordUWP.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    public sealed partial class StdRegis : Page
    {
        StudentModel studentModel = new StudentModel();
        int id;
        public StdRegis()
        {
            this.InitializeComponent();
        }
        
        private void btnSaveStd_Click(object sender, RoutedEventArgs e)
        {
            Save();
            Clear();     
        }

        private void Save()
        {
            var InsertCommand =
            $"INSERT INTO `registerstudents`(`roll_number`, `full_name`, `email`, `address`, " +
            $"`avatar`, `birthday`, `createdAt`, `updatedAt`, `gender`, `phone`, `status`) VALUES" +
            $"('" + rollnumber.Text + "','" + fullname.Text + "','" + email.Text + "'," +
            "'" + address.Text + "','" + avatar.Text + "','" + birthday.Text + "'," +
            "'" + createdAt.Text + "','" + updatedAt.Text + "','" + gender.Text + "'," +
            "'" + phone.Text + "','" + status.Text + "')";
            Student student = new Student();
            var connection = ConnectionHelper.GetConnection();
            connection.Open();
            var mysqlCommand = new MySqlCommand(InsertCommand, connection);
            mysqlCommand.Parameters.AddWithValue(rollnumber.Text, student.RollNumber);
            mysqlCommand.Parameters.AddWithValue(fullname.Text, student.FullName);
            mysqlCommand.Parameters.AddWithValue(email.Text, student.Email);
            mysqlCommand.Parameters.AddWithValue(address.Text, student.Address);
            mysqlCommand.Parameters.AddWithValue(avatar.Text, student.Avatar);
            mysqlCommand.Parameters.AddWithValue(birthday.Text, student.Birthday);
            mysqlCommand.Parameters.AddWithValue(createdAt.Text, student.CreatedAt);
            mysqlCommand.Parameters.AddWithValue(updatedAt.Text, student.UpdatedAt);
            mysqlCommand.Parameters.AddWithValue(gender.Text, student.Gender);
            mysqlCommand.Parameters.AddWithValue(phone.Text, student.Phone);
            mysqlCommand.Parameters.AddWithValue(status.Text, student.Status);

            mysqlCommand.ExecuteNonQuery();
            thongbao.Text = "Luu sinh vien thanh cong.";
            connection.Close();
            Clear();
        }

       
        public void Clear()
        {           
            rollnumber.Text = "";
            fullname.Text = "";
            email.Text = "";
            address.Text = "";
            avatar.Text = "";
            birthday.Text = "";
            createdAt.Text = "";
            updatedAt.Text = "";
            gender.Text = "";
            phone.Text = "";
            status.Text = "";
        }

        private  void btnListStd_Click(object sender, RoutedEventArgs e)
        {
            thongbao.Text = "";
            var listStudent = studentModel.FillAll();
            ListViewStudent.ItemsSource = listStudent;
        }
        

        private void ListViewStudent_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {          
            rollnumber.Text = ListViewStudent.SelectedValue.ToString();
            fullname.Text = ListViewStudent.SelectedValue.ToString();
            email.Text = ListViewStudent.SelectedValue.ToString();
            address.Text = ListViewStudent.SelectedValue.ToString();
            avatar.Text = ListViewStudent.SelectedValue.ToString();
            birthday.Text = ListViewStudent.SelectedValue.ToString();
            createdAt.Text = ListViewStudent.SelectedValue.ToString();
            updatedAt.Text = ListViewStudent.SelectedValue.ToString();
            gender.Text = ListViewStudent.SelectedValue.ToString();
            phone.Text = ListViewStudent.SelectedValue.ToString();
            status.Text = ListViewStudent.SelectedValue.ToString();
        }

        private void btnUpdateStd_Click(object sender, RoutedEventArgs e)
        {
            var connection = ConnectionHelper.GetConnection();
            connection.Open();
            var mysqlCommand = new MySqlCommand("UPDATE `registerstudents` SET `roll_number`='" + rollnumber.Text + "'," +
                "`full_name`='" + fullname.Text + "',`email`='" + email.Text + "',`address`='" + address.Text + "',`avatar`='" + avatar.Text + "'," +
                "`birthday`='" + birthday.Text + "',`createdAt`='" + createdAt.Text + "',`updatedAt`='" + updatedAt.Text + "',`gender`='" + gender.Text + "'," +
                "`phone`='" + phone.Text + "',`status`='" + status.Text + "' WHERE roll_number = '" + rollnumber.Text + "'", connection);
            mysqlCommand.ExecuteNonQuery();
            connection.Close();
            Clear();
        }

        private void btnDeleteStd_Click(object sender, RoutedEventArgs e)
        {           
            var connection = ConnectionHelper.GetConnection();
            connection.Open();
            var mysqlCommand = new MySqlCommand(" DELETE FROM `registerstudents` WHERE `roll_number` = '"+rollnumber.Text+"';", connection);
            mysqlCommand.ExecuteNonQuery();
            thongbao.Text = "Xoa thanh cong sinh vien co rollnumber = " + rollnumber.Text;
            connection.Close();
            Clear();
        }
    }
}
