using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Task1.Data;
using Task1.Models;
namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        public Task1Class t1Instance;
        public HomeController()
        {
            t1Instance = new Task1Class();
        }

        public ActionResult Index()
        {
            List<Employee1Task1> employees = t1Instance.GetEmployeeList();
            return View(employees);
        }
        public ActionResult InsertEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertEmployee(Employee1Task1 employee)
        {
            string query = "INSERT INTO Employee_Task1 (FirstName, MiddleName, LastName, DOB, MobileNumber, Address) VALUES(@FirstName, @MiddleName, @LastName, @DOB, @MobileNumber, @Address)";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@FirstName", employee.FirstName),
                new SqlParameter("@MiddleName", (object)employee.MiddleName ?? DBNull.Value),
                new SqlParameter("@LastName", employee.LastName),
                new SqlParameter("@DOB", employee.DOB),
                new SqlParameter("@MobileNumber", employee.MobileNumber),
                new SqlParameter("@Address", (object)employee.Address ?? DBNull.Value)
            };

            t1Instance.ExecuteSelectedQuery(query, parameters);

            return RedirectToAction("Index");
        }
        //Write an Update query to change the First Name to “SQLPerson” for the first record
        public ActionResult Query1()
        {
            string query = "UPDATE Employee_Task1 SET FirstName = 'SQLPerson' WHERE Id = (SELECT MIN(Id) FROM Employee_Task1)";
            t1Instance.ExecuteSelectedQuery(query);
            return RedirectToAction("Index");
        }
        //Write an Update query to change the Middle Name to “I” for all records
        public ActionResult Query2()
        {
            string query = "UPDATE Employee_Task1 SET MiddleName = 'I'";
            t1Instance.ExecuteSelectedQuery(query);
            return RedirectToAction("Index");
        }
        //Write a delete query to delete record having Id column value less than 2
        public ActionResult Query3()
        {
            string query = "DELETE FROM Employee_Task1 WHERE Id < 2";
            t1Instance.ExecuteSelectedQuery(query);
            return RedirectToAction("Index");
        }
        //Write a query to delete all the data from the table
        public ActionResult Query4()
        {
            string query = "DELETE FROM Employee_Task1";
            t1Instance.ExecuteSelectedQuery(query);
            return RedirectToAction("Index");
        }

    }
}