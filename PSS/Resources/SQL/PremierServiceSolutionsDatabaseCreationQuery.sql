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

GO

CREATE TABLE [Contract]
(ContractID INT PRIMARY KEY,
 ContractName VARCHAR(45) NOT NULL,
 ServiceLevel VARCHAR(15) NOT NULL,
 OfferStartDate DATETIME NOT NULL,
 OfferEndDate DATETIME,
 ContractDurationInMonths INT NOT NULL,
 MonthlyFee MONEY NOT NULL
)

ALTER TABLE [Contract]
ADD CONSTRAINT CK_OfferEndDateAfterStartDate CHECK(OfferEndDate>=OfferStartDate),
	CONSTRAINT CK_NoNegativeDates CHECK(ContractDurationInMonths>0);

GO

CREATE TABLE ServiceLevelAgreement
(ServiceID INT REFERENCES Service(ServiceID),
 ContractID INT REFERENCES Contract(ContractID),
 PerformanceExpectation VARCHAR(MAX) NOT NULL,
 PRIMARY KEY(ServiceID,ContractID)
)
--GO
--CREATE TABLE ContactInformation
--(ContactInformationID INT PRIMARY KEY,
 --CellPhoneNumber VARCHAR(12),
 --TelephoneNumber VARCHAR(12),
 --Email VARCHAR(320)
--)


--ALTER TABLE ContactInformation
--ADD CONSTRAINT CK_AtLeastOneModeOfContact CHECK(CellPhoneNumber!=NULL OR TelephoneNumber!=NULL OR Email!=NULL)

GO

CREATE TABLE [Address]
(AddressID INT PRIMARY KEY,
 Street VARCHAR(50) NOT NULL,
 City VARCHAR(30) NOT NULL,
 PostalCode CHAR(4),
 Province VARCHAR(20) NOT NULL
 )

 GO

CREATE TABLE [Person]
(PersonID INT PRIMARY KEY,
 FirstName VARCHAR(50) NOT NULL,
 LastName VARCHAR(50) NOT NULL,
 BirthDate DATE,
 CellPhoneNumber VARCHAR(12),
 TelephoneNumber VARCHAR(12),
 Email VARCHAR(320)
)

ALTER TABLE Person
ADD CONSTRAINT CK_AtLeastOneModeOfContact CHECK(CellPhoneNumber!=NULL OR TelephoneNumber!=NULL OR Email!=NULL)

GO

CREATE TABLE [User]
(UserID INT PRIMARY KEY,
 UserName VARCHAR(50) NOT NULL,
 [Password] VARCHAR(50) NOT NULL,
 [Role] VARCHAR(50) NOT NULL
)

GO

CREATE TABLE IndividualClient
(IndividualClientID INT REFERENCES Person(PersonID) PRIMARY KEY,
 [Type] VARCHAR(30) NOT NULL,
 [Status] VARCHAR(30) NOT NULL,
 Notes VARCHAR(MAX),
 AddressID INT NOT NULL REFERENCES Address(AddressID)
)

GO

CREATE TABLE BusinessClient
(BusinessClientID INT PRIMARY KEY, --Can potentially use negative numbers for business clients or it can be determined Checking that their is not a conflict Person and BusinessClient 
 BusinessName VARCHAR(50),
 [Type] VARCHAR(30) NOT NULL,
 [Status] VARCHAR(30) NOT NULL,
 Notes VARCHAR(MAX),
 PrimaryContactPersonID INT NOT NULL REFERENCES Person(PersonID),
 AddressID INT NOT NULL REFERENCES Address(AddressID)
)

GO

CREATE TABLE BusinessClientPerson
(BusinessClientID INT REFERENCES BusinessClient(BusinessClientID),
 PersonID INT REFERENCES Person(PersonID),
 [Role] VARCHAR(50) NOT NULL,
 PRIMARY KEY(BusinessClientID,PersonID)
)

GO

CREATE TABLE ClientEntityContract
(ContractID INT REFERENCES Contract(ContractID),
 ClientEntityID INT,
 EffectiveDate DATETIME,
 PRIMARY KEY(ContractID,ClientEntityID,EffectiveDate)
)

ALTER TABLE ClientEntityContract
ADD CONSTRAINT MFK_CECtoIndividualClients FOREIGN KEY (ClientEntityID) REFERENCES IndividualClient(IndividualClientID),
    CONSTRAINT MFK_CECtoBusinessClients FOREIGN KEY (ClientEntityID) REFERENCES BusinessClient(BusinessClientID);

