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

Select * from Employee_Task2;