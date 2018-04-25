using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibraryProject0;

namespace Project0
{
    class ApplicationManager
    {
        public RestaurantList restaurants;

        private static ApplicationManager instance = new ApplicationManager();

        private ApplicationManager()
        {
            restaurants = new RestaurantList();
        }

        public static ApplicationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationManager();
                }
                return instance;
            }
        }

        public void TestMethod() { }
    }
}
