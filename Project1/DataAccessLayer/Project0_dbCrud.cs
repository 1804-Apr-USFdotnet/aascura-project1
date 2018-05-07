using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerProject0
{
    public class Project0_dbCrud
    {
        project0_dbEntities db = new project0_dbEntities();

        public List<restaurant> GetRestaurants()
        {
            return db.restaurants.ToList();
        }
    }
}
