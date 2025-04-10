# SQL Employee Management System

This project contains SQL scripts for managing employee records across three tasks. Each task focuses on different aspects of database design including table creation, data insertion, and implementing relationships using foreign keys.

## Common Prerequisites

Update the `web.config` file with the following connection string:

```xml
<connectionStrings>
    <add name="DefaultConnection" connectionString="Server=.\SQLEXPRESS;Database=Practical12;Trusted_Connection=True;TrustServerCertificate=true" providerName="System.Data.SqlClient" />
</connectionStrings>
```

> **Note:** Modify the connection string if your SQL Server instance differs from `.\SQLEXPRESS`.

```sql
CREATE DATABASE Practical12
USE Practical12
```

Run below stored procedures:

```sql
CREATE PROCEDURE InsertDesignation @DesignationName NVARCHAR(50) AS BEGIN INSERT INTO Designation_Task3 (Designation) VALUES (@DesignationName) END

CREATE PROCEDURE InsertEmployee @FirstName VARCHAR(50), @MiddleName VARCHAR(50) NULL, @LastName VARCHAR(50), @DesignationId INT, @DOB DATE, @MobileNumber VARCHAR(15), @Address VARCHAR(255), @Salary DECIMAL(10,2) AS BEGIN INSERT INTO Employee_Task3(FirstName, MiddleName, LastName, DesignationId, DOB, MobileNumber, Address, Salary) VALUES (@FirstName, @MiddleName, @LastName, @DesignationId, @DOB, @MobileNumber, @Address, @Salary); END;

CREATE PROCEDURE GetEmployeesOrderedByDOB AS BEGIN SELECT e.Id, e.FirstName, e.MiddleName, e.LastName, d.Designation, e.DOB, e.MobileNumber, e.Address, e.Salary FROM Employee_Task3 e JOIN Designation_Task3 d ON e.DesignationId = d.Id ORDER BY e.DOB; END;

CREATE PROCEDURE GetEmployeesByDesignationId @DesignationId INT AS BEGIN SELECT e.Id, e.FirstName, e.MiddleName, e.LastName, e.DOB, e.MobileNumber, e.Address, e.Salary FROM Employee_Task3 e WHERE e.DesignationId = @DesignationId ORDER BY e.FirstName; END;
```

---

## Task 1: Basic Employee Table

### Create Employee_Task1 Table

```sql
CREATE TABLE Employee_Task1 (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50),
    LastName VARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    MobileNumber VARCHAR(10) NOT NULL,
    Address VARCHAR(100)
);
```

### Insert Records

```sql
INSERT INTO Employee_Task1(FirstName, MiddleName, LastName, DOB, MobileNumber, Address)  
VALUES 
    ('Amit', 'Kumar', 'Sharma', '1990-01-15', '9876543210', '123 MG Road, Mumbai'),
    ('Priya', 'Raj', 'Verma', '1992-03-22', '9876543211', '56 Nehru Street, Delhi'),
    ('Rahul', NULL, 'Gupta', '1985-07-10', '9876543212', NULL),
    ('Sneha', 'A', 'Joshi', '1998-11-30', '9876543213', NULL),
    ('Vikram', NULL, 'Singh', '1993-05-25', '9876543214', '45 Civil Lines, Jaipur'),
    ('Neha', 'S', 'Patel', '1995-09-18', '9876543215', '12 Ring Road, Ahmedabad'),
    ('Arjun', 'M', 'Reddy', '1987-06-14', '9876543216', '67 Hi-Tech City, Hyderabad'),
    ('Kavita', NULL, 'Chopra', '1991-12-02', '9876543217', '78 Anna Nagar, Chennai'),
    ('Rohan', 'T', 'Bose', '1996-08-09', '9876543218', '34 Park Street, Kolkata'),
    ('Meera', 'V', 'Iyer', '1989-04-27', '9876543219', '90 MG Road, Pune');
```

---

## Task 2: Employee Table with Identity and Salary

### Create Table `Employee_Task2`

```sql
CREATE TABLE Employee_Task2 (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50),
    LastName VARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    MobileNumber VARCHAR(10) NOT NULL,
    Address VARCHAR(100),
    Salary DECIMAL NOT NULL
);
```

### Insert Records

