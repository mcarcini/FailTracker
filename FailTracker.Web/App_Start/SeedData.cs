using FailTracker.Web.Data;
using FailTracker.Web.Domain;
using FailTracker.Web.Infrastructure.Tasks;
using System.Linq;

namespace FailTracker.Web.App_Start
{
    public class SeedData : IRunAtStartup
    {
        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context) {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.Users.Any()) {
                _context.Users.Add(new ApplicationUser
                {
                    UserName = "TestUser"
                });
                _context.SaveChanges();
            }
        }
    }
}