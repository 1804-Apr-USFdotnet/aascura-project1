using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplicationProject1.Models;
using ClassLibraryProject0;


namespace WebApplicationProject1.Controllers
{
    public class RestaurantsController : Controller
    {
        RestaurantRepo restaurantRepo;
        List<RestaurantWeb> restaurantsWeb;
        List<ReviewWeb> reviewsWeb;
        public RestaurantsController()
        {
            restaurantRepo = new RestaurantRepo();
            restaurantsWeb = new List<RestaurantWeb>();
            reviewsWeb = new List<ReviewWeb>();
            foreach(var restaurantLib in restaurantRepo.GetRestaurants())
            {
                restaurantsWeb.Add(new RestaurantWeb(restaurantLib));
         
            }
            foreach (var reviewLib in restaurantRepo.GetReviews())
            {
                reviewsWeb.Add(new ReviewWeb(reviewLib, new RestaurantWeb(reviewLib.restaurant)));
            }
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(restaurantsWeb);
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            return View(restaurantsWeb.GetById(id));
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(RestaurantWeb newRest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    restaurantRepo.CreateRestaurant(newRest.ToLibLayer());
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(newRest);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int id)
        {
            RestaurantWeb toEdit = restaurantsWeb.GetById(id);
            return View(toEdit);
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        public ActionResult Edit(RestaurantWeb toEdit)
        {
            if (ModelState.IsValid)
                {
                    restaurantRepo.UpdateRestaurant(toEdit.ToLibLayer());
                    return RedirectToAction("Index");
                }
            return View(toEdit);
        }

        // GET: Restaurants/Delete/5
        public ActionResult DeleteRestaurant(int id)
        {
            restaurantRepo.DeleteRestaurant(id);
            return RedirectToAction("Index", "Restaurants");
        }

       // [HttpPost]
        public ActionResult DeleteReview(ReviewWeb toDelete)
        {
            restaurantRepo.DeleteReview(toDelete.Id);
            return RedirectToAction("Index", "Restaurants");
        }

        public ActionResult EditReview(int id)
        {
            ReviewWeb toEdit = reviewsWeb.GetById(id);   
            return View(toEdit);
        }

        [HttpPost]
        public ActionResult EditReview(ReviewWeb toEdit)
        {
            if (ModelState.IsValid)
            {
                toEdit.Restaurant = reviewsWeb.GetById(toEdit.Id).Restaurant;
                restaurantRepo.UpdateReview(toEdit.ToLibLayer(toEdit.Restaurant.ToLibLayer()));
                return RedirectToAction("Details", "Restaurants",toEdit.Restaurant);
            }
            return View(toEdit);
        }

        public ActionResult ToRestaurant(int id)
        {
            return RedirectToAction("Details",restaurantsWeb.GetById(id));
        }

        public ActionResult CreateReview(int restId)
        {
            TempData.Add("restId", restId);
            return View();
        }

        [HttpPost]
        public ActionResult CreateReview(ReviewWeb newReviewWeb)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    object passedData;
                    TempData.TryGetValue("restId", out passedData);
                    int restId = (int) passedData;
                    newReviewWeb.Restaurant = restaurantsWeb.GetById(restId);
                    restaurantRepo.CreateReview(newReviewWeb.ToLibLayer(newReviewWeb.Restaurant.ToLibLayer()));
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(newReviewWeb);
                }
            }
            catch
            {
                return View();
            }

        }
    }
}
