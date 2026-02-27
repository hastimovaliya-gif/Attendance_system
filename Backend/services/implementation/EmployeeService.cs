using demoapplication.DTOs;
using demoapplication.Model;
using demoapplication.Repository;

namespace demoapplication.services.implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }


        public async Task<List<Employee>> GetEmployeesAsync()
            => await _repo.GetAllAsync1();


        public async Task CreateEmployeeAsync(EmployeeCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName) ||
                string.IsNullOrWhiteSpace(dto.LastName) ||
                string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("Required fields missing");

            if (!await _repo.PolicyExistsAsync(dto.PolicyId))
                throw new ArgumentException("Invalid PolicyId");

            if (await _repo.EmailExistsAsync(dto.Email))
                throw new InvalidOperationException("Email already exists");

            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PolicyId = dto.PolicyId,
                IsActive = true
            };

            await _repo.AddAsync(employee);
        }
    }
}
