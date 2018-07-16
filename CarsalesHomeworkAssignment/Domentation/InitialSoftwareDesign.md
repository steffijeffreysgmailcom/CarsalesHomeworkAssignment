### Storage Choice
External Database
* Requires installation and deployment
* Unsuitable for this project as it must be run simply from opening the project

In Memory Data (InMemory .Net Core)
* Built for lightweight prototyping.
* Can easily be switched for a real database when needed
    * This allows for the software to scale, but still allows for quick MVP to be built
* Can be still used for unit and module tests 

### Database Design
At the moment there is a single object that needs to be stored in the database, a car. However in the future we are aware of plans to include the management of motorbikes, boats, and other sorts of vehicles. Hence we need to choose a database structure that suits this inheritance model. 
* Have separate table for vehicle type (Table Per Concrete)
    * This would reduce the amount of storage of redundant in total
    * However would increase the total complexity and ability for abstraction.
* Have one common table for the common attributes and separate table for each of the separate types that links to this first table. (Table per Type)
    * Increase the number of table
    * Still do not have redundant space
    * However in our case there are many attributes that are common to some, but not possible future types. For example number of wheels applies to cars and motorbikes, however does not apply to boats. Selecting an appropriate level of commonality would be difficult
* Have one table with all the vehicle types and have empty columns for the unnecessary items. (Table per hierarchy)
    * Suits having different commonality between types
    * Does have some wasted storage as not all columns are in use. 
    * However, reduces code and database complexity

Final Decision 
* Use Table per hierarchy design

### Separated DAL, BLL and Presentation Layer
* This was chosen as it is very likely certain components might get replaced. Using an inmemory database works well for a prototype solution, however will eventually need to be replaced by a real database. Having the DAL separated allows for this to happen easily. The presentation layer is also likely to change or to have multiple sorts. For example, people might want to manage their cars from an app instead. 

 