using FailTracker.Web.Data;
using FailTracker.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FailTracker.Web.Controllers
{
	public class HomeController : Controller
	{
        private readonly ApplicationDbContext _context;
        private readonly ISayHello _sayHello;

        public HomeController(ApplicationDbContext context, ISayHello sayHello) {
            _context = context;
            _sayHello = sayHello;
        }

        [Log("Index of HomeController")]
        public ActionResult Index()
		{
			return View();
		}
	}

    public interface ISayHello
    { 
    }

    public class SayHello : ISayHello { 

    }
}