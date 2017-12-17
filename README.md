# WilliamHill.Website

Overview:

I suprisingly did not notice that the provided endpoints were implemented, it was my assumption that they were only there as a guideline for
naming conventions so I went ahead and designed a database model using Entity Framework code-first.

My initial model looked like this:

------------------                             -------------------
| Race           |                             | Horse           |
|-----------------                             |------------------
| ID (int)       |                             | ID (int)        |
| Name (string)  |   <---- Many to Many ---->  | Name (string)   |
| Date (DateTime)|                             | Odds (double)   |
| Status (Enum)  |                             |                 |
------------------                             -------------------



-----------------  
HorseRace (Join)|
-----------------  
| RaceID (int)  |
| HorseID (int) |
|               |
|               |
-----------------  
        |
        | One to One
        V
-------------------                            ---------------------
| Bet             |                            | Customer          |
|------------------                            |--------------------
| ID (int)        |                            | ID (int)          |
| Name (string)   |   <---- Many to One ----   | FirstName (string)|
| CustomerID (int)|                            | LastName (string) |
| HorseRace (obj) |                            |                   |
-------------------                            ---------------------

I then proceeded to seed the database using an initializer, I ran into some logical problems with the HorseRace/Bet relationship
which I decided to resolve later.

I went on to design a WEB API that would use the database, perform CRUD operations and run JOIN queries.

I ran into some CORS issues between my API and website using localhost but they didn't take long to resolve. At that point I started working
on the front-end using React. At some point I realised that the provided endpoints were there for a reason... oops!

After re-designing my application to consume the given endpoints and removing all unecessary logic I started running out of time so I 
decided to use Knockout.js and JQuery for the front-end part to speed things up.


Improvements:

Front-End

1) Write in React.js
2) Improve the Date format
3) Add currency formating to appropriate columns
4) Improve styling

Back-End

1) Some controller logic can be moved into re-usable methods.
2) Logging
3) Additional testing
4) Data persistence


Solution:

Task 1)

a) Implemented
b) Implemented, would be much easier using a database to achieve the desired result instead of calculating manually
c) Implemented, click on any row to expand the horse list
d)
	i) Implemented
	ii) Implemented, would be much easier using a database to achieve the desired result instead of calculating manually
	iii) Implemented, my understanding of betting is limited so I hope I got this right, as with above would be much easier using a database to calculate

Task 2)
	a) Implemented
	b) Implemented
	c) Implemented
	d) Implemented
	e) Implemented, I regret not re-using code for this one.
	

Regrets:

I should have been comitting to the repository more often, many iterations of my solution did not get recorded because I didn't do this.