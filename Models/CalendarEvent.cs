namespace Digital.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public bool IsFullDay { get; set; }
        public bool IsApproved { get; set; }

        public int VacationRequestId { get; set; }
        public virtual VacationRequest VacationRequest { get; set; }
    }
}
