using FailTracker.Web.Data;
using System;
using System.Web.Mvc;

namespace FailTracker.Web.Infrastructure
{
    public class LogAttribute : ActionFilterAttribute
    {
        public ApplicationDbContext Context { get; set; }
        public string Description { get; set; }

        public LogAttribute(string description) { 
            Description = description;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {            
            Console.WriteLine("Log: " + Description);
        }
    }
}