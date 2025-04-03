using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Data;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        public Task2Class t1Instance;
        public HomeController()
        {
            t1Instance = new Task2Class();
        }

        public ActionResult Index(List<Employee1Task2> employees_ = null)
        {
            string query = "SELECT * FROM Employee_Task2";
            List<Employee1Task2> employees = employees_ ?? t1Instance.GetEmployeeList(query);
            return View(employees);
        }
        public ActionResult InsertEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertEmployee(Employee1Task2 employee)
        {
            string query = "INSERT INTO Employee_Task2 (FirstName, MiddleName, LastName, DOB, MobileNumber, Address, Salary) VALUES(@FirstName, @MiddleName, @LastName, @DOB, @MobileNumber, @Address, @Salary)";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@FirstName", employee.FirstName),
                new SqlParameter("@MiddleName", (object)employee.MiddleName ?? DBNull.Value),
                new SqlParameter("@LastName", employee.LastName),
                new SqlParameter("@DOB", employee.DOB),
                new SqlParameter("@MobileNumber", employee.MobileNumber),
                new SqlParameter("@Address", (object)employee.Address ?? DBNull.Value),
                new SqlParameter("@Salary", employee.Salary)
            };

            t1Instance.ExecuteSelectedQuery(query, parameters);
            return RedirectToAction("Index");
        }
        //Write an SQL query to find the total amount of salaries
        public ActionResult Query1()
        {
            string query = "SELECT SUM(Salary) FROM Employee_Task2";
            ViewBag.QueryResult = t1Instance.ExecuteScalarQuery<decimal>(query);
            return View("QueryResultView");
        }
        //Write an SQL query to find all employees having DOB less than 01-01-2000
        public ActionResult Query2()
        {
            string query = "SELECT * FROM Employee_Task2 WHERE CAST(DOB AS DATE) < '2000-01-01'";
            List<Employee1Task2> employees_ = t1Instance.GetEmployeeList(query);
            return View("Index", employees_);
        }
        //Write an SQL query to count employees having Middle Name NULL
        public ActionResult Query3()
        {
            string query = "SELECT COUNT(*) FROM Employee_Task2 WHERE MiddleName IS NULL";
            ViewBag.QueryResult = t1Instance.ExecuteScalarQuery<int>(query);
            return View("QueryResultView");
        }
    }
}