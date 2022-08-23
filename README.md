# Pierre's Sweet and Savory Treats

#### A bakery application that uses Identity to allow users to login and manipulate many to many relationships

#### Created By: Alex Shevlin

## Technologies Used

* C#
* .NET 5
* NuGet
* ASP.NET Core
* Entity Framework Core
* ASP.NET MVC Identity
* MySql
* MySql Workbench

## Description

This project was created to show proficiency in Authentication with Identity. This application is for a bakery, allowing the user to log different treats and their flavors. The user must login to manipulate many to many relationships between treats and flavors.

Project requirements:
- Full CRUD implemented for at least one class
- Many to many relationship viewable from both sides
- Users can log in and log out with Identity
- Create, Update, and Delete are limited to logged in users

Authentication Features:
- Anyone can access the index and details views
- Only authenticated users can access the Create, Update, Delete views
- The buttons on the navbar, Details and Index pages (for Treats and Flavors) change depending on authentication status

## Setup and Usage Instructions

### Technology Requirements

* Download and install [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* Download and install a code text editor. Ex: [VS Code](https://code.visualstudio.com/)
* Download, install, and complete setup for [MySql Community Server](https://dev.mysql.com/downloads/file/?id=484914) and [MySql Workbench](https://dev.mysql.com/downloads/file/?id=484391).

### Installation

* Clone [this](https://github.com/a-shevlin/Treats.Solution) repository, or download and open the Zip on your local machine
* Open the Treats.Solutions folder in your preferred text editor
* To install required packages, navigate to Treats.Solutions/Treats in the terminal and type the following commands:
  - dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0
  - dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2
  - dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0
  - dotnet tool install --global dotnet-ef --version 3.0.0
  - dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0
* Create a file named "appsettings.json" in the Treats directory
  - add the following code to the appsettings.json file:
  ```
  {
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=alex_shevlin;uid=root;pwd=[YOUR-PASSWORD-HERE];"
    }
  }
  ```
  - replace [YOUR-PASSWORD-HERE] with your unique MySql password
* Launch the MySql server:
  - In the terminal, run the command "$ mySql -uroot -p[YOUR-PASSWORD-HERE]", replacing [YOUR-PASSWORD-HERE] with your unique MySql password
* To Import the required database:
   - In the terminal, navigate to Treats.Solution/Treats and run the command:
    - dotnet ef database update
* To Make Changes to the Database:
  - If you would like to change the database, make changes in the proper models files, then run the following commands in the terminal navigated to Treats.Solution/Treats:
    - "dotnet ef migrations add YourDescriptionHere"
    - "dotnet ef database update"
* To Restore, build, and run the project:
  - Navigate to the Treats.Solutions/Treats folder in the command line or terminal
    - Run the command "$ dotnet restore" to restore the project dependencies
    - Run the command "$ dotnet build" to build and compile the project
    - Run the command "$ dotnet run" to build and compile the project

## Known Bugs

* none at this time

## License

[GNU](/LICENSE-GNU)

Copyright (c) 2022 Alex Shevlin