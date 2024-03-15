This project was devoleped for PDM Technologies group.
Of of the many production that PDM technology group provieds to is useser,
is a Bluestar wich is an integrated part of Microsoft Dynamics 365 Finance.
to simplifi the product. it manages 3d drawings, and clisifies them as a part or an assembly (item or list item).
a motor for example can be an assembly with multiable parts, wich is a refrence to the same bolt 3d drawing.
and the drawings can be extended with further data/information about them.

With the Bluestar program in mind, a large part of the workload is to do with customers.
spesificly converting/intergrating/restructuring their existing data to a new database.
and with that alot of people in the company are tasked with this.
so this project seeks to automate that process, or at the very least lessen the work load for the people involved.

that vision come into play by giveing the customers access to impliment/edit their own data,
in the form of an uploadable spreadsheet, wich then can be converted to a sequal or similar database at a later state.


the project consist of
* SQL database for filemanagement, login, extended user information
* c# project for file management / logic / dataaccess,
* Blazor frontend using devexpress to look/feel similar to PDM technology groups other product.
the project accounts for concurrentcy issues of interactions with same file/same row and others.
it also using authentization state manager to identify same user, but with multiable tabs, and diffrent users.
and with logout all useres when one instance logs out.

this project is extensive in features so i proberly can list them all. but its one of my more refined projects.

to run this project you do need to install devexpress.
beond that. login is temperaryly disabled as filemanagement is getter an overhaul.
more features to come.
