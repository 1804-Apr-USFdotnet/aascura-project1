using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryProject0
{
    public class RestaurantList : List<Restaurant>
    {
        public IEnumerable<Restaurant> Search(string toFind)
        {
            List<Restaurant> toReturn = new List<Restaurant>();

            foreach (Restaurant current in this)
            {
                if (current.Contains(toFind))
                {
                    toReturn.Add(current.Copy());
                }
            }

            return toReturn;
        }
        public IEnumerable<Restaurant> TopThree()
        {
            var query = (from current in this
                         orderby current.GetAverage() descending
                         select current).Take(3);
            
            List<Restaurant> topList = new List<Restaurant>();
            foreach (var item in query)
            {
                topList.Add(item);
            }
          
            return topList;
        }
        public IEnumerable<Restaurant> GetOrderNameAscending()
        {
            IEnumerable<Restaurant> restaurants = this;
            restaurants = from current in this orderby current.name ascending select current;
            return restaurants;
        }
        public IEnumerable<Restaurant> GetOrderNameDescending()
        {
            IEnumerable<Restaurant> restaurants = this;
            restaurants = from current in this orderby current.name descending select current;
            return restaurants;
        }
        public IEnumerable<Restaurant> GetOrderAverageDescending()
        {
            IEnumerable<Restaurant> restaurants = this;
            restaurants = from current in this orderby current.GetAverage() descending select current;
            return restaurants;
        }
        public IEnumerable<Restaurant> GetOrderAverageAscending()
        {
            IEnumerable<Restaurant> restaurants = this;
            restaurants = from current in this orderby current.GetAverage() ascending select current;
            return restaurants;
        }

        public IEnumerable<Restaurant> GetOrderReviewSumAscending()
        {
            IEnumerable<Restaurant> restaurants = this;
            restaurants = from current in this orderby current.GetReviews().Count() ascending select current;
            return restaurants;
        }
        public IEnumerable<Restaurant> GetOrderReviewSumDescending()
        {
            IEnumerable<Restaurant> restaurants = this;
            restaurants = from current in this orderby current.GetReviews().Count() descending select current;
            return restaurants;
        }
    }
}
