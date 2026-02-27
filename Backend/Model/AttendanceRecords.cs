using System.ComponentModel.DataAnnotations;
namespace demoapplication.Model
{
    public class AttendanceRecord
    {
        [Key]
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; }
        public decimal HoursWorked { get; set; }
        public Employee Employee { get; set; }
    }
}
