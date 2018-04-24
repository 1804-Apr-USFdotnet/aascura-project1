using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;


using ClassLibraryProject0;
using System.IO;

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

        static void DisplayTopThree()
        {
            Console.WriteLine("TOP THREE");
        }

        static void DisplayAllRestaurants()
        {
            Console.WriteLine("ALL RESTAURANTS");
        }

        static void DisplayRestaurantDetails()
        {
            Console.WriteLine("RESTAURANT DETAILS");
        }

        static void DisplayRestaurantReviews()
        {
            Console.WriteLine("REVIEWS");
        }

        static void SearchRestaurants()
        {
            Console.WriteLine("SEARCH");
        }

        static void ProcessInput(out string input)
        {
            input = Console.ReadLine();
            input = input.ToUpper();

            if (input == Commands.topThree)
            {
                DisplayTopThree();
            }
            else if (input == Commands.allRestaurants)
            {
                DisplayAllRestaurants();
            }
            else if (input == Commands.restaurantDetails)
            {
                DisplayRestaurantDetails();
            }
            else if (input == Commands.restaurantReviews)
            {
                DisplayRestaurantReviews();
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

        
        static void testSerialize()
        {
            Review review1 = new Review("testname1", "testcomment1", 5M, new DateTime(1,1,1,1,1,1));
            Review review2 = new Review("TESTNAME2", "TESTCOMMENT2", 8M, new DateTime(2,2,2,2,2,2));
            List<Review> reviews = new List<Review>();

            reviews.Add(review1);
            reviews.Add(review2);
            
            Restaurant restaurant = new Restaurant("restname", "restaddress","123456789", reviews);
            string jsonString = restaurant.toJsonString();
            Console.WriteLine(jsonString);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Restaurant restaurant2 = new Restaurant(jsonString);
            string jsonString2 = restaurant2.toJsonString();
            Console.WriteLine(jsonString2);
            /*MemoryStream ms = new MemoryStream();

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restaurant));
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                ser.WriteObject(ms, restaurant);
                ms.Position = 0;
                Console.WriteLine("JSON form of User object: " + sr.ReadToEnd());
                //ms.Position = 0;  // sets position of memory stream back to start
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ms.Close();
            }*/
        }
        
        static void Main(string[] args)
        {
            string input;
            List<Restaurant> restaurants = new List<Restaurant>();

            Console.WriteLine("YO.  PROGRAM STARTING UP.");
            Console.WriteLine("WELCOME TO PROJECT 0.");

            /*do
            {
                DisplayMenu();
                ProcessInput(out input);
            } while (input.ToUpper() != Commands.quit);*/
            testSerialize();
            Console.ReadKey();
        }
    }
}
