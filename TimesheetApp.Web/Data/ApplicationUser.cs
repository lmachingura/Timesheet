using Microsoft.AspNetCore.Identity;
using TimesheetApp.Web.Models;

namespace TimesheetApp.Web.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int? OrganisationId { get; set; }
        public Organisation Organisation { get; set; }

        public ICollection<TimeEntry> TimeEntries { get; set; }
    }

}
