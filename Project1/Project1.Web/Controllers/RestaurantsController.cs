using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClassLibraryProject0;
using Project1.Web.Models;

namespace Project1.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        RestaurantRepo restaurantRepo;

        public RestaurantsController ()
        {
            restaurantRepo = new RestaurantRepo();
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(restaurantRepo.GetRestaurants());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            Restaurant toPass = restaurantRepo.GetById(id);
            return View(toPass);
//            return View(restaurantRepo.GetById(id));
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(RestaurantWeb restaurant)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    restaurantRepo.Create(restaurant.ToLibrary());
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(restaurant);
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
            return View();
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurants/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
