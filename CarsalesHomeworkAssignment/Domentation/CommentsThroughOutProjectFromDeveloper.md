## Running Commentary of Decisions Made
This document aims to provide some of the decisions I am making as I go along. I am aware this sort of file would be not usually be included in a production project, however since you are testing how I think I thought it could be useful. 

### Testing and Database concerns
I implemented the database in such a way it directly got the service reference, rather then going through a context class. This had impacts when I was doing my testing, as creating a new inmemory database for each test was not easily doable. Ponding on this decision took a lot of time and understanding what I did wrong. At this point, I have decided to value getting the product out, as it is over due, and then try fix the test cases. The quality should not be impacted as all tests do run individually. However, the efficiency of running the tests individually does not pay off. 

### Change to update tests
Originally my tests cases ignored nulls passed into the edit method. I realised that it could be possible that a person might want to remove some of the features after they add them. This would require null to be passed on to the database as nulls. 

### Adding static methods to car
I added two conversion methods to the Car class. As the interface cannot have static methods, and they needed to be static (doesn't make sense to instantiate an object to to convert a completely different object). This means I had to have case statements throughout the controller, to try deal with the different types of vehicles. 

### Template
By now I realise I really should have started with a template that is already out there. Unfortunately I am here now two days late. 