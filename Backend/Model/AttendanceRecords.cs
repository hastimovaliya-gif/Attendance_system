using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoapplication.Model
{
    public class AttendanceRecord
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Attendance date is required")]
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters")]
        [RegularExpression("^(Present|Absent|Leave|HalfDay)$",
            ErrorMessage = "Status must be Present, Absent, Leave, or HalfDay")]
        public string Status { get; set; }

        [Range(0, 24, ErrorMessage = "Hours worked must be between 0 and 24")]
        public decimal HoursWorked { get; set; }

        // Navigation property
        public Employee Employee { get; set; }
    }
}