Student Grade Management System
Author
Gabrielle Aragon Zabala

Technologies Used
ASP.NET Core Web API
ASP.NET Core MVC
SQL Server
Entity Framework Core
ASP.NET Core Identity
Postman
Faculty Account
Email: faculty@test.com

Password: Faculty123!

Student Account
Email: student@test.com

Password: Student123!

Faculty Permissions
View Grades
Create Grades
Update Grades
Delete Grades
Student Permissions
View Own Grades Only
Students Cannot:

Create Grades
Update Grades
Delete Grades
View Other Student Records
API Endpoints
Authentication

POST /api/auth/login

POST /api/auth/logout

Grades

GET /api/grades

GET /api/grades/{id}

POST /api/grades

PUT /api/grades/{id}

DELETE /api/grades/{id}

Student

GET /api/student/grades

Completed Features
Grade CRUD
Validation
Automatic Remarks
MVC Dashboard
Fetch API
Authentication
Authorization
Student Ownership Security
Postman Testing