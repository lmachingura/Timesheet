using TimesheetApp.Web.Models;
namespace TimesheetApp.Web.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }

        public ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
