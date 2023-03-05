using System.ComponentModel;

namespace Digital.Models
{
    public class VacationRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool HeadOfDepartmentApproval { get; set; }

        public bool OperationsApproval { get; set; }




        [DefaultValue("pending")]
        public string Status { get; set; } // can be "pending", "approved by head of department", "approved by operations", or "rejected"
    }
}
