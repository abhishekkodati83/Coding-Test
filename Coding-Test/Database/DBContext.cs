/// <summary>
/// Usually would create a new library as a seperate layer for DB operations
/// but for convenience creating a class file for the coding test
/// </summary>
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Coding_Test.Database
{
    public class DBContext : IDBContext
    {
        private readonly IConfiguration _configuration;

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// To fetch all the profiles
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDatabase")))
            {
                var sql = "SELECT [id],[name],[dob],[employeeId],[designation],[dateofjoining],[photo] FROM[dbo].[employee]";

                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var employee = new Employee()
                    {
                        Id = (long)reader["id"],
                        Name = reader["name"].ToString(),
                        DoB = Convert.ToDateTime(reader["dob"]),
                        EmployeeId = (long)reader["employeeId"],
                        Designation = reader["designation"].ToString(),
                        DoJ = Convert.ToDateTime(reader["dateofjoining"]),
                        Photo = reader["photo"].ToString()
                    };

                    employees.Add(employee);
                }
            }

            return employees;
        }

        /// <summary>
        /// To Add new employee record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>1 otherwise an exception</returns>
        public int AddEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDatabase")))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Dob", employee.DoB);
                    cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                    cmd.Parameters.AddWithValue("@Doj", employee.DoJ);
                    cmd.Parameters.AddWithValue("@Photo", employee.Photo);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Update the records of a particluar employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>1 otherwise an exception</returns>
        public int UpdateEmployee(long id, Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDatabase")))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Dob", employee.DoB);
                    cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                    cmd.Parameters.AddWithValue("@Doj", employee.DoJ);
                    cmd.Parameters.AddWithValue("@Photo", employee.Photo);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Delete the record on a particular employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 otherwise an exception</returns>
        public int DeleteEmployee(long id)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDatabase")))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        public static String ToBinary(Byte[] data)
        {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
    }
}
