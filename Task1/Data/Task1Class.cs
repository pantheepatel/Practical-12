using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Task1.Models;

namespace Task1.Data
{
    public class Task1Class
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public string getConnString()
        {
            return ConnectionString;
        }
        public List<Employee1Task1> GetEmployeeList()
        {
            List<Employee1Task1> employees = new List<Employee1Task1>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee_Task1", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Type: {reader["Id"].GetType()}");
                        Employee1Task1 employee = new Employee1Task1
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"] as string, // typecasting because this field might be null, so it will automatically handle it
                            LastName = reader["LastName"].ToString(),
                            DOB = (DateTime)reader["DOB"],
                            MobileNumber = reader["MobileNumber"].ToString(),
                            Address = reader["Address"] as string
                        };

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }


        public void ExecuteSelectedQuery(string userQuery, List<SqlParameter> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand commandQuery = new SqlCommand(userQuery, connection))
                {
                    if (parameters != null)
                    {
                        commandQuery.Parameters.AddRange(parameters.ToArray());
                    }
                    int rowsAffected = commandQuery.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("No rows were affected by the query.");
                    }
                }
            }
        }

    }
}