using TimesheetApp.Web.Data;

namespace TimesheetApp.Web.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
