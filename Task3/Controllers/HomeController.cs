using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Task3.Data;
using Task3.Models;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        public Task3Class t3Instance;
        public HomeController()
        {
            t3Instance = new Task3Class();
        }

        public ActionResult Index()
        {
            return View();
        }

        // Write a query to count the number of records by designation name
        public ActionResult Query1()
        {
            string query = "select d.Designation,count(e.Id) as EmployeeCount from Employee_Task3 e join Designation_Task3 d ON e.DesignationId = d.Id group by d.Designation";
            List<DesignationCount> result = t3Instance.GetDesignationCount(query);
            return View(result);
        }

        // Write a query to display First Name, Middle Name, Last Name & Designation name
        public ActionResult Query2()
        {
            string query = "select d.Designation,e.FirstName,e.MiddleName,e.LastName,e.Salary from Employee_Task3 e join Designation_Task3 d ON e.DesignationId = d.Id";
            List<EmpNameDesignation> result = t3Instance.GetEmpNameDesignation(query);
            return View(result);
        }

        // Write a query that displays only those designation names that have more than 1 employee
        public ActionResult Query3()
        {
            string query = "select d.Designation,count(e.Id) as EmployeeCount from Employee_Task3 e join Designation_Task3 d ON e.DesignationId = d.Id group by d.Designation having count(e.Id) > 1";
            List<DesignationCount> result = t3Instance.GetDesignationCount(query);
            return View("Query1", result);
        }

        // Write a query to find the employee having maximum salary
        public ActionResult Query4()
        {
            string query = "select top 1 e.FirstName, e.MiddleName, e.LastName, d.Designation, e.Salary from Employee_Task3 e join Designation_Task3 d ON e.DesignationId = d.Id order by e.Salary desc";
            List<EmpNameDesignation> result = t3Instance.GetEmpNameDesignation(query);
            return View("Query2", result);
        }

        // Create a database view that outputs Employee Id, First Name, Middle Name, Last Name, Designation, DOB, Mobile Number, Address & Salary
        public ActionResult CreateView()
        {
            // use to create view
            //string query = "CREATE VIEW EmployeeDetails AS SELECT e.Id, e.FirstName, e.MiddleName, e.LastName, d.Designation, e.DOB, e.MobileNumber, e.Address, e.Salary FROM Employee_Task3 e JOIN Designation_Task3 d ON e.DesignationId = d.Id";
            // to retrieve data from view
            string query = "select Id, FirstName, MiddleName, LastName, Designation, DOB, MobileNumber, Address, Salary from EmployeeDetails";
            List<CreateViewClass> result = t3Instance.createViewClasses(query);
            return View("ListEmpDetailsView", result);
        }

        // Create a stored procedure to insert data into the Designation table with required parameters
        public ActionResult CreateDesignation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDesignation(DesignationTask3 d3)
        {
            t3Instance.CreateDesignation(d3.Designation);
            return RedirectToAction("Index");
        }

        // Create a stored procedure to insert data into the Employee table with required parameters
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeTask3 e3)
        {
            t3Instance.CreateEmployee(e3);
            return RedirectToAction("Index");
        }

        // Create a stored procedure that returns a list of employees with columns Employee Id, First Name, Middle Name, Last Name, Designation, DOB, Mobile Number, Address & Salary(records should be ordered by DOB)
        public ActionResult ListOfEmployeesOrderByDOB()
        {
            List<CreateViewClass> result = t3Instance.GetEmployeesOrderedByDOB();
            return View("ListEmpDetailsView", result);
        }

        // Create a stored procedure that return a list of employees by designation id(Input) with columns Employee Id, First Name, Middle Name, Last Name, DOB, Mobile Number, Address & Salary(records should be ordered by First Name)
        public ActionResult GetEmployeesByDesignationId()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetEmployeesByDesignationIdMethod(int designationId)
        {
            List<EmployeeTask3> result = t3Instance.GetEmployeesByDesignationId(designationId);
            return View(result);
        }
    }
}