GO

CREATE TABLE FollowUpReport
(FollowUpReportID INT PRIMARY KEY,
 FollowUpTitle VARCHAR(30) NOT NULL,
 FollowUpType VARCHAR(20) NOT NULL,
 FollowUpDescription VARCHAR(MAX) NOT NULL,
 FollowUpDate DATETIME NOT NULL,
 ClientEntityID INT NOT NULL
)

ALTER TABLE FollowUpReport
ADD FOREIGN KEY (ClientEntityID) REFERENCES IndividualClient(IndividualClientID),
	FOREIGN KEY (ClientEntityID) REFERENCES BusinessClient(BusinessClientID)

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

ALTER TABLE ServiceRequest
ADD FOREIGN KEY (ClientEntityID) REFERENCES IndividualClient(IndividualClientID),
	FOREIGN KEY (ClientEntityID) REFERENCES BusinessClient(BusinessClientID)

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

GO

CREATE TABLE Technician
(TechnicianID INT REFERENCES Person(PersonID) PRIMARY KEY,
 Speciality VARCHAR(30) NOT NULL,
 PayRate MONEY NOT NULL
)

GO

CREATE TABLE TechnicianTask
(TechnicianTaskID INT PRIMARY KEY,
 TechnicianID INT NOT NULL REFERENCES Technician(TechnicianID),
 TaskID INT NOT NULL REFERENCES Task(TaskID),
 TimeToArrive DATETIME NOT NULL
)

GO

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

GO

CREATE TABLE CallChangeAssociation
(CallChangeAssociationID INT PRIMARY KEY,
 CallInstanceID INT NOT NULL REFERENCES CallInstance(CallInstanceID),
 TableName VARCHAR(30) NOT NULL,
 TableRecordID VARCHAR(MAX) NOT NULL
)

GO

--SAMPLE DATA START

INSERT INTO Service (ServiceID, ServiceName, ServiceDescription)
	VALUES (1,'On Site Repairs','This Service involves calling out a specialized technician to fix an issue with a product on the customer''s site'),
		   (2,'Pickup Repairs','This Service involves fetching the product at the customer location and fixing it on PSS company grounds'),
		   (3,'Customer Phone Calls', 'This service determines the kind of calling support customers enjoy from the call centre'),
		   (4,'Routine Phone Checkups','This service determines the frequency of routine checkups performed with customers over the phone'),
		   (5,'Maintenance','This service determines the frequency and extent of maintenance tasks performed on the product.'),
		   (6,'Product Replacement','This service determines the conditions under which a product is entirely replaced'),
		   (7,'Thin/Fat Clients Lease To Own','This service determines the details of leasing thin clients to own from PSS'),
		   (8,'Laptops Lease To Own','This service determines the details of leasing laptops to own from PSS'),
		   (9,'Desktop Computers Lease To Own','This service determines the details of leasing desktop computers to own from PSS'),
		   (10,'Servers Lease To Own','This service determines the details of leasing server computers to own from PSS'),
		   (11,'Printers Lease To Own','This service determines the details of leasing printers to own from PSS')

GO

INSERT INTO Contract (ContractID, ContractName, ServiceLevel, OfferStartDate, OfferEndDate, ContractDurationInMonths, MonthlyFee)
	VALUES (1, 'Printing Necessities', 'Peasant', '2021/04/01', NULL, 36, 400),
		   (2, 'Basic Printing', 'Commoner', '2021/04/01', NULL, 36, 600),
		   (3, 'Premium Printing','Noble','2021/04/01',NULL,36, 900),
		   (4, 'Ultimate Printing','Feudal lord','2021/04/01',NULL,36, 1800),
		   (5, 'Individual Laptop Necessities','Peasant','2021/04/01',NULL,24, 400),
		   (6, 'Individual Computer Necessities','Peasant','2021/04/01',NULL,24, 400),
		   (7, 'Computer Lab Basics','Commoner','2021/04/01',NULL,48, 4000),
		   (8, 'Computer Lab Premium','Noble','2021/04/01',NULL,48, 5500),
		   (9, 'Computer Lab Super','Feudal lord','2021/04/01',NULL,36, 8000),
		   (10, 'Mini Office Combo','Peasant','2021/04/01',NULL,36,500),
		   (11, 'Medium Office Combo','Commoner','2021/04/01',NULL,36,700),
		   (12, 'Maxi Office Combo','Noble','2021/04/01',NULL,36,850),
		   (13, 'Giant Office Combo','Feudal lord','2021/04/01',NULL,48,1200),
		   (14, 'Garsfontein High School Custom','Noble','2021/04/01',NULL,48,14200)

