using HelloWordUWP.Entities;
using HelloWordUWP.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWordUWP.Model
{
    public class StudentModel
    {

        private static string InsertCommand =
            "INSERT into `registerstudents`(`roll_number`, `full_name`, `email`, `address`) " +
            "VALUES (@rollnumber, @fullname, @email, @address)";
        private static string SelectCommand = "SELECT * FROM registerstudents";

        public bool Save(Student student)
        {
            using (var connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                var mysqlCommand = new MySqlCommand(InsertCommand, connection);
                mysqlCommand.Parameters.AddWithValue("@rollnumber", student.RollNumber);
                mysqlCommand.Parameters.AddWithValue("@fullname", student.FullName);
                mysqlCommand.Parameters.AddWithValue("@email", student.Email);
                mysqlCommand.Parameters.AddWithValue("@address", student.Address);

                mysqlCommand.ExecuteNonQuery();
                Console.WriteLine("Lưu sinh viên thành công");
                return true;
            }
            return false;
        }
        public List<Student> FillAll() //Có hay không có dữ liệu thì đều trả về một list rỗng .
        {
            //Tạo danh sách rỗng.
            List<Student> result = new List<Student>();
            //Tạo kết nối đến database.
            using(var connection = ConnectionHelper.GetConnection())
            {
                //mo ket noi
                connection.Open();
                //Tao cau lenh truy van tu ket noi o tren.
                var mysqlCommand = new MySqlCommand(SelectCommand, connection);
                //Thuc thi lay du lieu tra ve.
                var reader = mysqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    var rollNumber = reader.GetString("roll_number");
                    var fullName = reader.GetString("full_name");
                    var email = reader.GetString("email");
                    var address= reader.GetString("address");
                    var avatar= reader.GetString("avatar");
                    var birthday= reader.GetString("birthday");
                    var createdAt= reader.GetString("createdAt");
                    var updatedAt= reader.GetString("updatedAt");
                    var gender= reader.GetString("gender");
                    var phone= reader.GetString("phone");
                    var status= reader.GetInt32("status");
                   
                    var student = new Student
                    {
                        RollNumber = rollNumber,
                        FullName = fullName,
                        Email = email,
                        Address = address,
                        Avatar = avatar,
                        Birthday = birthday,
                        CreatedAt = createdAt,
                        UpdatedAt = updatedAt,
                        Gender = gender,
                        Phone = phone,
                        Status = status,
                    };
                    //add vao danh sach tra ve
                    result.Add(student);
                }
            }
            return result;
        }        
    }
}
