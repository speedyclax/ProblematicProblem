using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {       
            Random rng = new Random();

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            
            bool cont = true;
            var contResponse = Console.ReadLine().ToLower();
            
            if (contResponse == "yes")
            {
                cont = true;
            }
            else if (contResponse == "no")
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for your time.");
                Console.WriteLine();
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");

            string userName = Console.ReadLine();

            Console.WriteLine();
            Console.Write("What is your age? ");

            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");

            bool seeList = (Console.ReadLine().ToLower() == "sure")? true : false;

            if (seeList)
            {
                Console.WriteLine();

                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Would you like to add any activities before we generate one? yes/no: ");

            bool addToList = (Console.ReadLine().ToLower() == "yes")? true : false;

            Console.WriteLine();

            while (addToList)
                {
                    Console.Write("What would you like to add? ");

                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    Console.WriteLine();

                    foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
            
                    addToList = (Console.ReadLine().ToLower() == "yes")? true : false;
                    
                }
            }

            while (cont)
            {
                Console.WriteLine();
                Console.Write("Connecting to the database");
        
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
        
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine();
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine();
                    Console.WriteLine("We'll find a different activity for you");
                    Console.WriteLine();

                    Console.Write("Connecting to the database");

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();
                    Console.Write("Choosing your random activity");

                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();

                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.WriteLine();
                Console.Write($"Ah, got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                
                cont = (Console.ReadLine().ToLower() == "redo") ? true : false;
            }
        }
    }
}