GO

INSERT INTO ServiceLevelAgreement (ServiceID, ContractID, PerformanceExpectation)
	VALUES (11, 1, '1x Heavy Duty Inkjet Printer valued at R 10 000 of availiable brands HP, CANON or PIXMA , Capable of printing 50 pages per minute'),
		   (1, 1, 'Free on site repairs on all issues not relating to water or electrical damage'),
		   (3, 1, 'Unlimited phone calls to PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 4, thus a waiting time of up to 15 minutes may be incurred'),
		   (6, 1, 'Product will be replaced in the case of product failure resulting from a production fault.'),
		   
		   (11, 2, '1x Heavy Duty Laser Printer valued at R 17 000 of availiable brands HP, CANON or PIXMA , Capable of printing 100 pages per minute'),
		   (1, 2, 'Free on site repairs on all issues not relating to water or electrical damage'),
		   (2, 2, '5x Free pick-up repairs on all serious technical issues for the duration of the contract. Product can be expected to be fixed within 5 working days.'),
		   (3, 2, 'Unlimited customer phone calls to the PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 3, thus a waiting time of up to 10 minutes may be incurred'),
		   (4, 2, 'PSS Phone call checkups after 1 week of all repairs'),
		   (6, 2, 'Product will be replaced in the case of product failure resulting from a production fault.'),
		   
		   (11, 3, '1x Heavy Duty Laser Printer valued at R 25 000 of availiable brands HP, CANON or EPSON. Inlcudes WiFi, BlueTooth and Capable of printing 150 pages per minute'),
		   (1, 3, 'Free on site repairs on all issues not relating to water or electrical damage'),
		   (2, 3, 'Unlimited Free pick-up repairs on all serious technical issues for the duration of the contract. Product can be expected to be fixed within 3 working days. The product to be fixed will also be temporarily replaced'),
		   (3, 3, 'Unlimited phone calls to PSS call centre for assistance or service requests 24 hours every day of the week (Monday to Sunday). These phone calls will enjoy priority level 2, thus a waiting time of up to 5 minutes may be incurred'),
		   (4, 3, 'PSS Phone call checkups after 3 days of all repairs'),
		   (5, 3, 'A technician will visit customer grounds every 6 months for routine checkups on the product'),
		   (6, 3, 'Product will be replaced in the case of product failure resulting from a production fault or any environmental events outside of the customer''s control per evidence basis.'),

		   (11, 4, '1x Ultra Heavy Duty Laser Printer valued at R 50 000 of availiable brands HP, CANON or EPSON. Inlcudes WiFi, BlueTooth and Capable of printing 500 pages per minute'),
		   (1, 4, 'Free on site repairs on any kind of product issues. If the issue cannot be resolved within 4 hours, the product will be replaced as per the replacement service'),
		   (3, 4, 'Unlimited phone calls to PSS call centre for assistance or service requests 24 hours every day of the week (Monday to Sunday). These phone calls will enjoy priority level 1, thus a maximum waiting time of up to 2 minutes may be incurred'),
		   (4, 4, 'PSS Phone call checkups within 24 hours and after 3 days of all repairs'),
		   (5, 4, 'A technician will visit customer grounds every 3 months for routine checkups on the product'),
		   (6, 4, 'Product will be replaced in the case of any kind of product failure resulting from unintentional cause as per evidence basis or in cases where the product cannot be repaired the customer''s premise'),

		   (8, 5, '1x laptop valued at R 6000 of availiable brands HP, LENOVO, ASUS or MSI. Inlcudes Windows 10 and Office 2019'),
		   (2, 5, '5x Free pick up repairs on the product for the duration of the contract'),
		   (3, 5, 'Unlimited phone calls to PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 4, thus a waiting time of up to 15 minutes may be incurred'),		   
		   (6, 5, 'Product will be replaced in the case of product failure resulting from a production fault.'),

		   (9, 6, '1x desktop computer valued at R 6000 of availiable brands HP, LENOVO, ASUS or MSI. Inlcudes Windows 10 and Office 2019'),
		   (2, 6, '5x Free pick up repairs on the product for the duration of the contract'),
		   (3, 6, 'Unlimited phone calls to PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 4, thus a waiting time of up to 15 minutes may be incurred'),		   
		   (6, 6, 'Product will be replaced in the case of product failure resulting from a production fault.'),

		   (7, 7, '25x fat clients valued at R 4000  each of availiable brands HP or MSI. Inlcudes Windows 10 and Office 2019. These computers are not reliant on a server to fulfill their funcationality'),
		   (2, 7, 'Unlimited Free pick up repairs on the products for the duration of the contract'),
		   (3, 7, 'Unlimited phone calls to PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 3, thus a waiting time of up to 10 minutes may be incurred'),		   
		   (5, 7, 'A technician will visit customer grounds every 6 months for routine checkups on the product system'),
		   (6, 7, 'Product will be replaced in the case of product failure resulting from a production fault.'),

		   (7, 8, '40x thin clients valued at R 3500  each of availiable brands HP or MSI. Inlcudes Red Hat Linux. These computers rely on a server to fulfill their funcationality'),
		   (10, 8, '1x server valued at R 25000 of availiable brands DELL, LENOVO, HP or MSI. Inlcudes 32 Threads, 256GB RAM, Windows 10 Server and Office 2019 (volume license edition).'),
		   (1, 8, 'Free on site repairs on any kind of product issues. If the issue cannot be resolved within 4 hours, the product will be replaced as per the replacement service'),
		   (2, 8, 'Unlimited Free pick up repairs on the products for the duration of the contract'),
		   (3, 8, 'Unlimited phone calls to PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 2, thus a waiting time of up to 5 minutes may be incurred'),		   
		   (5, 8, 'A technician will visit customer grounds every 3 months for routine checkups on the product system'),
		   (6, 8, 'Product will be replaced in the case of product failure resulting from a production fault.'),

		   (7, 9, '50x thin clients valued at R 5000 each of availiable brands HP or MSI. Inlcudes Red Hat Linux. These computers rely on a server to fulfill their funcationality'),
		   (10, 9, '1x server valued at R 40000 of availiable brands DELL, LENOVO, HP or MSI. Inlcudes 64 Threads, 512GB RAM, Windows 10 Server and Office 2019 (volume license edition).'),
		   (1, 9, 'Free on site repairs on any kind of product issues. If the issue cannot be resolved within 4 hours, the product will be replaced as per the replacement service'),
		   (2, 9, 'Unlimited Free pick up repairs on the products for the duration of the contract'),
		   (3, 9, 'Unlimited phone calls to PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 1, thus a waiting time of up to 2 minutes may be incurred'),		   
		   (5, 9, 'A technician will visit customer grounds every 2 months for routine checkups on the product system'),
		   (6, 9, 'Product will be replaced in the case of product failure resulting from a production fault.'),

		   (9, 10, '1x desktop computer valued at R 8000 of availiable brands DELL or HP. Inlcudes Windows 10 and Office 2019'),
		   (11, 10, '1x small office inkjet printer valued at R 4000 of availiable brands HP, CANON or PIXMA. Capable of printing 15 pages per minute.'),
		   (1, 10, 'Free on site repairs on all issues not relating to water or electrical damage'),
		   (2, 10, 'Unlimited Free pick up repairs on the products for the duration of the contract'),
		   (3, 10, 'Unlimited phone calls to PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 4, thus a waiting time of up to 15 minutes may be incurred'),		   
		   (6, 10, 'Product will be replaced in the case of product failure resulting from a production fault.'),

		   (9, 11, '1x desktop computer valued at R 12000 of availiable brands DELL or HP. Inlcudes Windows 10 and Office 2019'),
		   (11, 11, '1x Office inkjet printer valued at R 6000 of availiable brands HP, CANON or PIXMA. Capable of printing 25 pages per minute.'),
		   (1, 11, 'Free on site repairs on all issues not relating to water or electrical damage'),
		   (2, 11, 'Unlimited Free pick up repairs on the products for the duration of the contract'),
		   (3, 11, 'Unlimited phone calls to PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 3, thus a waiting time of up to 10 minutes may be incurred'),		   
		   (6, 11, 'Products will be replaced in the case of product failure resulting from a production fault.'),

		   (9, 12, '1x desktop computer valued at R 16000 of availiable brands DELL or HP. Inlcudes Windows 10 and Office 2019'),
		   (11, 12, '1x Office inkjet printer valued at R 8000 of availiable brands HP, CANON or EPSON. Capable of printing 35 pages per minute.'),
		   (1, 12, 'Free on site repairs on all issues not relating to water or electrical damage'),
		   (2, 12, 'Unlimited Free pick up repairs on the products for the duration of the contract'),
		   (3, 12, 'Unlimited phone calls to PSS call centre for assistance or service requests 24 hours every day of the week (Monday to Sunday). These phone calls will enjoy priority level 2, thus a waiting time of up to 5 minutes may be incurred'),		   
		   (6, 12, 'Products will be replaced in the case of product failure resulting from a production fault.'),

		   (9, 13, '1x desktop computer valued at R 20000 of availiable brands DELL or HP. Inlcudes Windows 10 and Office 2019'),
		   (10, 13, '1x storage server valued at R 15000 of availiable brands DELL, LENOVO, HP or MSI. Inlcudes 32 TB storage, Windows 10 Server and Office 2019 (volume license edition).'),
		   (11, 13, '1x Office inkjet printer valued at R 8000 of availiable brands HP, CANON or EPSON. Capable of printing 35 pages per minute.'),
		   (1, 13, 'Free on site repairs on all issues not relating to water or electrical damage'),
		   (2, 13, 'Unlimited Free pick up repairs on the products for the duration of the contract'),
		   (3, 13, 'Unlimited phone calls to PSS call centre for assistance or service requests 24 hours every day of the week (Monday to Sunday). These phone calls will enjoy priority level 1, thus a maximum waiting time of up to 2 minutes may be incurred'),		   
		   (6, 13, 'Products will be replaced in the case of product failure resulting from a production fault.'),

		   (7, 14, '120x fat clients valued at R 3500 each of brand MSI. Inlcudes Windows 10. These computers are not reliant on a server to fulfill their funcationality'),
		   (10, 14, '4x server valued at R 25000 each of brand DELL. Each Server Inlcudes 32 Threads, 128GB RAM, Windows 10 Server and Office 365 (volume license edition).'),
		   (1, 14, 'Free on site repairs on any kind of product issues. If the issue cannot be resolved within 4 hours, the product will be replaced as per the replacement service'),
		   (2, 14, 'Unlimited Free pick up repairs on the products for the duration of the contract'),
		   (3, 14, 'Unlimited phone calls to PSS call centre for assistance or service requests during specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 1, thus a waiting time of up to 2 minutes may be incurred'),
		   (5, 14, 'A technician will visit customer grounds every month for routine checkups on the product system'),
		   (6, 14, 'Products will be replaced in the case of product failure resulting from a production fault.')

