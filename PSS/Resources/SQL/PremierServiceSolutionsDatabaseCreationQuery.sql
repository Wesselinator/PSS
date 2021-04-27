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

--USE master
--GO
--DROP DATABASE PremierServiceSolutionsDB

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
 FILENAME = 'C:\SQLServerDatabases\ PremierServiceSolutionsLogFile1.ldf',
 SIZE = 5MB,
 MAXSIZE = UNLIMITED,
 FILEGROWTH = 10MB
)
GO

USE PremierServiceSolutionsDB
GO

CREATE TABLE Service
(ServiceID INT PRIMARY KEY,
 ServiceName VARCHAR(30) NOT NULL,
 [Type] VARCHAR(30) NOT NULL,
 ServiceDescription VARCHAR(MAX) NOT NULL
)

CREATE TABLE Contract
(ContractID INT PRIMARY KEY,
 ContractName VARCHAR(45) NOT NULL,
 ServiceLevel VARCHAR(15) NOT NULL,
 OfferStartDate DATETIME NOT NULL,
 OfferEndDate DATETIME,
 ContractDurationInMonths INT NOT NULL CHECK(ContractDurationInMonths>0),
 MontlyFee MONEY NOT NULL
)

GO

ALTER TABLE Contract
ADD CONSTRAINT CK_OfferEndDateAfterStartDate CHECK(OfferEndDate>=OfferStartDate)

CREATE TABLE ServiceLevelAgreement
(ServiceID INT REFERENCES Service(ServiceID),
 ContractID INT REFERENCES Contract(ContractID),
 Agreement VARCHAR(MAX) NOT NULL,
 ServiceQuantity INT NOT NULL,
 PRIMARY KEY(ServiceID,ContractID)
)

--CREATE TABLE ContactInformation
--(ContactInformationID INT PRIMARY KEY,
-- CellPhoneNumber VARCHAR(12),
-- TelephoneNumber VARCHAR(12),
-- Email VARCHAR(320)
--)

GO

--ALTER TABLE ContactInformation
--ADD CONSTRAINT CK_AtLeastOneModeOfContact CHECK(CellPhoneNumber!=NULL OR TelephoneNumber!=NULL OR Email!=NULL)

CREATE TABLE Address
(AddressID INT PRIMARY KEY,
 Street VARCHAR(50) NOT NULL,
 City VARCHAR(30) NOT NULL,
 PostalCode CHAR(4),
 Province VARCHAR(20) NOT NULL
)

CREATE TABLE Person
(PersonID INT PRIMARY KEY,
 FirstName VARCHAR(50) NOT NULL,
 LastName VARCHAR(50) NOT NULL,
 BirthDate DATE,
 CellPhoneNumber VARCHAR(12),
 TelephoneNumber VARCHAR(12),
 Email VARCHAR(320)
)
GO

ALTER TABLE Person
ADD CONSTRAINT CK_AtLeastOneModeOfContact CHECK(CellPhoneNumber!=NULL OR TelephoneNumber!=NULL OR Email!=NULL)

CREATE TABLE [User]
(UserID INT PRIMARY KEY,
 UserName VARCHAR(50) NOT NULL,
 Password VARCHAR(50) NOT NULL,
 Role VARCHAR(50) NOT NULL
)

CREATE TABLE IndividualClient
(IndividualClientID INT REFERENCES Person(PersonID) PRIMARY KEY,
 Type VARCHAR(30) NOT NULL,
 Status VARCHAR(30) NOT NULL,
 Notes VARCHAR(MAX),
 AddressID INT NOT NULL REFERENCES Address(AddressID)
)

CREATE TABLE BusinessClient
(BusinessClientID INT PRIMARY KEY,
 BusinessName VARCHAR(50),
 Type VARCHAR(30) NOT NULL,
 Status VARCHAR(30) NOT NULL,
 Notes VARCHAR(MAX),
 AddressID INT NOT NULL REFERENCES Address(AddressID)
)

CREATE TABLE BusinessClientPerson
(BusinessClientID INT REFERENCES BusinessClient(BusinessClientID),
 PersonID INT REFERENCES Person(PersonID),
 Role VARCHAR(50) NOT NULL,
 --IsPrimaryContact BIT NOT NULL,
 PRIMARY KEY(BusinessClientID,PersonID)
)

--Remember to add instead of trigger such that a client can only have 1 active contract at a time

CREATE TABLE BusinessClientContract
(BusinessClientContractID INT PRIMARY KEY,
 ContractID INT NOT NULL REFERENCES Contract(ContractID),
 BusinessClientID INT NOT NULL REFERENCES BusinessClient(BusinessClientID),
 EffectiveDate DATETIME NOT NULL, 
)

