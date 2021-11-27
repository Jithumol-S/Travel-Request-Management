CREATE DATABASE TravelRequestSystem
USE TravelRequestSystem;

CREATE TABLE Login
(
	LoginId		INT PRIMARY KEY IDENTITY(1,1),
	Username	VARCHAR(25) NOT NULL,
	Password	VARCHAR(25) NOT NULL,
	UserType	INT NOT NULL

	CONSTRAINT FK_Roles_Login FOREIGN KEY(UserType) 
	REFERENCES UserTypes(UserTypeId)
);

CREATE TABLE UserTypes
(
	UserTypeId		INT PRIMARY KEY IDENTITY(1,1),
	UserType		VARCHAR(15)		
);

CREATE TABLE Employees
(
	EmpId			INT PRIMARY KEY IDENTITY(1,1),
	FirstName		VARCHAR(35) NOT NULL,
	LastName		VARCHAR(35) NOT NULL,
	Age				INT NOT NULL,
	Gender			VARCHAR(10) NOT NULL,
	Address			VARCHAR(150) NOT NULL,
	PhoneNumber		NUMERIC NOT NULL,
	LoginId			INT NOT NULL,
	IsActive		BIT NOT NULL


	CONSTRAINT FK_EMP_LOGIN FOREIGN KEY(LoginId)
	REFERENCES Login(LoginId)
);

CREATE TABLE RequestTable
(
	RequestId		INT PRIMARY KEY IDENTITY(1,1),
	CauseTravel		VARCHAR(100) NOT NULL,
	Source			VARCHAR(100) NOT NULL,
	Destination		NUMERIC NOT NULL,
	Mode			VARCHAR(100) NOT NULL,
	FromDate		DATE NOT NULL,
	ToDate			DATE NOT NULL,
	NoDays			INT NOT NULL,
	Priority		VARCHAR(20) NOT NULL,
	ProjectId		INT NOT NULL,
	EmpId			INT NOT NULL,
	Status			VARCHAR(20) NOT NULL,

	CHECK(Priority IN ('Critical','Normal')),

	CONSTRAINT FK_EMP_RTbl FOREIGN KEY(EmpId)
	REFERENCES Employees(EmpId),

	CONSTRAINT FK_PROJECT_RTbl FOREIGN KEY(ProjectId)
	REFERENCES Projects(ProjectId)
);

CREATE TABLE Projects
(
	ProjectId		INT PRIMARY KEY IDENTITY(1,1),
	ProjectName		VARCHAR(100) NOT NULL
);

ALTER TABLE Employees
ADD CHECK(Gender IN ('Female','Male'));

ALTER TABLE Projects ADD IsActive BIT;
UPDATE Projects SET IsActive=1;