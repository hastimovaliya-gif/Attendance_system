using System.ComponentModel.DataAnnotations;

namespace demoapplication.Model
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }

        [Required(ErrorMessage = "Policy name is required")]
        [StringLength(100, ErrorMessage = "Policy name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Minimum daily hours are required")]
        [Range(0, 24, ErrorMessage = "Minimum daily hours must be between 0 and 24")]
        public decimal MinDailyHours { get; set; }

        // Navigation Property
        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}