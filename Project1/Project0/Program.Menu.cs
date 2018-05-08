using ClassLibraryProject0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project0
{
    partial class Program
    {
        static void DisplayMenu()
        {

            Console.WriteLine("PRESS \"T\" TO DISPLAY TOP 3 RESTAURANTS.");
            Console.WriteLine("PRESS \"L\" TO DISPLAY LIST OF RESTAURANTS.");
            Console.WriteLine("PRESS \"D\" TO DISPLAY DETAILS OF A SINGLE RESTAURANT.");
            Console.WriteLine("PRESS \"R\" TO DISPLAY ALL REVIEWS OF A SINGLE RESTAURANT.");
            Console.WriteLine("PRESS \"S\" TO SEARCH FOR RESTAURANTS.");
            Console.WriteLine("PRESS \"Q\" TO QUIT");
        }

        static string GetInput(string prompt)
        {
            string input;
            Console.Write(prompt);
            input = Console.ReadLine();
            return input;
        }

        static bool ValidateInput(string[] validInputs, string input)
        {
            bool isInvalid = false;

            foreach (string current in validInputs)
            {
                if (input.Equals(current))
                {
                    isInvalid = true;
                }
            }

            return isInvalid;
        }

        static void DisplayInvalidInput()
        {
            Console.WriteLine("ERROR: INVALID INPUT.  PLEASE SELECT OPTION FROM MENU.");
        }

        static void DisplayTopThree(IEnumerable<Restaurant> toParse)
        {
            IEnumerable<Restaurant> topThree = toParse.TopThree();
            foreach (Restaurant current in topThree)
            {
                Console.WriteLine("Name: {0}", current.name);
                Console.WriteLine("Rating: {0}", current.GetAverage().ToString("#.##"));
            }
        }

        static void DisplayAllRestaurants(IEnumerable<Restaurant> toDisplay)
        {
            Console.WriteLine("All restaurants");
            DisplayOrderedRestaurantList(toDisplay);
        }

        static void DisplayRestaurantList(IEnumerable<Restaurant> toDisplay)
        {
            for (int i = 0; i < (toDisplay.Count<Restaurant>()); i++)
            {
                Console.WriteLine("{0}. {1}", i+1, toDisplay.ElementAt<Restaurant>(i).name);
            }
        }

        static void DisplayOrderedRestaurantList(IEnumerable<Restaurant> toDisplay)
        {
            string input;
            int parsedInput = 0;
            bool isValid;
            do
            {
                isValid = false;
                Console.WriteLine("1. Alphabetical Order");
                Console.WriteLine("2. Reverse Alphabetical Order");
                Console.WriteLine("3. Average Review - High to Low");
                Console.WriteLine("4. Average Review - Low to High");
                Console.WriteLine("5. Number of Reviews - High to Low");
                Console.WriteLine("6. Number of Reviews - Low to High");
                input = GetInput("PLEASE ENTER NUMBER FOR PREFERRED ORDER CRITERION > ");
                if (IsNum(input))
                {
                    parsedInput = int.Parse(input);
                    if (parsedInput > 0 && parsedInput < 7)
                    {
                        isValid = true;
                    } else
                    {
                        Console.WriteLine("ERROR: PLEASE SELECT A NUMBER BETWEEN 1 AND 6");
                    }
                }
            } while (isValid == false);

            IEnumerable<Restaurant> queryResults = from current in toDisplay select current;
            switch (parsedInput)
            {
                case 1:
                    queryResults = toDisplay.GetOrderNameAscending();
                    int i = 1;
                    foreach (var current in queryResults)
                    {
                        Console.WriteLine(i + ". " + current.name);
                        i++;
                    }
                    break;
                case 2:
                    queryResults = toDisplay.GetOrderNameDescending();
                    i = 1;
                    foreach (var current in queryResults)
                    {
                        Console.WriteLine(i + ". " + current.name);
                        i++;
                    }
                    break;
                case 3:
                    queryResults = toDisplay.GetOrderAverageDescending();
                    i = 1;
                    foreach (var current in queryResults)
                    {
                        Console.WriteLine(i + ". " + current.name + ", Avg Rating: " + current.GetAverage().ToString("#.##"));
                        i++;
                    }
                    break;
                case 4:
                    queryResults = toDisplay.GetOrderAverageAscending();
                    i = 1;
                    foreach (var current in queryResults)
                    {
                        Console.WriteLine(i + ". " + current.name + ", Avg Rating: " + current.GetAverage().ToString("#.##"));
                        i++;
                    }
                    break;
                case 5:
                    queryResults = toDisplay.GetOrderReviewSumDescending();
                    i = 1;
                    foreach (var current in queryResults)
                    {
                        Console.WriteLine(i + ". " + current.name + ", # of Ratings: " + current.GetReviews().Count);
                        i++;
                    }
                    break;
                case 6:
                    queryResults = toDisplay.GetOrderReviewSumAscending();
                    i = 1;
                    foreach (var current in queryResults)
                    {
                        Console.WriteLine(i + ". " + current.name + ", # of Ratings: " + current.GetReviews().Count);
                        i++;
                    }
                    break;
                default:
                    break;
            }
        }



        static void DisplayRestaurantDetails(IEnumerable<Restaurant> restaurants)
        {
            int index;
            Restaurant toDisplay;

            DisplayRestaurantList(restaurants);
            index = GetValidIndex(restaurants);
            toDisplay = restaurants.ElementAt<Restaurant>(index);

            Console.WriteLine("Details for " + toDisplay.name);
            Console.WriteLine("Address: " + toDisplay.address);
            Console.WriteLine("Phone Numeber: " + toDisplay.phoneNum);
            Console.WriteLine("Average Rating: " + toDisplay.GetAverage().ToString("#.##"));
            Console.WriteLine("Number of Ratings: " + toDisplay.GetReviews().Count);
        }

        static int GetValidIndex(IEnumerable<Restaurant> restaurants)
        {
            string input;
            bool inputIsValid;
            int index = 0;
            do
            {
                input = GetInput("PLEASE ENTER RESTAURANT INDEX. >");
                inputIsValid = IsNum(input);
                if (inputIsValid == true)
                {
                    index = int.Parse(input);
                }
                if (index < 1 || index > restaurants.Count<Restaurant>())
                {
                    inputIsValid = false;
                    Console.WriteLine("ERROR: INVALID INPUT.  PLEASE ENTER VALUE BETWEEN {0} AND {1}.", 1, restaurants.Count<Restaurant>());
                }
            } while (!inputIsValid);
            return index - 1;
        }

        static void DisplayRestaurantReviews(IEnumerable<Restaurant> restaurants)
        {
            int index;
            Restaurant toDisplay;
            List<Review> reviews;
            DisplayRestaurantList(restaurants);
            index = GetValidIndex(restaurants);
            toDisplay = restaurants.ElementAt<Restaurant>(index);

            Console.WriteLine("Reviews for " + toDisplay.name);
            reviews = toDisplay.GetReviews();

            foreach (Review current in reviews)
            {
                Console.WriteLine("Reviewer Name: " + current.name);
                Console.WriteLine("Rating: " + current.rating);
                Console.WriteLine("Review Date: " + current.dateTime);
                Console.WriteLine("Coments: " + current.comment);
                Console.WriteLine("Review for {0}, id {1}", current.restaurant.name, current.restaurant.id);
            }
        }

        static void SearchRestaurants(List<Restaurant> restaurants)
        {
            IEnumerable<Restaurant> relatedRestaurants;
            string toFind;
            Console.WriteLine("SEARCH");
            toFind = GetInput("Please enter search term. >");
            relatedRestaurants = restaurants.Search(toFind);
            Console.WriteLine("Related restaurants:");
            if (relatedRestaurants.Count<Restaurant>() == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Restaurant current in relatedRestaurants)
                {
                    Console.WriteLine(current.name);
                }
            }
        }
        
        static bool IsNum(string input)
        {
            bool isValid = true;
            Regex alphanum = new Regex("^[0-9]+$");
            if (!alphanum.IsMatch(input))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
