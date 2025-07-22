using TimesheetApp.Web.Data;

namespace TimesheetApp.Web.Models
{
    public class TimeEntry
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }

        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
        public string Notes { get; set; }

        public bool IsSubmitted { get; set; }
        public bool IsApproved { get; set; }
    }
}
