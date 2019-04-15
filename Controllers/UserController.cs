using Sandeeptest.DAL;
using Sandeeptest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sandeeptest.Controllers
{
    public class UserController : Controller
    {
        UserDAL dal = new UserDAL();
        Helper help = new Helper();
        // GET: User
        public ActionResult Index()
        {
            List<User> users = new List<User>();
            users = dal.GetUsers();
            return View(users);
        }
        public ActionResult Create()
        {
            User user = new User();
            user.Countries = dal.GetCountries();
            user.Cities = new List<City>();//dal.GetCitiesByCountryId(1);
            return View("Create", user);
        }
        [HttpPost]
        public JsonResult GetCountryById(int countryId)
        {
            //List<City> cities = dal.GetCitiesByCountryId(countryId);
            var result = dal.GetCitiesByCountryId(countryId);
            return Json(result);
        }
        public ActionResult Edit(int id)
        {
            User user = new User();
            user = dal.GetUserById(id);
            user.Countries = dal.GetCountries();
            user.Cities = dal.GetCitiesByCountryId(1);

            return View("Create", user);
        }


        public async Task<JsonResult> CheckEmailInDataBase(string email, string previousemail)
        {
            bool status = false;
            try
            {
                if (email != previousemail)
                    return Json(false, JsonRequestBehavior.AllowGet); 
                bool isExist = dal.CheckEmailInDataBase(email);
                return Json(isExist, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {

                throw;
            }


            return Json(status);
        }

        public ActionResult Delete(int id)
        {
            User user = new User();
            int rowDeleted = dal.DeleteUserById(id);
            //user.Countries = dal.GetCountries();
            //user.Cities = dal.GetCitiesByCountryId(1);

            return RedirectToAction("Index");// ("Create", user);
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<User> users = new List<User>();
                    users.Add(user);
                    int isCreated = dal.CreateUser(Helper.ToDataTable(users));
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Create", user);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}