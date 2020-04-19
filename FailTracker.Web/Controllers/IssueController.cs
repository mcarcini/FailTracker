using FailTracker.Web.Data;
using System.Web.Mvc;

namespace FailTracker.Web.Controllers
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssueController(ApplicationDbContext context)
        {
            _context = context;            
        }

        public ActionResult Index()
        {
            return Content("Here is where issues would go!");
        }

    }
}