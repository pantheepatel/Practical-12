using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
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

        // Create a stored procedure to insert data into the Designation table with required parameters

        // Create a stored procedure to insert data into the Employee table with required parameters

        // Create a stored procedure that returns a list of employees with columns Employee Id, First Name, Middle Name, Last Name, Designation, DOB, Mobile Number, Address & Salary(records should be ordered by DOB)

        // Create a stored procedure that return a list of employees by designation id(Input) with columns Employee Id, First Name, Middle Name, Last Name, DOB, Mobile Number, Address & Salary(records should be ordered by First Name)

        // Create Non-Clustered index on the DesignationId column of the Employee table



    }
}