# Hair Salon Manager

### Description
Create an MVC web application for a hair salon. The owner should be able to add a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist.

User Stories
* As a salon employee, I need to be able to see a list of all our stylists.
* As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As an employee, I need to add new stylists to our system when they are hired.
* As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.

### Setup
Make sure you have Net Core, Mono & MAMP all installed.

Instructions to recreate database in MySQL prompt:
```
CREATE DATABASE clara_munro;
USE clara_munro;
CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);
```
```
CREATE DATABASE clara_munro_test;
USE clara_munro_test;
CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);
```

* git clone this repository: https://github.com/claramunro/HairSalon.Solution.git
* cd HairSalon.Solution/Hairsalon

Install the .NET packages & run the program inside the HairSalon directory
* dotnet restore
* dotnet build
* dotnet run

* go to your browser port "http://localhost:5000".


### Technologies Used
* C#, .NET, HTML, Razor, MySQL

### Support and contact details
* clarajmunro@gmail.com

### Known Bugs
* None

### License
* MIT License
