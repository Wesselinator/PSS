USE master
GO
DROP TABLE IF EXISTS PremierServiceSolutionsDB.CallInstance
DROP TABLE IF EXISTS PremierServiceSolutionsDB.TechnicianTaskFeedback
DROP TABLE IF EXISTS PremierServiceSolutionsDB.TechnicianTask
DROP TABLE IF EXISTS PremierServiceSolutionsDB.Technician
DROP TABLE IF EXISTS PremierServiceSolutionsDB.Task
DROP TABLE IF EXISTS PremierServiceSolutionsDB.ServiceRequest
DROP TABLE IF EXISTS PremierServiceSolutionsDB.FollowUpCall
DROP TABLE IF EXISTS PremierServiceSolutionsDB.FollowUpReport
DROP TABLE IF EXISTS PremierServiceSolutionsDB.ClientEntityContract
DROP TABLE IF EXISTS PremierServiceSolutionsDB.BusinessClientPerson
DROP TABLE IF EXISTS PremierServiceSolutionsDB.BusinessClient
DROP TABLE IF EXISTS PremierServiceSolutionsDB.IndividualClient
DROP TABLE IF EXISTS PremierServiceSolutionsDB.[User]
DROP TABLE IF EXISTS PremierServiceSolutionsDB.Person
DROP TABLE IF EXISTS PremierServiceSolutionsDB.[Address]
DROP TABLE IF EXISTS PremierServiceSolutionsDB.ContactInformation
DROP TABLE IF EXISTS PremierServiceSolutionsDB.ServiceLevelAgreement
DROP TABLE IF EXISTS PremierServiceSolutionsDB.CallChangeAssociation
DROP TABLE IF EXISTS PremierServiceSolutionsDB.ServiceLevelAgreement
DROP TABLE IF EXISTS PremierServiceSolutionsDB.[Contract]
DROP TABLE IF EXISTS PremierServiceSolutionsDB.[Service]
GO
DROP DATABASE IF EXISTS PremierServiceSolutionsDB
GO

CREATE DATABASE PremierServiceSolutionsDB
ON
(NAME = PremierServiceSolutionsDataFile1,
 FILENAME = 'C:\SQLServerDatabases\PremierServiceSolutionsDataFile1.mdf',
 SIZE = 5MB,
 MAXSIZE=UNLIMITED,
 FILEGROWTH =10%
)

LOG ON
(NAME = PremierServiceSolutionsLogFile1,
 FILENAME = 'C:\SQLServerDatabases\PremierServiceSolutionsLogFile1.ldf',
 SIZE = 5MB,
 MAXSIZE = UNLIMITED,
 FILEGROWTH = 10MB
)
GO

USE PremierServiceSolutionsDB
GO


CREATE TABLE [Service]
(ServiceID INT PRIMARY KEY,
 ServiceName VARCHAR(30) NOT NULL,
 ServiceDescription VARCHAR(MAX) NOT NULL
)


CREATE TABLE [Contract]
(ContractID INT PRIMARY KEY,
 ContractName VARCHAR(30) NOT NULL,
 ServiceLevel VARCHAR(15) NOT NULL,
 OfferStartDate DATETIME NOT NULL,
 OfferEndDate DATETIME,
 ContractDurationInMonths INT NOT NULL CHECK(ContractDurationInMonths>0),
 MontlyFee MONEY NOT NULL
)

GO

ALTER TABLE [Contract]
ADD CONSTRAINT CK_OfferEndDateAfterStartDate CHECK(OfferEndDate>=OfferStartDate)

CREATE TABLE ServiceLevelAgreement
(ServiceID INT REFERENCES Service(ServiceID),
 ContractID INT REFERENCES Contract(ContractID),
 PerformanceExpectation VARCHAR(MAX) NOT NULL,
 PRIMARY KEY(ServiceID,ContractID)
)

CREATE TABLE ContactInformation
(ContactInformationID INT PRIMARY KEY,
 CellPhoneNumber VARCHAR(12),
 TelephoneNumber VARCHAR(12),
 Email VARCHAR(320)
)

GO

ALTER TABLE ContactInformation
ADD CONSTRAINT CK_AtLeastOneModeOfContact CHECK(CellPhoneNumber!=NULL OR TelephoneNumber!=NULL OR Email!=NULL)


CREATE TABLE [Address]
(AddressID INT PRIMARY KEY,
 Street VARCHAR(50) NOT NULL,
 City VARCHAR(30) NOT NULL,
 PostalCode CHAR(4) NOT NULL,
 Province VARCHAR(20) NOT NULL
)

CREATE TABLE [Person]
(PersonID INT PRIMARY KEY,
 FirstName VARCHAR(50) NOT NULL,
 LastName VARCHAR(50) NOT NULL,
 BirthDate DATE,
 ContactInformationID INT NOT NULL REFERENCES ContactInformation(ContactInformationID)
)

CREATE TABLE [User]
(UserID INT PRIMARY KEY,
 UserName VARCHAR(50) NOT NULL,
 [Password] VARCHAR(50) NOT NULL,
 [Role] VARCHAR(50) NOT NULL
)

CREATE TABLE IndividualClient
(IndividualClientID INT REFERENCES Person(PersonID) PRIMARY KEY,
 [Type] VARCHAR(30) NOT NULL,
 [Status] VARCHAR(30) NOT NULL,
 Notes VARCHAR(MAX),
 AddressID INT NOT NULL REFERENCES Address(AddressID)
)

