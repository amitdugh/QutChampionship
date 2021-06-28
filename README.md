# QutChampionship

This code accomplishes the following:
Task 1: Create an Athlete class with the following characteristics:
This class contains public static arrays that hold codes and descriptions of events held in a championship organised by QUT Sports Faculty. The event codes are T, B, S, R and O, corresponding to categories Tennis, Badminton, Swimming, Running and Other.  
The class contains an auto-implemented property that holds a participant’s name. 
The class contains fields for event code and description. The set accessor for the code assigns a code only if it is valid. Otherwise, it assigns I for Invalid. The event description is a read-only property that is assigned a value when the code is set. 

Task 2: Create an Application named QutChampionship that uses the Athlete class and performs the following tasks (at least one method is required for each the following sub-tasks):
a.	The program prompts the user for the number of participants in this year’s championship; the number must be between 0 and 40 (inclusive). The program continues to prompt the user until a valid value is entered. 
b.	The expected revenue is calculated and displayed. The cost is $30.00 per participant. 
c.	The program prompts the user for the names and event codes for each participant entered. Along with the prompt for an event code, display a list of valid categories. 
d.	Display information of all participants including the names, the event codes and the corresponding names of events. 
e.	After data entry is complete, the program displays the valid event categories and then continuously prompts the user for event codes, and displays the names of all participants in the category. Appropriate messages are displayed if the entered code is not a character or a valid code. 
