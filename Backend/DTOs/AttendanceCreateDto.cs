using demoapplication.Model;
using System.Net.NetworkInformation;

namespace demoapplication.DTOs
{
    public class AttendanceCreateDto
    {
       public int EmployeeId { get; set; }
       public DateTime AttendanceDate { get; set; }

       public string Status { get; set; }

       public int HoursWorked { get; set; }

    }
}

