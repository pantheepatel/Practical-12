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