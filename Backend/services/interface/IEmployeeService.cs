using demoapplication.DTOs;
using demoapplication.Model;


namespace demoapplication.services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task CreateEmployeeAsync(EmployeeCreateDto dto);
    }

}