GO
		   --Use Odd primary keys for person
INSERT INTO Person (PersonID, FirstName, LastName, BirthDate, CellPhoneNumber, TelephoneNumber, Email)
	VALUES (1, 'Pieter', 'Du Toit', '1990/12/31', '+27824428419', NULL, 'Piet.toit@gmail.com'),
		   (3, 'Jan', 'Coetzee', '1983/06/27', '+27762931847', NULL, 'jantutoring@gmail.com'),
		   (5, 'San-Marie', 'Kritzinger', '1979/05/14', '+27761214222', NULL, 'kritzinger.s@gmail.com'),
		   (7, 'John', 'Smith', '1984/01/19', '+27714361997', NULL, 'john.growtoday@gmail.com'),
		   (9, 'Sam', 'Walker', '1993/09/09', '+27842431875', NULL, 'sam.w@gmail.com'),
		   (11, 'Kathy', 'Bellbottom', '1970/11/09', '+2714123322', NULL, 'bellb.kathy@yahoo.com'),
		   (13, 'Wielfred', 'Mekoa', '1991/03/12', '+27734175449', NULL, 'wielfredmekoa.marketing@gmail.com'),
		   (15, 'Delma', 'Tadiwa', '1995/05/22', '+27825539658', NULL, 'd.tadiwa@gmail.com'),
		   (17, 'Blessing', 'Moyo', '1988/07/25', '+27618824356', NULL, 'blessingmoyo@gmail.com')

