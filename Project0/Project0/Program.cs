using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;


using ClassLibraryProject0;
using DataAccessLayerProject0;

namespace Project0
{
    partial class Program
    {
        public static class Commands
        {
            public const string topThree = "T";
            public const string allRestaurants = "L";
            public const string restaurantDetails = "D";
            public const string restaurantReviews = "R";
            public const string search = "S";
            public const string quit = "Q";
        }
        
        static void Main(string[] args)
        {         
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("Starting up.");
            string input;

            Project0_dbCrud dbCrud = new Project0_dbCrud();
            RestaurantList restaurants;

            
            InitializeFromDb(out restaurants, dbCrud);
            if (restaurants.Count == 0)
            {
                logger.Warn("Empty restaurant list.  May be indicative of failure to read.");
            }

            Console.WriteLine("WELCOME TO PROJECT 0.");
            
            do
            {

                DisplayMenu();
                input = GetInput("PLEASE INPUT MENU OPTION. >");
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
                    DisplayRestaurantDetails(restaurants);
                }
                else if (input == Commands.restaurantReviews)
                {
                    DisplayRestaurantReviews(restaurants);
                }
                else if (input == Commands.search)
                {
                    SearchRestaurants(restaurants);
                }
                else if (input == Commands.quit)
                {
                }
                else
                {
                    DisplayInvalidInput();
                }
            } while (input != Commands.quit);
            logger.Info("Program shutting down normally.");
        }


    }
}
