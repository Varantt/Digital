using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Models
{
    public class Approval
    {
        public int Id { get; set; }


        [ForeignKey("ApproverId")]
        public Employee Approver { get; set; }

        [ForeignKey("VacationRequestId")]
        public VacationRequest VacationRequest { get; set; }

        // Setting the OnDelete behavior to 'Restrict'
        [ForeignKey(nameof(VacationRequest))]
        public int VacationRequestId { get; set; }

        // Setting the OnDelete behavior to 'Cascade'
        [ForeignKey(nameof(Approver))]
        public int ApproverId { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string Comments { get; set; }
    }
}
