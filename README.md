# Crossover-Assignment-National-Criminals-Database
My solution for Crossover assignment National Criminals Database

# Used technologies:
## Frameworks and Nugets:
	ASP.Net MVC 5
	HTML 5
	WCF
	Entity Framework 6
	Microsoft.AspNet.Identity
	Unity (Dependency injection framework)
	Moq (Unit testing framework)
	IronPdf (PDF library)
## Tools:
	Microsoft Visual Studio Community 2015
	Microsoft SQL Server 2014
	IIS Express

# Solution structure:
## This solution consists of 4 projects (The web project, the service project and test project for each of them):
	NationalCriminalsDB: The Asp.Net MVC web project
	NationalCriminalsDB.Service: The WCF service project
	NationalCriminalsDB.Service.Test: The unit tests of the WCF service project
	NationalCriminalsDB.Tests: The unit test of the Asp.Net MVC web project

# Getting started:
First of all you need to make sure that all the tools mentioned in the first section are installed and working fine on your machine.
## Before running the solution:
	1- Restore the solution Nugets and make sure that all references are ok.
	2- Add the server to the connection string in the “Web.config” file of the “NationalCriminalsDB.Service” and the “NationalCriminalsDB” projects.
	3- Fill the values of these keys “SMTPHost”, “GmailId” and “GmailPswrd” in the “Web.config” file of the service project
	4- Run all the unit test to make sure that everything is working as it should. (As shown in the demo video all my unit tests pass).
	5- After building the solution update the service reference in the “NationalCriminalsDB” project.
## Notes:
	1-	This is a code first solution so you don’t have to execute the “script.sql” file. In the “Package Manager Console” run these commands to create the database and add the initial data:
		Update-Database –Project NationalCriminalsDB
		Update-Database –Project NationalCriminalsDB.Service
	2- Make sure that you enabled the access of untrusted applications feature in the used email as the “GmailId” (that the system uses to send emails)
	3- Make sure that you run both projects “NationalCriminalsDB” and “NationalCriminalsDB.Service” (from the solution properties select “multiple startup projects” and chose start for each of the 2 project).

# Assumptions:
	- The system uses a Gmail account to send emails
	- The criminal has many crimes in his/her criminal history and the crime can be committed by multiple criminals
	- I ignored the crime severity and if the criminal has finished, not yet started or in progress of doing his punishment.
	- I ignored the current status of the criminal (dead or alive)
	- Locations are just strings not (countries, states and locations) entities. So searchable addresses are: California, Munich, Cairo, Quebec, London, Paris and Washington DC. Any other address won’t return any found data. (of course if you change the initial data in the “Configuration” class in the “Migrations” folder in the “NationalCriminalsDB.Service” project and add or change addresses, or any other data, and submit it to the database that list will vary accordingly).
