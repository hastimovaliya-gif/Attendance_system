using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace demoapplication.Model

{
   
        public class Employee
        {
             [Key]
            public int EmployeeId { get; set; }
            public int PolicyId { get; set; }
        

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public bool IsActive { get; set; }

        [JsonIgnore]
        public Policy Policy { get; set; }
        [JsonIgnore]
        public ICollection<AttendanceRecord> AttendanceRecords { get; set; }

        }


    
}