```sql
INSERT INTO Employee_Task2 (FirstName, MiddleName, LastName, DOB, MobileNumber, Address, Salary)
VALUES  
    ('Rajesh', NULL, 'Sharma', '1985-07-15', '9876543210', '123, MG Road, Delhi', 65000.00),
    ('Amit', 'Prakash', 'Verma', '1990-03-25', '9823456789', '45, Park Street, Mumbai', 72000.50),
    ('Pooja', NULL, 'Gupta', '1995-10-10', '9781234567', '67, Laxmi Nagar, Pune', 55000.75),
    ('Suresh', 'Chandra', 'Patel', '1988-12-20', '9870012345', '22, Sector 5, Noida', 78000.25),
    ('Neha', NULL, 'Joshi', '1992-06-18', '9812345678', '12, Gandhi Path, Jaipur', 60000.00),
    ('Ankit', 'Vinod', 'Mehta', '1987-09-30', '9834567890', '89, Ashok Nagar, Ahmedabad', 82000.75),
    ('Kavita', 'Suresh', 'Desai', '1993-04-05', '9798765432', '34, Shivaji Road, Bangalore', 58000.90),
    ('Vikram', 'Narayan', 'Iyer', '1991-11-11', '9856784321', '76, MG Road, Chennai', 73000.30),
    ('Swati', NULL, 'Kulkarni', '1996-02-28', '9776543210', '56, Kothrud, Pune', 57000.40),
    ('Arun', 'Mahesh', 'Reddy', '1984-08-08', '9765432109', '90, Banjara Hills, Hyderabad', 89000.60);
```

---

## Task 3: Employee with Designation (Foreign Key Relationship)

### Create `Designation_Task3` Table

```sql
CREATE TABLE Designation_Task3 (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Designation VARCHAR(50) NOT NULL
);
```

### Insert Designations

```sql
INSERT INTO Designation_Task3 (Designation) VALUES 
('Software Engineer'),
('Senior Software Engineer'),
('Team Lead'),
('Project Manager'),
('HR Manager'),
('Business Analyst');
```

### Create `Employee_Task3` Table with Foreign Key

```sql
CREATE TABLE Employee_Task3 (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50) NULL,
    LastName VARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    MobileNumber VARCHAR(10) NOT NULL,
    Address VARCHAR(100) NULL,
    Salary DECIMAL(10,2) NOT NULL,
    DesignationId INT NULL,
    FOREIGN KEY (DesignationId) REFERENCES Designation_Task3(Id)
);
```

### Insert Records into `Employee_Task3`

```sql
INSERT INTO Employee_Task3 (FirstName, MiddleName, LastName, DOB, MobileNumber, Address, Salary, DesignationId) VALUES
('Amit', 'Raj', 'Sharma', '1995-06-15', '9876543210', 'Delhi, India', 65000.00, 1),
('Rohit', NULL, 'Verma', '1998-09-23', '7896541230', 'Mumbai, India', 75000.00, 1),
('Priya', 'Anand', 'Kapoor', '1992-04-10', '9658741230', 'Chennai, India', 85000.00, 2),
('Vikas', NULL, 'Mehta', '1988-07-19', '9988776655', 'Kolkata, India', 120000.00, 3),
('Neha', 'Kumari', 'Singh', '1996-12-25', '9098765432', 'Pune, India', 95000.00, 2),
('Suresh', 'Kumar', 'Patel', '1985-03-30', '8877665544', 'Ahmedabad, India', 150000.00, 4),
('Pooja', NULL, 'Reddy', '1997-11-14', '8899007766', 'Hyderabad, India', 70000.00, 1),
('Manish', 'Dev', 'Tripathi', '1990-01-01', '8787878787', 'Lucknow, India', 98000.00, 5),
('Sanjay', 'Pratap', 'Yadav', '1989-05-21', '8989898989', 'Bangalore, India', 105000.00, 3),
('Ritika', NULL, 'Gupta', '1993-02-17', '7676767676', 'Jaipur, India', 89000.00, 2),
('Nitin', NULL, 'Joshi', '1994-08-29', '9191919191', 'Chandigarh, India', 65000.00, 6),
('Kavita', 'Ramesh', 'Desai', '1991-10-05', '9292929292', 'Surat, India', 102000.00, 5);
```