GO

INSERT INTO Address (AddressID, Street, City, PostalCode, Province)
	VALUES (1, '961 Church St', 'Pretoria', '0155', 'Gauteng'),
		   (2, '127 Willowmore Street', 'Pretoria', '0182', 'Gauteng'),
		   (3, '1266 Diesel Street', 'Randfontein', '1767', 'Gauteng'),
		   (4, '1227 Glyn St', 'Philip Nel Park', '0183', 'Gauteng'),
		   (5, '1765 Hoog St', 'Brakpan', '1547', 'Gauteng'),
		   (6, '150 Derby Ave', 'Roodepoort', '1731', 'Gauteng'),
		   (7, '41 Schoeman St', 'Garsfontein', '0081', 'Gauteng'),
		   (8, '1470 Market St', 'Randpark Ridge', '2169', 'Gauteng'),
		   (9, '1453 Albert St', 'Tokoza Ext', '1426', 'Gauteng'),
		   (10, '903 President St', 'Johannesburg', '2110', 'Gauteng'),
		   (11, '2319 Dickens St', 'Tembisa', '1636', 'Gauteng'),
		   (12, '1425 Prospect St', 'Doornpoort', '0017', 'Gauteng'),
		   (13, '306 Broad Rd', 'De Deur', '1884', 'Gauteng'),
		   (14, '1051 Zigzag Rd', 'Vereeniging', '1939', 'Gauteng'),
		   (15, '1888 Wolmarans St', 'Bryanston', '2196', 'Gauteng'),
		   (16, '2293 Bodenstein St', 'Alberton', '1454', 'Gauteng'),
		   (17, '540 Wit Rd', 'Johannesburg', '2037', 'Gauteng'),
		   (18, '742 Church St', 'Centurion', '0149', 'Gauteng'),
		   (19, '458 Marconi St', 'Eldoradopark', '1832', 'Gauteng'),
		   (20, '853 Prospect St', 'Moreletapark', '0044', 'Gauteng')

