using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerProject0
{
    public class Project0_dbCrud
    {
        project0_dbEntities db = new project0_dbEntities();

        public IEnumerable<restaurant> GetRestaurants()
        {
            return db.restaurants.ToList();
        }

        public IEnumerable<review> GetReviews()
        {
            return db.reviews.ToList();
        }

        public void Create(restaurant toInsert)
        {
            if (toInsert == null)
            {
                throw new ArgumentNullException("toInsert");
            }
            db.restaurants.Add(toInsert);
            db.SaveChanges();
        }

        public void Delete(restaurant toDelete)
        {
            if(toDelete == null)
            {
                throw new ArgumentNullException("toDelete");
            }
            db.restaurants.Remove(toDelete);
            db.SaveChanges();
        }

        public void Update(restaurant updateFrom)
        {
            if(updateFrom == null)
            {
                throw new ArgumentNullException("toUpdate");
            }
            restaurant toUpdate = GetRestaurantById(updateFrom.id);
            toUpdate.name = updateFrom.name;
            toUpdate.phoneNumber = updateFrom.phoneNumber;
            toUpdate.address = updateFrom.address;
            db.SaveChanges();
        }

        public void Create(review toInsert)
        {
            if (toInsert == null)
            {
                throw new ArgumentNullException("toInsert");
            }
            db.reviews.Add(toInsert);
            db.SaveChanges();
        }

        public void Delete(review toDelete)
        {
            if (toDelete == null)
            {
                throw new ArgumentNullException("toDelete");
            }
            db.reviews.Remove(toDelete);
            db.SaveChanges();
        }

        public void Update(review updateFrom)
        {
            if (updateFrom == null)
            {
                throw new ArgumentNullException("updateFrom");
            }
            review toUpdate = GetReviewById(updateFrom.id);

            toUpdate.reviewerName = updateFrom.reviewerName;
            toUpdate.comment = updateFrom.comment;
            toUpdate.date = updateFrom.date;
            toUpdate.rating = updateFrom.rating;

            db.SaveChanges();
        }

        public restaurant GetRestaurantById(int id)
        {
            restaurant toFind = null;

            foreach (restaurant currentRest in db.restaurants)
            {
                if(currentRest.id == id)
                {
                    toFind = currentRest;
                    break;
                }
            }
            return toFind;
        }

        public review GetReviewById(int id)
        {
            review toFind = null;
            foreach (review currentRev in db.reviews)
            {
                if(currentRev.id == id)
                {
                    toFind = currentRev;
                }
            }
            return toFind;
        }

    }
}
