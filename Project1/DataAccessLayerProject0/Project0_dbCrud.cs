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

        public List<review> GetReviews()
        {
            return db.reviews.ToList();
        }

        public void CreateRestaurant(restaurant toAdd)
        {
            db.restaurants.Add(toAdd);
            db.SaveChanges();
        }

        public void UpdateRestaurant(restaurant toUpdate)
        {
        }

        public void DeleteRestaurant(int toDeleteIndex)
        {
            Delete(db.restaurants.ElementAt(toDeleteIndex));
        }

        private void Delete(restaurant toDelete)
        {
            db.restaurants.Remove(toDelete);
        }
    }
}