CREATE TABLE BusinessClient
(BusinessClientID INT PRIMARY KEY, --Can potentially use negative numbers for business clients or it can be determined Checking that their is not a conflict Person and BusinessClient 
 BusinessName VARCHAR(50),
 [Type] VARCHAR(30) NOT NULL,
 [Status] VARCHAR(30) NOT NULL,
 Notes VARCHAR(MAX),
 AddressID INT NOT NULL REFERENCES Address(AddressID)
)

CREATE TABLE BusinessClientPerson
(BusinessClientID INT REFERENCES BusinessClient(BusinessClientID),
 PersonID INT REFERENCES Person(PersonID),
 [Role] VARCHAR(50) NOT NULL,
 IsPrimaryContact BIT NOT NULL,
 PRIMARY KEY(BusinessClientID,PersonID)
)

CREATE TABLE ClientEntityContract
(ContractID INT REFERENCES Contract(ContractID),
 ClientEntityID INT,
 EffectiveDate DATETIME,
 PRIMARY KEY(ContractID,ClientEntityID,EffectiveDate)
)

GO

ALTER TABLE ClientEntityContract
ADD FOREIGN KEY (ClientEntityID) REFERENCES IndividualClient(IndividualClientID)

GO

ALTER TABLE ClientEntityContract
ADD FOREIGN KEY (ClientEntityID) REFERENCES BusinessClient(BusinessClientID)

CREATE TABLE FollowUpReport
(FollowUpReportID INT PRIMARY KEY,
 FollowUpTitle VARCHAR(30) NOT NULL,
 FollowUpType VARCHAR(20) NOT NULL,
 FollowUpDescription VARCHAR(MAX) NOT NULL,
 FollowUpDate DATETIME NOT NULL,
 ClientEntityID INT NOT NULL
)

GO

ALTER TABLE FollowUpReport
ADD FOREIGN KEY (ClientEntityID) REFERENCES IndividualClient(IndividualClientID)

GO

ALTER TABLE FollowUpReport
ADD FOREIGN KEY (ClientEntityID) REFERENCES BusinessClient(BusinessClientID)

GO


CREATE TABLE FollowUpCall
(FollowUpCallID INT PRIMARY KEY,
 IsIssueResolved BIT NOT NULL,
 SatisfactionLevel INT NOT NULL,
 FollowUpReportID INT NOT NULL REFERENCES FollowUpReport(FollowUpReportID)
)

CREATE TABLE ServiceRequest
(ServiceRequestID INT PRIMARY KEY,
 ServiceRequestTitle VARCHAR(30) NOT NULL,
 ServiceRequestType VARCHAR(20) NOT NULL,
 ServiceRequestDescription VARCHAR(MAX) NOT NULL,
 ClientEntityID INT NOT NULL
)

GO

ALTER TABLE ServiceRequest
ADD FOREIGN KEY (ClientEntityID) REFERENCES IndividualClient(IndividualClientID)

GO

ALTER TABLE ServiceRequest
ADD FOREIGN KEY (ClientEntityID) REFERENCES BusinessClient(BusinessClientID)

GO


CREATE TABLE Task
(TaskID INT PRIMARY KEY,
 TaskTitle VARCHAR(30) NOT NULL,
 TaskDescription VARCHAR(MAX) NOT NULL,
 TaskNotes VARCHAR(MAX),
 ServiceRequestID INT NOT NULL REFERENCES ServiceRequest(ServiceRequestID),
 --AddressID INT NOT NULL REFERENCES Address(AddressID), --Add constaint to take business or indiviual client address as default
 DateProcessed DATETIME NOT NULL,
 IsFinished BIT NOT NULL DEFAULT 0
)

CREATE TABLE Technician
(TechnicianID INT REFERENCES Person(PersonID) PRIMARY KEY,
 Speciality VARCHAR(30) NOT NULL,
 PayRate MONEY NOT NULL
)

CREATE TABLE TechnicianTask
(TechnicianTaskID INT PRIMARY KEY,
 TechnicianID INT NOT NULL REFERENCES Technician(TechnicianID),
 TaskID INT NOT NULL REFERENCES Task(TaskID),
 TimeToArrive DATETIME NOT NULL
)

CREATE TABLE TechnicianTaskFeedback
(TechnicianTaskFeedbackID INT PRIMARY KEY,
 TimeArrived DATETIME NOT NULL,
 TimeDeparture DATETIME NOT NULL,
 [Status] VARCHAR(30) NOT NULL,
 Notes VARCHAR(MAX),
 TechnicianTaskID INT NOT NULL REFERENCES TechnicianTask(TechnicianTaskID)
)
GO
--The following portion of the script is optional at this point


CREATE TABLE CallInstance
(CallInstanceID INT PRIMARY KEY,
 StartTime DATETIME NOT NULL,
 EndTime DATETIME NOT NULL,
 [Description] VARCHAR(120) NOT NULL
)

CREATE TABLE CallChangeAssociation
(CallChangeAssociationID INT PRIMARY KEY,
 CallInstanceID INT NOT NULL REFERENCES CallInstance(CallInstanceID),
 TableName VARCHAR(30) NOT NULL,
 TableRecordID VARCHAR(MAX) NOT NULL
)