GO
--Following is a list of different types of customers.
--Need-based customers :
--Loyal customers :
--Discount customers :
--Impulsive customers :
--Potential customers :
--New customers :
--Wandering customers :


INSERT INTO IndividualClient (IndividualClientID, Type, Status, Notes, AddressID)
	VALUES (1, 'New Customer', 'Active', 'The Client has started using PSS services in 2021', 1),
	       (9, 'Discount Customer', 'Active', 'The Client has been with PSS for years and is always on the lookout for a bargain', 2),
	       (15, 'Potential Customer', 'Inactive', 'A potential client from the 2020/08/13 conference meeting', 9)

GO
		   --Use even primary keys for business client
INSERT INTO BusinessClient (BusinessClientID, BusinessName, Type, Status, Notes, PrimaryContactPersonID, AddressID)
	VALUES (2, 'Renner Accounting Services', 'Loyal Customer', 'Active', 'Renner Accounting Services has been a loyal customer since 2005', 17, 3),
		   (4, 'Wielfred Marketing Agency', 'Wandering Customer', 'Active', 'The Wielfred marketing agency has abruptly stopped and changed printer contracts in the past', 13, 4),
		   (6, 'Personal Growth Consultations', 'New Customer', 'Active', 'Personal Growth Consultations is a small 1 man business who approached PSS in 2021', 7, 5);
		   --(8, 'Garsfontein High School', 'New Customer', 'Active', 'Garsfontein High School contacted PSS in 2021 and were reffered to by Personal Growth Consultations', , 7)

GO

INSERT INTO	BusinessClientPerson (BusinessClientID, PersonID, Role)
	VALUES (2,3, 'Head of computer/IT department'),
		   (2,5, 'Head of physical media/printing department'),
		   (2,17,'Receptionist'),
		   (2,9, 'Business Owner'),
		   (4,15,'Head of technical department (computers/printers)'),
		   (4,13,'Business Owner'),
		   (6,7,'Business Owner')
GO
--INSERT INTO ClientEntityContract (ContractID, ClientEntityID, EffectiveDate)
--	VALUES (10, 3, '2021/04/13');
--		   --(5, 9, '2021/04/04'),
--		   --(6, 9, '2021/04/18'),
--		   --(3, 2, '2021/04/02'),
--		   --(7, 2, '2021/04/02'),
--		   --(13, 4, '2021/04/02'),
--		   --(7, 4, '2021/04/02'),
--		   --(2, 4, '2021/04/15'),
--		   --(11, 6, '2021/04/02'),
--		   --(14, 8, '2021/04/02');
--GO
--Still have to add data for Service request portion, and followup
