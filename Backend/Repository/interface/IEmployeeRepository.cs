using demoapplication.Model;

namespace demoapplication.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync1();
        Task<bool> EmailExistsAsync(string email);
        Task<bool> PolicyExistsAsync(int policyId);
        Task AddAsync(Employee employee);
    }


}