CREATE TABLE IndividualClientContract
(IndividualClientContractID INT PRIMARY KEY,
 ContractID INT NOT NULL REFERENCES Contract(ContractID),
 IndividualClientID INT NOT NULL REFERENCES IndividualClient(IndividualClientID),
 EffectiveDate DATETIME NOT NULL, 
)

GO

CREATE TABLE FollowUpReport
(FollowUpReportID INT PRIMARY KEY,
 FollowUpTitle VARCHAR(80) NOT NULL,
 FollowUpType VARCHAR(20) NOT NULL,
 FollowUpDescription VARCHAR(MAX) NOT NULL,
 FollowUpDate DATETIME NOT NULL,
 IsIssueResolved BIT NOT NULL,
 SatisfactionLevel INT,
)

GO

CREATE TABLE IndividualClientFollowUp
(IndividualClientID INT NOT NULL REFERENCES IndividualClient(IndividualClientID),
 FollowUpReportID INT NOT NULL REFERENCES FollowUpReport(FollowUpReportID),
 PRIMARY KEY(IndividualClientID, FollowUpReportID)
)

CREATE TABLE BusinessClientFollowUp
(BusinessClientID INT NOT NULL REFERENCES BusinessClient(BusinessClientID),
 FollowUpReportID INT NOT NULL REFERENCES FollowUpReport(FollowUpReportID),
 PRIMARY KEY(BusinessClientID, FollowUpReportID)
)

GO

--CREATE TABLE FollowUpCall
--(FollowUpCallID INT PRIMARY KEY,
-- IsIssueResolved BIT NOT NULL,
-- SatisfactionLevel INT NOT NULL,
-- FollowUpReportID INT NOT NULL REFERENCES FollowUpReport(FollowUpReportID)
--)

CREATE TABLE ServiceRequest
(ServiceRequestID INT PRIMARY KEY,
 ServiceRequestTitle VARCHAR(80) NOT NULL,
 ServiceRequestType VARCHAR(20) NOT NULL,
 ServiceRequestDescription VARCHAR(MAX) NOT NULL,
 DateReceived DATETIME NOT NULL,
 AddressID INT REFERENCES Address(AddressID)
)

GO

CREATE TABLE BusinessClientServiceRequest
(BusinessClientID INT,
 ServiceRequestID INT,
 PRIMARY KEY(BusinessClientID,ServiceRequestID)
)
GO

CREATE TABLE IndividualClientServiceRequest
(IndividualClientID INT,
 ServiceRequestID INT,
 PRIMARY KEY(IndividualClientID,ServiceRequestID)
)

CREATE TABLE Task
(TaskID INT PRIMARY KEY,
 TaskTitle VARCHAR(80) NOT NULL,
 TaskType VARCHAR(20) NOT NULL,
 TaskDescription VARCHAR(MAX) NOT NULL,
 TaskNotes VARCHAR(MAX),
 ServiceRequestID INT NOT NULL REFERENCES ServiceRequest(ServiceRequestID),
 --AddressID INT REFERENCES Address(AddressID), --Add constaint to take business or indiviual client address as default
 DateProcessed DATETIME NOT NULL,
 IsFinished BIT NOT NULL DEFAULT 0
)
GO

-- This trigger will automatically insert the customer location as the default location where the service should be performed
--The Trigger will be moved to businessclientservicerequest and individualclient service request upon the next revision
CREATE TRIGGER trDefaultAddressForTask
ON ServiceRequest
FOR INSERT
AS
BEGIN
	DECLARE @serviceRequestID INT,@addressID INT
                    
    DECLARE cur CURSOR FAST_FORWARD READ_ONLY LOCAL FOR
        SELECT ServiceRequestID, AddressID
        FROM INSERTED
                    
    OPEN cur
                    
    FETCH NEXT FROM cur INTO @serviceRequestID,@addressID
                    
    WHILE @@FETCH_STATUS = 0
	BEGIN 
		SELECT ISNULL(@addressID,
			(SELECT bc.AddressID
			FROM ServiceRequest sr 
			JOIN BusinessClientServiceRequest bcsr
			ON sr.ServiceRequestID = bcsr.ServiceRequestID
			JOIN BusinessClient bc
			ON bcsr.BusinessClientID = bc.BusinessClientID
			UNION ALL
			SELECT ic.AddressID
			FROM ServiceRequest sr 
			JOIN IndividualClientServiceRequest icsr
			ON sr.ServiceRequestID = icsr.ServiceRequestID
			JOIN IndividualClient ic
			ON icsr.IndividualClientID = ic.IndividualClientID
			WHERE sr.ServiceRequestID=@serviceRequestID)
		)
		
		UPDATE ServiceRequest 
		SET AddressID = @addressID
		WHERE ServiceRequestID = @serviceRequestID;
        FETCH NEXT FROM cur INTO @serviceRequestID,@addressID                   
    END
                    
    CLOSE cur
    DEALLOCATE cur
	--IF SELECT AddressID FROM INSERTED
