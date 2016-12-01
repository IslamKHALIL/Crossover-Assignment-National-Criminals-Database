using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NationalCriminalsDB.ViewModels;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace NationalCriminalsDB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationUserManager userManager;

        public HomeController(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }

        private string GetUserEmail()
        {
            if (User == null || User.Identity == null || string.IsNullOrEmpty(User.Identity.GetUserId()))
                return null;

            var user = userManager.FindById(User.Identity.GetUserId());
            if (user != null)
                return user.Email;

            return null;
        }

        public ActionResult Search()
        {
            var userEmail = GetUserEmail();
            if (string.IsNullOrEmpty(userEmail))
                return RedirectToAction("Login", "Account");

            var model = new SearchViewModel() { RequesterEmail = userEmail };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search(SearchViewModel model)
        {
            if (model == null)
                return RedirectToAction("Search");

            if (ModelState.IsValid && model.HasAtLeastOneFilter)
            {
                try
                {
                    using (CriminalSearchService.SearchServiceClient client = new CriminalSearchService.SearchServiceClient())
                    {
                        var res = await client.SearchAsync(new Service.ViewModels.SearchViewModel()
                        {
                            Address = model.Address,
                            FirstName = model.FirstName,
                            FromDateOfBirth = model.FromDateOfBirth,
                            LastName = model.LastName,
                            MaxAge = model.MaxAge,
                            MaxHeight = model.MaxHeight,
                            MaxResultCount = model.MaxResultCount,
                            MaxWeight = model.MaxWeight,
                            MinAge = model.MinAge,
                            MinHeight = model.MinHeight,
                            MinWeight = model.MinWeight,
                            Nationality = model.Nationality,
                            RequesterEmail = model.RequesterEmail,
                            Sex = model.Sex,
                            ToDateOfBirth = model.ToDateOfBirth
                        });
                        ViewBag.Message = res ? "The search request has been successfully created. Kindly check your inbox for the results." : "Error: The submitted model doesn't correspond of the one in the service";
                    }
                    return RedirectToAction("Search");
                }
                catch (Exception e)
                {
                    ViewBag.Message = $"Error: An error occured kindly try again. Error details: {e.Message}";
                }
                return View(model);
            }

            ViewBag.Message = !model.HasAtLeastOneFilter ? "Error: at least one criteria must be set." : "Error: invalid search parameters";
            return View(model);
        }
    }
}