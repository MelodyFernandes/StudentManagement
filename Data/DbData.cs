using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentManagement.Data
{
    public class DbData
    {
        private static string _connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True";

        public List<Subject> GetSubject()
        {
            List<Subject> subjects = new List<Subject>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM subject", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject()
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Name = reader[1].ToString(),
                            DepartmentId= Convert.ToInt32(reader[2]),
                            Optional = Convert.ToBoolean(reader[3].ToString())
                        }) ;
                    }
                }
            }
            return subjects;
        }
        
        public List<Department> GetDepartment()
        {
            List<Department> depts = new List<Department>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Department", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        depts.Add(new Department()
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Name = reader[1].ToString(),
                        }) ;
                    }
                }
            }
            return depts;
        }

        public List<Student> GetStudents()
        {
            List<Student> depts = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Student", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        depts.Add(new Student()
                        {
                            Id = Convert.ToInt32(reader[0]),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                            DOB = reader[3].ToString(),
                        });
                    }
                }
            }
            return depts;
        }
    }
}