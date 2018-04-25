using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;


using ClassLibraryProject0;
using System.IO;
using System.Text.RegularExpressions;

namespace Project0
{
    class Program
    {
        static class Commands
        {
            public const string topThree = "T";
            public const string allRestaurants = "L";
            public const string restaurantDetails = "D";
            public const string restaurantReviews = "R";
            public const string search = "S";
            public const string quit = "Q";
        }

        static void DisplayMenu()
        {

            Console.WriteLine("PRESS \"T\" TO DISPLAY TOP 3 RESTAURANTS.");
            Console.WriteLine("PRESS \"L\" TO DISPLAY LIST OF RESTAURANTS.");
            Console.WriteLine("PRESS \"D\" TO DISPLAY DETAILS OF A SINGLE RESTAURANT.");
            Console.WriteLine("PRESS \"R\" TO DISPLAY ALL REVIEWS OF A SINGLE RESTAURANT.");
            Console.WriteLine("PRESS \"S\" TO SEARCH FOR RESTAURANTS.");
            Console.WriteLine("PRESS \"Q\" TO QUIT");
            Console.Write("PROVIDE AN INPUT > ");
        }

        static void DisplayInvalidInput()
        {
            Console.WriteLine("HEY.  THIS IS INVALID INPUT.  READ THE MENU MORE CAREFULLY.");
        }

        static void DisplayTopThree(RestaurantList toParse)
        {
            List<Restaurant> topThree = toParse.TopThree();
            foreach (Restaurant current in topThree)
            {
                Console.WriteLine("Name: {0}", current.name);
                Console.WriteLine("Rating: {0}", current.GetAverage());
            }
        }

        static void DisplayAllRestaurants(RestaurantList toDisplay)
        {
            Console.WriteLine("Restaurant Names");
            foreach (Restaurant current in toDisplay)
            {
                Console.WriteLine(current.name);
            }
        }

        static void DisplayRestaurantDetails()
        {
            Console.WriteLine("RESTAURANT DETAILS");
        }

        static void DisplayRestaurantReviews(RestaurantList restaurantList)
        {
            Restaurant toDisplay;
            int index = 0;
            string input;
            //Some logic to select a single restaurant
            bool inputIsValid;
            do
            {
                Console.Write("Please enter restaurant index >");
                input = Console.ReadLine();
                inputIsValid = ValidIndex(input, ref index);
                if (index < 0 || index > (restaurantList.Count - 1))
                {
                    inputIsValid = false;
                    Console.WriteLine("Error: index out of bounds.  Enter value between {0} and {1}", 0, restaurantList.Count- 1);
                }
            } while (!inputIsValid);

            toDisplay = restaurantList[index];

            Console.WriteLine("Reviews for " + toDisplay.name);
            List<Review> reviews = toDisplay.GetReviews();
            foreach (Review current in reviews)
            {
                Console.WriteLine("Reviewer Name: " + current.name);
                Console.WriteLine("Rating: " + current.rating);
                Console.WriteLine("Review Date: " + current.dateTime);
                Console.WriteLine("Coments: " + current.comment);

            }
            
        }

        static void SearchRestaurants()
        {
            Console.WriteLine("SEARCH");
        }



        static void ProcessMainMenuInput(out string input, RestaurantList restaurants)
        {
            input = Console.ReadLine();
            input = input.ToUpper();

            if (input == Commands.topThree)
            {
                DisplayTopThree(restaurants);
            }
            else if (input == Commands.allRestaurants)
            {
                DisplayAllRestaurants(restaurants);
            }
            else if (input == Commands.restaurantDetails)
            {
                DisplayRestaurantDetails();
            }
            else if (input == Commands.restaurantReviews)
            {
                DisplayRestaurantReviews(restaurants);
            }
            else if (input == Commands.search)
            {
                SearchRestaurants();
            }
            else if (input == Commands.quit)
            {
            }
            else
            {
                DisplayInvalidInput();
            }
        }

        static bool ValidIndex(string input, ref int index)
        {
            bool isValid = true;
            Regex alphanum = new Regex("^[0-9]+$");
            if (!alphanum.IsMatch(input))
            {
                isValid = false;
            }
            else
            {
                index = int.Parse(input);
            }

            return isValid;
        }

        static void TestInitialize(RestaurantList restaurants)
        {
            Review testReview1 = new Review("John", "Good", 9, new DateTime());
            Review testReview2 = new Review("James", "Meh", 5, new DateTime());
            Review testReview3 = new Review("Jacob", "Bad", 1, new DateTime());
            List<Review> testReviews = new List<Review>();
            testReviews.Add(testReview3);

            Restaurant testRestaurant1 = new Restaurant("Mark's Eatery", "1234 Food Road", "123456789", testReviews);

            testReviews.Add(testReview2);

            Restaurant testRestaurant2 = new Restaurant("Mick's Eatery", "2345 Food Road", "234567891", testReviews);

            testReviews.Add(testReview1);
            Restaurant testRestaurant3 = new Restaurant("Mary's Eatery", "3456 Food Road", "345678912", testReviews);

            testReviews.Add(testReview1);
            Restaurant testRestaurant4 = new Restaurant("Mary's Eatery", "3456 Food Road", "345678912", testReviews);

            restaurants.Add(testRestaurant1);
            restaurants.Add(testRestaurant2);
            restaurants.Add(testRestaurant3);
            restaurants.Add(testRestaurant4);

            //Console.WriteLine("Test Data Initialized");
        }

        static void Main(string[] args)
        {
            string input;
            ApplicationManager applicationManager = ApplicationManager.Instance;

            applicationManager.TestMethod();
            RestaurantList restaurants = new RestaurantList();
            TestInitialize(restaurants);

            Console.WriteLine("YO.  PROGRAM STARTING UP.");
            Console.WriteLine("WELCOME TO PROJECT 0.");
            
            do
            {
                DisplayMenu();
                ProcessMainMenuInput(out input, restaurants);
            } while (input.ToUpper() != Commands.quit);
            Console.ReadKey();
        }
    }
}
