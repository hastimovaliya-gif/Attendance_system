using demoapplication.Model;
using Microsoft.EntityFrameworkCore;

namespace demoapplication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) => _context = context;


        public async Task<List<Employee>> GetAllAsync1()
            => await _context.Employees
                .Include(e => e.Policy)
                .ToListAsync();

        

        public async Task<bool> EmailExistsAsync(string email)
            => await _context.Employees.AnyAsync(e => e.Email == email);

        public async Task<bool> PolicyExistsAsync(int policyId)
            => await _context.Policies.AnyAsync(p => p.PolicyId == policyId);

        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}
