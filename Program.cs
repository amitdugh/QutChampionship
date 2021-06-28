using System;
using static System.Console;
using static System.Array;

namespace QutChampionship
{
    class QutChampionship
    {
        static void Main(string[] args)
        {
            //This program is modular where new event code and corredponding description can be added to the
            // arrays defined in the Atlete class to scale it.
            // The minimum and maximum number of participants can be altered by changing the MIN and MAX constant
            // values in the method named NumberPlayers
            WriteLine("****************************************************************************************");
            WriteLine("Welcome to the QUT Championship");
            int participants;
            NumberPlayers(out participants); // Call method to get number of Participants
            CalcRev(participants); // Call method to calculate and display revenue        
            Athlete[] players = new Athlete[participants]; // define players as an array of Athlete
            CreateRecord(participants, players); //Call method to get user input and create record for each athlete
            Display(players); // Display name, event and event description for all participants
            EventInfo(players); // Call method to get user input to display event participation details

        }
        //Method to Prompt user to input number of participants - TASK 2A
        public static void NumberPlayers(out int numParticipants) 
        {
            const int MIN = 0; // Define the minimum number of players program can accept
            const int MAX = 40;// Define the maximum number of players program can accept
            int entry = -1;
            bool success = false;
            WriteLine("\n****************************** Task 2a ************************************************"); 
            Write("Enter the number of Participants >> ");
            while (entry <MIN || entry>MAX) 
            {
                success = int.TryParse(ReadLine(), out entry);
                if (success && entry>=MIN && entry<=MAX) // If conditions satisfied break out of while loop
                {
                    break;
                }
                else 
                {
                    entry = -1; //If no success then reassign entry to -1 to stay inside the loop
                    WriteLine("Invalid Entry >> Please enter the number of Participants between 0 and 40 >>");
                }
                
            }
            numParticipants = entry;
        } //End of method for TASK 2A
        
        //Method to calculate the Revenue - TASK 2B
        public static void CalcRev(int a) 
        {
            const double COST = 30.00;
            double revenue;
            revenue = a * COST;
            WriteLine("\n****************************** Task 2b ************************************************");
            WriteLine("\nThe total revenue is calculated as {0}",revenue.ToString("C"));
        } //End of method for TASK 2B

        //Method to Prompt user for enter participant's name and event code - TASK 2C - Part A
        public static void UserInput(out string name, out string inputcode) 
        {
            
            {
                Write("Enter participants name >>");
                name = ReadLine();
                for (int i = 0; i < Athlete.Code.Length; i++)
                {
                    WriteLine("{0,-6}{1,0}", Athlete.Code[i].ToString(), Athlete.Description[i]);
                }
                WriteLine("{0,29}","Enter event code >> ");
                inputcode = ReadLine();
            }
        }//End of method for TASK 2C - Part A

        //Method to create Participant records into an Array - TASK 2C - Part B
        public static void CreateRecord(int numParticipants, Athlete[] list) 
        {
            WriteLine("\n****************************** Task 2c ************************************************");
            for (int i = 0; i < numParticipants; i++) 
            {
                string namePlayer;
                string playerEventCode;
                UserInput(out namePlayer, out playerEventCode); // Call method to get user input for name and event code
                list[i] = new Athlete(namePlayer, playerEventCode); // Construct Athelete based on user input

            }
        }//End of method for TASK 2C - Part B

        //Method to Display information of participants - TASK 2D
        public static void Display(Athlete[] list) 
        {
            WriteLine("\n****************************** Task 2d ************************************************");
            WriteLine("\n------------------------------------------------------");
            WriteLine("| {0,-14}| {1,-14}| {2,-19}|", "Name", "Event Code", "Event Description");
            WriteLine("------------------------------------------------------");
            foreach (Athlete player in list) 
            {
                WriteLine("| {0,-14}| {1,-14}| {2,-19}|", player.Name, player.EventCode, player.EventDescription);
                //WriteLine("Player with name {0} is participating in event {1} : {2}",
                //    player.Name,player.EventCode,player.EventDescription);
            }
            WriteLine("------------------------------------------------------");
        }//End of method for TASK 2D


        //Method to Display event information based on user input - TASK 2E
        public static void EventInfo(Athlete[] list) 
        {
            const char QUIT = 'Z';
            WriteLine("\n****************************** Task 2e ************************************************");
            WriteLine("\nThe codes of categories are:");
            char input = 'A';
            string query;
            for (int i = 0; i < Athlete.Code.Length;i++) //Display the relevant codes
            {
                WriteLine("{0,-6}{1,-9}",Athlete.Code[i].ToString(),Athlete.Description[i]);
            }
            while (input != QUIT) // Stay in the loop until sentinel value is not passed
            {
                int counter1 = -1;
                Write("\nEnter an event code or Z to quit >>");
                query = ReadLine();
                if (query == Convert.ToString(QUIT)) //if Sentinel is passed break out of loop
                {
                    break;
                }
                for (int x = 0; x < Athlete.Code.Length; x++) //Check if the user input code is in the array of codes
                {
                    if (query == Convert.ToString(Athlete.Code[x]))
                    {
                        counter1 = x;
                        break;//Break the loop as soon as the Code is found
                    }
                }
                if (counter1 >= 0) //Display the player names
                {
                    int counter2 = -1;
                    WriteLine("\nParticipants with talent {0} are:", Athlete.Description[counter1]);
                    foreach (Athlete player in list)
                    {
                        if (query == Convert.ToString(player.EventCode))
                        {
                            WriteLine("{0} ", player.Name);
                            counter2 = 1;
                        }

                    }
                    if (counter2 == -1)
                    {
                        WriteLine("\n Note: No participant registered in this category");
                    }

                }
                else 
                {
                    WriteLine("\n{0} is not a valid event code", query);
                }

            }

        }//End of method for TASK 2E


    }//End of Main


    //Create Athelete Class
    class Athlete
    {
        public static char[] Code = { 'T', 'B', 'S', 'R', 'O'};
        public static string[] Description = { "Tennis", "Badminton", "Swimming", "Running", "Other"};
        public string Name { get; set; }
        private char eventCode;
        readonly string eventDescription;
        public char EventCode //define get set
        {
            set 
            {
                eventCode = value;
            }
            get 
            { 
                return eventCode; 
            }
        }

        public string EventDescription //get only defined as it is read only
        {
            get 
            {
                return eventDescription;
            }
        
        }

        //Constructor for the Athelete Class
        public Athlete(string name, string sport) 
        {
            Name = name;
            //Assign value for eventCode and based on input
            for (int n = 0; n < Code.Length; n++) 
            {
                if (sport == Convert.ToString(Code[n])) //Assign value if sport found in array Code
                {
                    eventCode = Code[n];
                    eventDescription = Description[n];
                    break;
                }
                else //if sport not found in the array Code then assign as per below
                {
                    eventCode = 'I';
                    eventDescription = "Invalid";
                }

            }
            

        }

    }
    //End Athelete Class

}//End of Program