END

--SELECT bc.AddressID
--FROM ServiceRequest sr 
--JOIN BusinessClientServiceRequest bcsr
--ON sr.ServiceRequestID = bcsr.ServiceRequestID
--JOIN BusinessClient bc
--ON bcsr.BusinessClientID = bc.BusinessClientID
--UNION ALL
--SELECT ic.AddressID
--FROM ServiceRequest sr 
--JOIN IndividualClientServiceRequest icsr
--ON sr.ServiceRequestID = icsr.ServiceRequestID
--JOIN IndividualClient ic
--ON icsr.IndividualClientID = ic.IndividualClientID
--WHERE bc.AddressID=1 OR ic.AddressID=1

GO
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
 Status VARCHAR(30) NOT NULL,
 Notes VARCHAR(MAX),
 TechnicianTaskID INT NOT NULL REFERENCES TechnicianTask(TechnicianTaskID)
)
GO

CREATE TABLE CallInstance
(CallInstanceID INT PRIMARY KEY,
 StartTime DATETIME NOT NULL,
 EndTime DATETIME NOT NULL,
 Description VARCHAR(120) NOT NULL
)

CREATE TABLE CallChangeAssociation
(CallChangeAssociationID INT PRIMARY KEY,
 CallInstanceID INT NOT NULL REFERENCES CallInstance(CallInstanceID),
 TableName VARCHAR(30) NOT NULL,
 TableRecordID VARCHAR(MAX) NOT NULL
)
GO

--Can possibly Change Name To ProductOrService, add column for type
INSERT INTO Service (ServiceID, ServiceName, [Type], ServiceDescription)
	VALUES (1,'On Site Repairs','Service','This Service involves calling out a specialized technician to fix an issue with a product on the customer''s site'),
		   (2,'Pickup Repairs','Service','This Service involves fetching the product at the customer location and fixing it on PSS company grounds'),
		   (3,'Customer Phone Calls','Service', 'This service determines the kind of calling support customers enjoy from the call centre'),
		   (4,'Routine Phone Checkups','Service','This service determines the frequency of routine checkups performed with customers over the phone'),
		   (5,'Maintenance','Service','This service determines the frequency and extent of maintenance tasks performed on the product.'),
		   (6,'Product Replacement','Service','This service determines the conditions under which a product is entirely replaced'),
		   (7,'MSI Cubi N','Fat Client','Model 8GL-074EU/Celeron N5000/4GB/64GB SSD/UHD Graphics 600'),
		   (8,'Lenovo Ideapad','Laptop','Model S145/10th Gen Intel Core i5/15.6-inch/8GB RAM/1TB HDD'),
		   (9,'Dell Precision','Workstation Computer','Model T7920 Tower/2 x Intel Xeon Silver 4114/64GB RAM/256B NVME SSD/2TB HDD'),
		   (10,'HP Proliant','Server','Model DL360 Gen10/8-Bay 2.5" Server/Intel Xeon W-1290TE Processor (10 Cores, 20 Threads, 20MB Cache, up to 4.50 GHz)/256GB RAM/4x 4TB HDD'),
		   (11,'Canon Pixma','Printer','Model iX6840/Up to 50 pages per minute'),
		   (12,'HP LaserJet Pro','Printer','Model Number M130a/Up to 100 pages per minute'),
		   (13,'HP LaserJet Pro','Printer','Model Number M180c/Up to 200 pages per minute'),
		   (14,'Canon i-SENSYS','Printer','Model Number MF543X/Up to 300 pages per minute'),
		   (15,'HP Proliant','Server','Model Number DL380 Gen10/8-Bay 2.5" Server/Intel Xeon W-2295 Processor (18 Cores, 36 Threads, 24.75MB Cache, up to 4.60 GHz)/512GB RAM/8x 4TB HDD'),
		   (16,'HP Proliant','Server','Model Number DL390 Gen10/8-Bay 2.5" Server/AMD Epyc 7763 Processor (32 Cores, 64 Threads, 256MB Cache, up to 4.00 GHz)/512GB RAM/8x 4TB HDD'),
		   (17,'PSS Basic Workstation','Workstation Computer','Model Custom 2122/AMD RYZEN 5 3400G PRO (4 Cores, 8 Threads, 6MB Cache, Turbo 4.2GHz)/8GB RAM/256GB NVME SSD/1TB HDD'),
		   (18,'PSS Medium Workstation','Workstation Computer','Model Custom 2301/AMD RYZEN 5 3600 (6 Cores, 12 Threads, 35MB Cache, Turbo 4.2GHz)/16GB RAM/512GB NVME SSD/1TB HDD/Quadro P400'),
		   (19,'PSS High End Workstation','Workstation Computer','Model Custom 2531/AMD RYZEN 9 5950X (16 Cores, 32 Threads, 3.4GHz, 72MB Cache, Turbo 4.9GHz+)/32GB RAM/2TB NVME SSD/NVIDIA QUADRO P1000')
		   
