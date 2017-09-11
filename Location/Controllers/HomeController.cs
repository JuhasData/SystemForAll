using System.Web.Mvc;
using SystemForAll.Global;

namespace SystemForAll.Location.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        private GlobalControl global;
        
        //Locate all Global Entities
        public void locateAllGlobes()
        {
            GlobalControl currentGlobal = global;
            while (currentGlobal.nextGlobal != null)
            {
                //populate the Page with Globals by currentGlobal.entity
                currentGlobal = currentGlobal.nextGlobal;
            }
        }

        public void Add(long entity)
        {
            GlobalControl globalToAdd = new GlobalControl();
            globalToAdd.nextGlobal = entity;
            GlobalControl currentGlobal = global;
            currentGlobal.nextGlobal = globalToAdd;
        }

    }
}
