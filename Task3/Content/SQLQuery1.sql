CREATE TABLE Designation_Task3 (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Designation VARCHAR(50) NOT NULL
);
 
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

INSERT INTO Designation_Task3 (Designation) VALUES 
('Software Engineer'),
('Senior Software Engineer'),
('Team Lead'),
('Project Manager'),
('HR Manager'),
('Business Analyst');

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


CREATE PROCEDURE InsertDesignation 
    @DesignationName NVARCHAR(50)
AS 
BEGIN 
    INSERT INTO Designation_Task3 (Designation) VALUES (@DesignationName) 
END

CREATE PROCEDURE InsertEmployee 
	@FirstName VARCHAR(50),
	@MiddleName VARCHAR(50) NULL,
	@LastName VARCHAR(50),
	@DesignationId INT,
	@DOB DATE,
	@MobileNumber VARCHAR(15),
	@Address VARCHAR(255),
	@Salary DECIMAL(10,2) 
AS 
BEGIN 
	INSERT INTO Employee_Task3(FirstName, MiddleName, LastName, DesignationId, DOB, MobileNumber, Address, Salary) 
	VALUES (@FirstName, @MiddleName, @LastName, @DesignationId, @DOB, @MobileNumber, @Address, @Salary); 
END;

CREATE PROCEDURE GetEmployeesOrderedByDOB
AS
BEGIN
    SELECT
        e.Id, 
        e.FirstName, 
        e.MiddleName, 
        e.LastName, 
        d.Designation, 
        e.DOB, 
        e.MobileNumber, 
        e.Address, 
        e.Salary
    FROM Employee_Task3 e
    JOIN Designation_Task3 d ON e.DesignationId = d.Id
    ORDER BY e.DOB;
END;

CREATE PROCEDURE GetEmployeesByDesignationId
    @DesignationId INT
AS
BEGIN
    SELECT
        e.Id, 
        e.FirstName, 
        e.MiddleName, 
        e.LastName, 
        e.DOB, 
        e.MobileNumber, 
        e.Address, 
        e.Salary
    FROM Employee_Task3 e
    WHERE e.DesignationId = @DesignationId
    ORDER BY e.FirstName;
END;