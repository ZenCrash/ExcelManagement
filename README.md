This project was developed as a proof of concept for PDM Technologies group.
Of the many production that PDM technology group provieds to its users,
one of them is Bluestar wich is an integrated part of Microsoft Dynamics 365 Finance.
to simplify the product. it manages 3d drawings, and classifies them as a part or an assembly (relational files).

With Bluestar program in mind, a large part of the workload is to do with customers.
specifically converting/integrating/restructuring their existing data to a new database.
and with that alot of people in the company are tasked with this.
so this project seeks to automate that process, or at the very least lessen the workload for the people involved.

That vision come into play by giving the customers access to implement/edit their own data,
in the form of an uploadable spreadsheet, which then can be converted to a sequal or similar database at a later state.

the project features:
* SQL database for filemanagement, login, extended user information.
* C# project for file management / logic / dataaccess,
* Blazor frontend using devexpress to look/feel similar to PDM technology groups other product.
the project accounts for concurrency issues of interactions with file management.
It also uses authentication state manager to identify same user, but with multiple tabs, and different users. and with logout all useres when one instance logs out.

this project is extensive in features so i probably can list them all.
that being said some of the features are more proof of concept so we thet may not be fully implemented.

<img scr="https://i.ibb.co/tKByDhC/excelmanagement"/>

Requirements:
* Microsoft Visual Studio
* MSSQL or similar sequel database.

Installation:
* Install Devexpress from https://www.devexpress.com/products/try/
* Install MSSQL.
* Open project, and in the package manager console, type “update-database”, and press enter. 
