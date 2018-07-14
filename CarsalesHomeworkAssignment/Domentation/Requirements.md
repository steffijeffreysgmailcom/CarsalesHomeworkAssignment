# CarsalesHomeworkAssignment
A Vechicle Management System

General requirements and assumptions
Requirements:
As a user I want to record the details of my car so that I can manage them later
* As a user I want to record the following fields:
    * Make (free form text upto 50 characters long)
    * Model (free form text upto 50 characters long)
    * Engine (free form text upto 50 characters long)
    * Doors (text field allowing numbers only. Must have at least one door)
    * Wheels (text field allowing numbers only. Must have at least four wheels)
    * Body Type (free form text upto 50 characters long)
* As a user I don’t want to be allowed enter wrong values where possible so that I reduce the amount of mistakes I make
    * The users shouldn’t be able to enter more than 50 characters in the following fields
        * Make
        * Model
        * Engine
        * Body Type
    * The user shouldn’t be allowed to enter anything but digits in the following fields
        * Wheels
        * Doors
* As a user I want an error message when I make a mistake so that I can correct it
    * An appropriate error message should show when
        * I enter less than four wheels
        * I enter less than one door
        * I try to save my car without filling in any fields

As a user I want to see all my current cars so that I can manage them
* A drop down with all current cars should be shown
** The cars should show the make and model to identify them
** There should be an edit button on each car that allows me to see and edit that car
** All fields should show the current car’s specification

As a user I want to edit my current cars so that I can keep the cars details up to day
* As a user I want to be able to access the edit page so that I can update my cars
    * A drop down with all cars should be shown on the home page
    * There should be an edit button on each car that takes you to an edit page
* As a user I want the UI to be the same as adding a car so I don’t have to learn two new pages
    * The UI should look exactly the same as the add section
* As a user I want all the fields to be pre-populated with the details I entered before so I do not have to re-enter them
    * Make, Model, Engine, Number of Doors, Number of wheels, and body type should have the same values as were entered on creation or last edit
* As a user when I click save I want the updates to be saved in the system so my changes aren’t lost
    * There should be a save button, that when clicked saves the updated fields  

As a developer I want this code to be easy for my team to support in the future so that there isn’t a single person depencies
* Design decisions should be clearly documented
* Where possible, current technologies should be used
* Test cases should clearly define the business logic

As a developer I want this code to be easily extensible to add more vehicle types so that this code will not need to be re-written in the near future.
* Interfaces and Inheritance should be used where possible
* Code should be written with the intention of adding more vehicles. 

Assumptions: 
* ID is internally assigned by the system and not a physical attribute of a car
* Filling in all fields is not required. However, filling in one or more fields is required.
* There is no limit to the number of doors on a car. There must be at least one door. 
* There is no limit to the number of wheels on a car. There must be at least four.
* 50 characters is sufficient to describe the Make, Model, Engine, and BodyType
* Make, Model, Engine and BodyType can be free form text and do not have particular values they must take. 
* There is only one user. Login is not require for that user. 
* Infrastructure for this application is out of scope. 
* A record of past updates is not required. 
