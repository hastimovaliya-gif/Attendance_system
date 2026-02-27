using System.ComponentModel.DataAnnotations;
namespace demoapplication.Model
{
    
        public class Policy
        {
            [Key]
            public int PolicyId { get; set; }
            public string Name { get; set; }
            public decimal MinDailyHours { get; set; }

            public ICollection<Employee> Employees { get; set; }
        }

    
}