INSERT INTO Contract (ContractID, ContractName, ServiceLevel, OfferStartDate, OfferEndDate, ContractDurationInMonths, MontlyFee)
	VALUES (1, 'Printing Necessities', 'Peasant', '2021/04/01', NULL, 36, 400),
		   (2, 'Basic Printing', 'Commoner', '2021/04/01', NULL, 36, 600),
		   (3, 'Premium Printing','Noble','2021/04/01',NULL,36, 900),
		   (4, 'Ultimate Printing','Feudal lord','2021/04/01',NULL,36, 1800),
		   (5, 'Individual Laptop Necessities','Peasant','2021/04/01',NULL,24, 400),
		   (6, 'Individual Computer Necessities','Peasant','2021/04/01',NULL,24, 400),
		   (7, 'Computer Lab Basics','Commoner','2021/04/01',NULL,48, 4000),
		   (8, 'Computer Lab Premium','Noble','2021/04/01',NULL,48, 6000),
		   (9, 'Computer Lab Super','Feudal lord','2021/04/01',NULL,36, 8000),
		   (10, 'Mini Office Combo','Peasant','2021/04/01',NULL,36, 450),
		   (11, 'Medium Office Combo','Commoner','2021/04/01',NULL,36,700),
		   (12, 'Maxi Office Combo','Noble','2021/04/01',NULL,36,850),
		   (13, 'Giant Office Combo','Feudal lord','2021/04/01',NULL,48,1200),
		   (14, 'Garsfontein High School Custom','Noble','2021/04/01',NULL,48,14200)

