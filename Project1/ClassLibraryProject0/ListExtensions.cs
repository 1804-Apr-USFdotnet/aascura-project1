using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryProject0
{
    public static class ListExtensions
    {
        public static IEnumerable<Restaurant> Search(this List<Restaurant> list, string toFind)
        {
            List<Restaurant> toReturn = new List<Restaurant>();

            foreach (Restaurant current in list)
            {
                if (current.Contains(toFind))
                {
                    toReturn.Add(current.Copy());
                }
            }
            return toReturn;
        }


        public static IEnumerable<Restaurant> TopThree(this IEnumerable<Restaurant> list)
        {
            var query = (from current in list
                         orderby current.GetAverage() descending
                         select current).Take(3);

            List<Restaurant> topList = new List<Restaurant>();
            foreach (var item in query)
            {
                topList.Add(item);
            }

            return topList;
        }

        public static IEnumerable<Restaurant> GetOrderNameAscending(this IEnumerable<Restaurant> list)
        {
            IEnumerable<Restaurant> restaurants = list;
            restaurants = from current in list orderby current.name ascending select current;
            return restaurants;
        }
        public static IEnumerable<Restaurant> GetOrderNameDescending(this IEnumerable<Restaurant> list)
        {
            IEnumerable<Restaurant> restaurants = list;
            restaurants = from current in list orderby current.name descending select current;
            return restaurants;
        }

        public static IEnumerable<Restaurant> GetOrderAverageDescending(this IEnumerable<Restaurant> list)
        {
            IEnumerable<Restaurant> restaurants = list;
            restaurants = from current in list orderby current.GetAverage() descending select current;
            return restaurants;
        }
        public static IEnumerable<Restaurant> GetOrderAverageAscending(this IEnumerable<Restaurant> list)
        {
            IEnumerable<Restaurant> restaurants = list;
            restaurants = from current in list orderby current.GetAverage() ascending select current;
            return restaurants;
        }

        public static IEnumerable<Restaurant> GetOrderReviewSumAscending(this IEnumerable<Restaurant> list)
        {
            IEnumerable<Restaurant> restaurants = list;
            restaurants = from current in list orderby current.GetReviews().Count() ascending select current;
            return restaurants;
        }
        public static IEnumerable<Restaurant> GetOrderReviewSumDescending(this IEnumerable<Restaurant> list)
        {
            IEnumerable<Restaurant> restaurants = list;
            restaurants = from current in list orderby current.GetReviews().Count() descending select current;
            return restaurants;
        }
    }
}
