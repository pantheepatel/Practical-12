using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task3.Models;

namespace Task3.Data
{
    public class Task3Class
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public string getConnectionString()
        {
            return ConnectionString;
        }
        public List<EmployeeTask3> GetEmployeeList(string query)
        {
            List<EmployeeTask3> employees = new List<EmployeeTask3>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Type: {reader["Id"].GetType()}");
                        EmployeeTask3 employee = new EmployeeTask3
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"] as string, // typecasting because this field might be null, so it will automatically handle it
                            LastName = reader["LastName"].ToString(),
                            DOB = (DateTime)reader["DOB"],
                            MobileNumber = reader["MobileNumber"].ToString(),
                            Address = reader["Address"] as string,
                            Salary = (decimal)reader["Salary"]
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


        public T ExecuteScalarQuery<T>(string query)
        {
            object result = null;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    result = cmd.ExecuteScalar();
                }
            }
            return (T)result;
        }

        // Write a query to count the number of records by designation name
        public List<DesignationCount> GetDesignationCount(string query)
        {
            List<DesignationCount> designationCounts = new List<DesignationCount>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DesignationCount designationCount = new DesignationCount
                        {
                            Designation = reader["Designation"].ToString(),
                            EmployeeCount = (int)(reader["EmployeeCount"])
                        };

                        designationCounts.Add(designationCount);
                    }
                }
            }

            return designationCounts;
        }

        public List<EmpNameDesignation> GetEmpNameDesignation(string query)
        {
            List<EmpNameDesignation> employeeList = new List<EmpNameDesignation>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmpNameDesignation designationCount = new EmpNameDesignation
                        {
                            Designation = reader["Designation"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Salary = reader["Salary"].ToString()
                        };

                        employeeList.Add(designationCount);
                    }
                }
            }

            return employeeList;
        }

        public List<CreateViewClass> createViewClasses(string query) 
        {
            List<CreateViewClass> employeeList = new List<CreateViewClass>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CreateViewClass employee = new CreateViewClass
                        {
                            // DOB, MobileNumber, Address, Salary
                            Id = reader["Id"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Designation = reader["Designation"].ToString(),
                            DOB = (DateTime)reader["DOB"],
                            MobileNumber = reader["MobileNumber"].ToString(),
                            Address = reader["Address"].ToString(),
                            Salary = (decimal)reader["Salary"]
                        };

                        employeeList.Add(employee);
                    }
                }
            }

            return employeeList;
        }

        public void CreateDesignation(string designationName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand commandQuery = new SqlCommand("InsertDesignation", connection))
                {
                    commandQuery.CommandType = CommandType.StoredProcedure; // Set CommandType to StoredProcedure
                    commandQuery.Parameters.AddWithValue("@DesignationName", designationName);

                    commandQuery.ExecuteNonQuery();
                }
            }
        }
        public void CreateEmployee(EmployeeTask3 employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand commandQuery = new SqlCommand("InsertEmployee", connection))
                {
                    commandQuery.CommandType = CommandType.StoredProcedure;
                    commandQuery.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    commandQuery.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                    commandQuery.Parameters.AddWithValue("@LastName", employee.LastName);
                    commandQuery.Parameters.AddWithValue("@DesignationId", employee.DesignationId);
                    commandQuery.Parameters.AddWithValue("@DOB", employee.DOB);
                    commandQuery.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);
                    commandQuery.Parameters.AddWithValue("@Address", employee.Address);
                    commandQuery.Parameters.AddWithValue("@Salary", employee.Salary);

                    commandQuery.ExecuteNonQuery();
                }
            }
        }

        public List<CreateViewClass> GetEmployeesOrderedByDOB()
        {
            List<CreateViewClass> employees = new List<CreateViewClass>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetAllEmployees", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new CreateViewClass
                            {
                                FirstName = reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Designation = reader["Designation"].ToString(),
                                MobileNumber = reader["MobileNumber"].ToString(),
                                Address = reader["Address"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Salary = Convert.ToDecimal(reader["Salary"])
                            });
                        }
                    }
                }
            }
            return employees;
        }

        public List<EmployeeTask3> GetEmployeesByDesignationId(int designationId)
        {
            List<EmployeeTask3> employees = new List<EmployeeTask3>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetEmployeesByDesignationId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DesignationId", designationId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new EmployeeTask3
                            {
                                FirstName = reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                MobileNumber = reader["MobileNumber"].ToString(),
                                Address = reader["Address"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Salary = Convert.ToDecimal(reader["Salary"])
                            });
                        }
                    }
                }
            }
            return employees;
        }           
    }
}