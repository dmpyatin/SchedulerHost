/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\InsertData\Faculties.sql
:r .\InsertData\Departments.sql
:r .\InsertData\Specialities.sql
:r .\InsertData\Courses.sql
:r .\InsertData\Groups.sql
:r .\InsertData\Ranks.sql
:r .\InsertData\Lecturers.sql
:r .\InsertData\TutorialTypes.sql
:r .\InsertData\Tutorials.sql
:r .\InsertData\Building.sql
:r .\InsertData\Auditories.sql
:r .\InsertData\Times.sql
:r .\InsertData\WeekTypes.sql