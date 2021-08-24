#### Table of Contents
- 1 TheMatrixAPI
  - 1.1 Overview
  - 1.2 Functionalities and Roles
- 2 Architecture
- 3 Technology Stack

# TheMatrixAPI

TheMatrixAPI is my defense project for Softuni ASP.NET Core course, part of the C# Web module. 
The software is powered by ASP.NET Core MVC backend and supports a MSSQL database. The project overview, functionalities, architecture and technology stack is reviewed bellow.  
![Screenshot](public/TheMatrixAPI.png?raw=true "TheMatrixAPI")

## :pencil: Overview

TheMatrixAPI is the world's first quantified and programmatically-formatted set of The Matrix data.  
If you do not register, you will be able to submit up to 100 requests per day to https://thematrixapi.com
### How can you register?
Register online in a few simple steps by visiting the matrix api website page. Submit your:  
:pushpin: EGN  
:pushpin: First, Middle and Last Name  
:pushpin: Phone Number  
:pushpin: User Name  
:pushpin: E-mail  
:pushpin: Password  

After you register successfully, you will become a user and you will be able to:  
:pushpin: Get personal token id - used for API calls  
:pushpin: Submit up to 10 000 requests per month  

## :computer: Functionalities and Roles
TheMatrixAPI offers two roles - User and Admin.
### :pushpin: Role User  
### :pushpin: Home Page - call TheMatrixAPI via AJAX requests  
![Screenshot](public/tryitnow.png?raw=true "TryItNow")
### :pushpin: About Page  
![Screenshot](public/aboutpage.png?raw=true "AboutPage")
### :pushpin: Documentation Page  
![Screenshot](public/documentationpage.png?raw=true "DocumentationPage")
### :pushpin: Role Admin  
![Screenshot](public/roleadmin.png?raw=true "RoleAdmin")
### :pushpin: Movies Page - CRUD operations  
![Screenshot](public/moviespage.png?raw=true "MoviesPage")
### :pushpin: Actors Page - CRUD operations
![Screenshot](public/actorspage.png?raw=true "ActorsPage")
### :pushpin: Characters Page - CRUD operations  
![Screenshot](public/characterspage.png?raw=true "CharactersPage")
### :pushpin: Quotes Page - CRUD operations  
![Screenshot](public/quotespage.png?raw=true "QuotesPage")
### :pushpin: Races Page - CRUD operations  
![Screenshot](public/racespage.png?raw=true "RacesPage")

# :hammer: Architecture
TheMatrixAPI based on the .NET technology stack.
The platform communicates with MSSQL database via service layer.

# :gear: Technology Stack
- C# and .NET 5 MVC
- JS, HTML, CSS, Bootstrap
- Razor View Engine
- MSSQL Server