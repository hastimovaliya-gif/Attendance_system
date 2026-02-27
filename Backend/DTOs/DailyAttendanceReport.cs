namespace demoapplication.DTOs
{
    public class DailyAttendanceReportDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string PolicyName { get; set; }
        public decimal MinDailyHours { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; }
        public decimal HoursWorked { get; set; }
        public string DailyFlag { get; set; } // OK / PolicyViolation
    }
}
