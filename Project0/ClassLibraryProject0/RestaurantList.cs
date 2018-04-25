using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryProject0
{
    public class RestaurantList : List<Restaurant>
    {
        public List<Restaurant> Search(string toFind)
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
        public List<Restaurant> TopThree()
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
    }
}
