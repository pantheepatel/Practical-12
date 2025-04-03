CREATE TABLE Employee_Task1 (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50),
    LastName VARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    MobileNumber VARCHAR(10) NOT NULL,
    Address VARCHAR(100)
);


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


SELECT * FROM Employee_Task1;