INSERT INTO ServiceLevelAgreement (ServiceID, ContractID, Agreement, ServiceQuantity)
	VALUES (11, 1, 'Lease to own',1),--valued at R 10 000
		   (1, 1, 'Applies to all issues not relating to water or electrical damage',-1),--negative 1 presents an unlimited amount of the service availible for the contract duration
		   (3, 1, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 4, thus a waiting time of up to 15 minutes may be incurred',-1),
		   (6, 1, 'Applies to product failure resulting from a production fault',-1),
		   
		   (12, 2, 'Lease to own',1),--valued at R 17 000
		   (1, 2, 'Applies to all issues not relating to water or electrical damage',-1),
		   (2, 2, 'Applies to all serious technical issues. Product can be expected to be fixed within 5 working days.',5),
		   (3, 2, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 3, thus a waiting time of up to 10 minutes may be incurred',-1),
		   (4, 2, 'To be carried out 1 week after all repairs',-1),
		   (6, 2, 'Applies to product failure resulting from a production fault',-1),
		   
		   (13, 3, 'Lease to own',1),--valued at R 25 000 each
		   (1, 3, 'Applies to all issues not relating to water or electrical damage',-1),
		   (2, 3, 'Applies to all serious technical issues. Product can be expected to be fixed within 3 working days. The product to be fixed will also be temporarily replaced',-1),
		   (3, 3, 'Applies to anytime, 24 hours every day of the week (Monday to Sunday). These phone calls will enjoy priority level 2, thus a waiting time of up to 5 minutes may be incurred',-1),
		   (4, 3, 'To be carried out 1 week after all repairs',-1),
		   (5, 3, 'To be carried out every 6 months for routine checkups on the product',-1),
		   (6, 3, 'Applies to product failure resulting from a production fault or any environmental events outside of the customer''s control per evidence basis.',-1),

		   (14, 4, 'Lease to own',1),--valued at R 40 000
		   (1, 4, 'Applies to any kind of product issues. If the issue cannot be resolved within 4 hours, the product will be replaced as per the replacement service',-1),
		   (3, 4, 'Applies to anytime, 24 hours every day of the week (Monday to Sunday). These phone calls will enjoy priority level 1, thus a maximum waiting time of up to 2 minutes may be incurred',-1),
		   (4, 4, 'To be carried out within 24 hours and after 1 week of all repairs',-1),
		   (5, 4, 'To be carried out every 3 months for routine checkups on the product',-1),
		   (6, 4, 'Applies to product failure resulting from unintentional cause as per evidence basis or in cases where the product cannot be repaired the customer''s premise',-1),

		   (8, 5, 'Lease to own',1),--valued at R 6000 each
		   (2, 5, 'Applies to all serious technical issues. Product can be expected to be fixed within 5 working days.',5),
		   (3, 5, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 4, thus a waiting time of up to 15 minutes may be incurred',-1),		   
		   (6, 5, 'Applies to product failure resulting from a production fault',-1),

		   (17, 6, 'Lease to own',1),--valued at R 6500 each
		   (2, 6, 'Applies to all serious technical issues. Product can be expected to be fixed within 5 working days.',5),
		   (3, 6, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 4, thus a waiting time of up to 15 minutes may be incurred',-1),		   
		   (6, 6, 'Applies to product failure resulting from a production fault',-1),

		   (7, 7, 'Lease to own',25),--valued at R 4000 each
		   (2, 7, 'Applies to all serious technical issues. Product can be expected to be fixed within 5 working days.',-1),
		   (3, 7, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 3, thus a waiting time of up to 10 minutes may be incurred',-1),		   
		   (5, 7, 'To be carried out every 6 months for routine checkups on the product system',-1),
		   (6, 7, 'Applies to product failure resulting from a production fault',-1),

		   (7, 8, 'Lease to own',40),--valued at R 4000 each
		   (15, 8, 'Lease to own',1),
		   (1, 8, 'Applies to all issues not relating to water or electrical damage',-1),
		   (2, 8, 'Applies to all serious technical issues. Product can be expected to be fixed within 3 working days.',-1),
		   (3, 8, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 2, thus a waiting time of up to 5 minutes may be incurred',-1),		   
		   (5, 8, 'To be carried out every 3 months for routine checkups on the product system',-1),
		   (6, 8, 'Applies to product failure resulting from a production fault',-1),

		   (7, 9, 'Lease to own',60),--valued at R 4000 each
		   (16, 9, 'Lease to own',1),--valued at R 40000
		   (1, 9, 'Applies to any kind of product issues. If the issue cannot be resolved within 4 hours, the product will be replaced as per the replacement service',-1),
		   (3, 9, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 1, thus a waiting time of up to 2 minutes may be incurred',-1),		   
		   (5, 9, 'To be carried out every 2 months for routine checkups on the product system',-1),
		   (6, 9, 'Applies to product failure resulting from a production fault or inability to repair product on customer premise',-1),

		   (17, 10, 'Lease to own',1),--valued at R 6500 each
		   (11, 10, 'Lease to own',1),--valued at R 4000
		   (1, 10, 'Applies to all issues not relating to water or electrical damage',-1),
		   (2, 10, 'Applies to all serious technical issues. Product can be expected to be fixed within 5 working days.',-1),
		   (3, 10, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 4, thus a waiting time of up to 15 minutes may be incurred',-1),		   
		   (6, 10, 'Applies to product failure resulting from a production fault',-1),

		   (18, 11, 'Lease to own',1),--valued at R 9000
		   (12, 11, 'Lease to own',1),--valued at R 6000
		   (1, 11, 'Applies to all issues not relating to water or electrical damage',-1),
		   (2, 11, 'Applies to all serious technical issues. Product can be expected to be fixed within 3 working days.',-1),
		   (3, 11, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 3, thus a waiting time of up to 10 minutes may be incurred',-1),		   
		   (6, 11, 'Applies to product failure resulting from a production fault',-1),

		   (19, 12, 'Lease to own',1),--valued at R 16000
		   (13, 12, 'Lease to own',1),--valued at R 8000
		   (1, 12, 'Applies to all issues not relating to water or electrical damage',-1),
		   (2, 12, 'Applies to all serious technical issues. Product can be expected to be fixed within 3 working days. The product to be fixed will also be temporarily replaced',-1),
		   (3, 12, 'Applies to anytime, 24 hours every day of the week (Monday to Sunday). These phone calls will enjoy priority level 2, thus a waiting time of up to 5 minutes may be incurred',-1),		   
		   (6, 12, 'Applies to product failure resulting from a production fault',-1),

		   (19, 13, 'Lease to own',1),--valued at R 20000
		   (7, 13, 'Lease to own',4),--valued at R 16000
		   (13, 13, 'Lease to own',1),
		   (1, 13, 'Applies to any kind of product issues. If the issue cannot be resolved within 4 hours, the product will be replaced as per the replacement service',-1),
		   (3, 13, 'Applies to anytime, 24 hours every day of the week (Monday to Sunday). These phone calls will enjoy priority level 1, thus a maximum waiting time of up to 2 minutes may be incurred',-1),		   
		   (6, 13, 'Applies to product failure resulting from a production fault or inability to repair product on customer premise',-1),

		   (7, 14, 'Lease to own',120),
		   (10, 14, 'Lease to own',4),
		   (1, 14, 'Applies to any kind of product issues. If the issue cannot be resolved within 4 hours, the product will be replaced as per the replacement service',-1),
		   (3, 14, 'Applies to specified working hours (Monday to Friday 8am to 8pm). These phone calls will enjoy priority level 1, thus a waiting time of up to 2 minutes may be incurred',-1),
		   (5, 14, 'To be carried out every every month for routine checkups on the product system',-1),
		   (6, 14, 'Applies to product failure resulting from a production fault or inability to repair product on customer premise',-1)

GO
INSERT INTO Person (PersonID, FirstName, LastName, BirthDate, CellPhoneNumber, TelephoneNumber, Email)
	VALUES (1, 'Pieter', 'Du Toit', '1990/12/31', '+27824428419', NULL, 'Piet.toit@gmail.com'),
		   (2, 'Jean', 'Van Rensburg', '1985/07/21', '+27762931242', NULL, 'jeanvrens@gmail.com'),
		   (3, 'Jan', 'Coetzee', '1983/06/27', '+27762931847', NULL, 'jantutoring@gmail.com'),
		   (4, 'Blake', 'Thompson', '1990/05/13', '+27862342231', NULL, 'b.thompson@gmail.com'),
		   (5, 'San-Marie', 'Kritzinger', '1979/05/14', '+27761214222', NULL, 'kritzinger.s@gmail.com'),
		   (6, 'Nigel', 'Ozark', '1990/06/04', '+27720542344', NULL, 'nigel.ozark90@gmail.com'),
		   (7, 'John', 'Smith', '1984/01/19', '+27714361997', NULL, 'john.growtoday@gmail.com'),
		   (9, 'Sam', 'Walker', '1993/09/09', '+27842431875', NULL, 'sam.w@gmail.com'),
		   (11, 'Kathy', 'Bellbottom', '1970/11/09', '+2714123322', NULL, 'bellb.kathy@yahoo.com'),
		   (13, 'Wielfred', 'Mekoa', '1991/03/12', '+27734175449', NULL, 'wielfredmekoa.marketing@gmail.com'),
		   (15, 'Delma', 'Tadiwa', '1995/05/22', '+27825539658', NULL, 'd.tadiwa@gmail.com'),
		   (17, 'Blessing', 'Moyo', '1988/07/25', '+27618824356', NULL, 'blessingmoyo@gmail.com')

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

INSERT INTO [User] (UserID, UserName, Password, Role)
	VALUES (11, 'KathyB', 'Admin', 'Admin');

INSERT INTO Technician (TechnicianID, Speciality, PayRate)
	VALUES (2, 'Printers', 500),
		   (4, 'Computers', 600),
		   (6, 'Servers', 1000);

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
		  
INSERT INTO BusinessClient (BusinessClientID, BusinessName, Type, Status, Notes, AddressID)--will add the primary contact person id after discussion
	VALUES (2, 'Renner Accounting Services', 'Loyal Customer', 'Active', 'Renner Accounting Services has been a loyal customer since 2005', 3),
		   (4, 'Wielfred Marketing Agency', 'Wandering Customer', 'Active', 'The Wielfred marketing agency has abruptly stopped and changed printer contracts in the past', 4),
		   (6, 'Personal Growth Consultations', 'New Customer', 'Active', 'Personal Growth Consultations is a small 1 man business who approached PSS in 2021', 5),
		   (8, 'Garsfontein High School', 'New Customer', 'Active', 'Garsfontein High School contacted PSS in 2021 and were reffered to by Personal Growth Consultations', 7)

INSERT INTO	BusinessClientPerson (BusinessClientID, PersonID, Role)
	VALUES (2,3, 'Head of computer/IT department'),
		   (2,5, 'Head of physical media/printing department'),
		   (2,17,'Receptionist'),
		   (2,9, 'Business Owner'),
		   (4,15,'Head of technical department (computers/printers)'),
		   (4,13,'Business Owner'),
		   (6,7,'Business Owner')

INSERT INTO IndividualClientContract (IndividualClientContractID, ContractID, IndividualClientID, EffectiveDate)
	VALUES (1,10, 1, '2021/01/13'),
		   (2,5, 9, '2021/01/04'),
		   (3,6, 9, '2021/02/18');

INSERT INTO BusinessClientContract (BusinessClientContractID, ContractID, BusinessClientID, EffectiveDate)
	VALUES (1,7, 2, '2020/04/02'),
		   (2,13, 4, '2019/01/02'),
		   (3,11, 6, '2021/01/13'),
		   (4,14, 8, '2019/04/02');
GO

INSERT INTO ServiceRequest (ServiceRequestID, ServiceRequestTitle, ServiceRequestType, ServiceRequestDescription, DateReceived)
	VALUES (1, 'Fix Broken Printer', 'Client Requested', 'HP printer Model Number M130a not printing, its displays error code 50','2021/04/04'),
		   (2, 'Fix Fat client Broken Wifi', 'Routine Maintenance', 'MSI Cubi N Model 8GL-074EU wifi not working','2021/04/15'),
		   (3, 'Routine maintenance on computer lab', 'Routine Maintenance', 'Perform maintenance tasks on computer lab computers per contract agreement.','2021/04/15'),
		   (4, 'Fix 3x Broken Computers in computer lab', 'Client Requested', 'Serious "fan" noise comming from 3x computers in computer lab. 2x of these computers also suffer from random restarts','2021/04/16'),
		   (5, 'Routine maintenance on computer lab', 'Routine Maintenance', 'Perform maintenance tasks on computer lab computers. Availible times for client include 2pm to 5pm Monday to Friday','2021/04/15'),
		   (6, 'Fix or Replace Broken PC', 'Client Requested', 'Computer does not turn and cannot boot into diagnostic mode','2021/04/17'),
		   (7, 'Pickup Repair for 2x faulty fat clients', 'Technician Requested', 'Fat clients suffer from random restarts, errors include "IRQL NOT LESS OR EQUAL" and "KERNAL SECURITY CHECK FAILURE". Harddrive, Fan and CPU temperatures are healthy','2021/04/19')

INSERT INTO BusinessClientServiceRequest (BusinessClientID, ServiceRequestID)
	VALUES (2, 2),
		   (2, 3),
		   (4, 5),
		   (6, 1),
		   (8, 4)

INSERT INTO IndividualClientServiceRequest (IndividualClientID, ServiceRequestID)
	VALUES (1, 6);

INSERT INTO Task (TaskID, TaskTitle, TaskType, TaskDescription, TaskNotes, ServiceRequestID, DateProcessed, IsFinished)
	VALUES (1, 'Repair hardware issue on HP printer model M130a', 'Hardware Repair', 'Printer error code 50 reports a hardware problem. Attempt or fix, if not repairible on the customer site, schedule pickup repair', 'Enter customer site from back door', 1, '2021/04/05', DEFAULT),
		   (2, 'Fix wifi Issue on MSI Cubi N Model 8GL-074EU', 'Hard/Software Repair', 'Wifi/Bluetooth card may be faulty or misconfigured on a software or harware level', NULL, 2,'2021/04/17', DEFAULT),
		   (3, 'Routine hardware maintenance 25x MSI Cubi N Model 8GL-074EU', 'Hardware Maintanence', 'Clean fat clients. Inspect and report health of CPU, RAM, HDD. Repaste CPU if idle temperatures above 55°C', NULL, 3, '2021/04/17', DEFAULT),
		   (4, 'Routine software maintenance 25x MSI Cubi N Model 8GL-074EU', 'Software Maintanence', 'Run PSS registry cleaner, run PSS antivirus, ensure Windows and Office is activited', NULL, 3, '2021/04/17', DEFAULT),
		   (5, 'Diagnose and repair 3x problematic MSI Cubi N Model 8GL-074EU', 'Hard/Software Repair', 'All 3 Fat clients are noisy, 2 suffer from random restarts. Possible Fan, HDD or device driver problem', 'If issue not resolved, schedule pickup repair', 4, '2021/04/17', DEFAULT)

INSERT INTO TechnicianTask (TechnicianTaskID, TechnicianID, TaskID, TimeToArrive)
	VALUES (1, 2, 1, '2021/04/06 14:00:00'),
		   (2, 4, 2, '2021/04/18 09:00:00'),
		   (3, 2, 3, '2021/04/18 09:00:00'),
		   (4, 4, 4, '2021/04/18 09:00:00'),
		   (5, 6, 5, '2021/04/18 09:00:00')

INSERT INTO TechnicianTaskFeedback (TechnicianTaskFeedbackID, TimeArrived, TimeDeparture, Status, Notes, TechnicianTaskID)
	VALUES (1, '2021/04/06 13:50:00', '2021/04/06 14:30:00', 'Successful', 'HP printer model M130a Laserjet Imaging Drum required cleaning', 1),
		   (2, '2021/04/18 09:15:00', '2021/04/18 10:20:00', 'Successful', 'MSI Cubi N Model 8GL-074EU wifi/bluetooth m.2 card replaced (Intel AX201NGW WIFI6 Wireless Network Card M.2)', 2),
		   (3, '2021/04/18 08:55:00', '2021/04/18 13:50:00', 'Successful', 'Routine hardware maintenance performed successfully as per task description', 3),
		   (4, '2021/04/18 08:55:00', '2021/04/18 13:50:00', 'Successful', 'Routine software maintenance performed successfully as per task description', 4),
		   (5, '2021/04/18 08:50:00', '2021/04/18 13:50:00', 'Incomplete', 'Detected a driver issue with pc 1 and managed to resolve this issue, however the other 2 pcs could not been fixed. These 2 computers display healthy HDDs, have clean/lubricated fans and do not display any device driver anomalies. I have therefore created a service request for a pick-up repair', 5)

INSERT INTO FollowUpReport (FollowUpReportID, FollowUpTitle, FollowUpType, FollowUpDescription, FollowUpDate, IsIssueResolved, SatisfactionLevel)
	VALUES (1, 'HP printer model M130a Laserjet Imaging Drum cleaned', 'Post-Repair', 'Followup with client to ensure printer is still working properly', '2021/04/13 10:00:00', 1, 5),
		   (2, 'Technician arrived 15 minutes late', 'Complaint', 'Client was unsatisfied with time of arrival of technician Blake. Contact technician with id 4 with regards to task with id 2', '2021/04/18 11:00:00', 1, 3),
		   (3, 'Routine hardware and software maintenance performed', 'Post-Repair', 'Followup with client to ensure computers are still working properly', '2021/04/25 12:00:00', 1, 4),
		   (4, '1 Of 3 PCs fixed', 'Post-Repair', 'Followup with client to ensure they understand why not all PCs was able to be fixed on their premise', '2021/04/18 14:52:00', 0, 4)

INSERT INTO BusinessClientFollowUp (BusinessClientID, FollowUpReportID)
	VALUES (6, 1),
		   (2, 2),
		   (2, 3),
		   (8, 4)

INSERT INTO CallInstance (CallInstanceID, StartTime, EndTime, Description)
	VALUES (1, '2021/04/13 10:00:00', '2021/04/13 10:12:23', 'Duration 12:23 minutes'),
		   (2, '2021/04/18 11:00:00', '2021/04/18 11:17:04', 'Duration 17:04 minutes'),
		   (3, '2021/04/25 12:00:00', '2021/04/25 12:05:12', 'Duration 05:12 minutes'),
		   (4, '2021/04/18 14:52:00', '2021/04/18 15:03:05', 'Duration 11:05 minutes')

--SELECT te.TechnicianID, P.FirstName 'IndividualClientFirstName', bc.BusinessName, 
--FROM Person p
--JOIN IndividualClient ic
--ON p.PersonID = ic.IndividualClientID
--JOIN Address a
--ON ic.AddressID = a.AddressID
--JOIN BusinessClient bc
--ON a.AddressID = bc.AddressID
--JOIN ServiceRequest sr
--ON sr.ClientEntityID=bc.BusinessClientID OR sr.ClientEntityID=ic.IndividualClientID
--JOIN Task t
--ON sr.ServiceRequestID = t.ServiceRequestID
--JOIN TechnicianTask tt
--ON t.TaskID = tt.TaskID
--JOIN Technician te
--ON tt.TechnicianID = te.TechnicianID
--JOIN TechnicianTaskFeedback ttf
--ON tt.TechnicianTaskID = ttf.TechnicianTaskID



--SELECT * FROM Service


--SELECT TOP 1 sr.ServiceRequestID,
--CASE
--	WHEN t.TaskID IS NULL THEN 1
--	WHEN tt.TechnicianTaskID IS NULL THEN 2
--	WHEN ttf.TechnicianTaskFeedbackID IS NULL THEN 3
--	WHEN ttf.TechnicianTaskFeedbackID IS NOT NULL THEN 4
--END 'ProgressLevel',
--CASE
--	WHEN t.TaskID IS NULL THEN 'Service Request Received'
--	WHEN tt.TechnicianTaskID IS NULL THEN 'Service Request Processed Into Task'
--	WHEN ttf.TechnicianTaskFeedbackID IS NULL THEN 'Task Has Been Assigned To A Technian Who Is Due To Arrive At '+tt.TimeToArrive
--	WHEN ttf.TechnicianTaskFeedbackID IS NOT NULL THEN 'Task Addressed By Technician. Task Current Status:\n'+ ttf.Status
--END 'Progress'
--FROM ServiceRequest sr
--LEFT JOIN Task t
--ON sr.ServiceRequestID = t.ServiceRequestID
--LEFT JOIN TechnicianTask tt
--ON t.TaskID = tt.TaskID
--LEFT JOIN TechnicianTaskFeedback ttf
--ON tt.TechnicianTaskID = ttf.TechnicianTaskID
--WHERE sr.ServiceRequestID=0 
--ORDER BY t.DateProcessed DESC, ProgressLevel DESC --lastest dateprocessed first


--INSERT INTO BusinessClient (BusinessClientID, BusinessName, Type, Status, Notes, AddressID)
--	VALUES (1, 'JP', 'Executive', 'Active', 'Valued customer', 0);

