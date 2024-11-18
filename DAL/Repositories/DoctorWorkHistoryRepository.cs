using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class DoctorWorkHistoryRepository : RepositoryBase<DoctorWorkHistory>, IDoctorWorkHistoryRepository
{
    public DoctorWorkHistoryRepository(DbContext context) : base(context) { }

    // Отримати історію роботи лікаря з пов'язаним відділенням і спеціалізацією
    public async Task<DoctorWorkHistory?> GetWithDepartmentAndSpecializationAsync(Guid id)
    {
        return await _dbSet
            .Include(dwh => dwh.Department)
            .Include(dwh => dwh.DoctorSpecialization)
            .FirstOrDefaultAsync(dwh => dwh.Id == id);
    }

    // Отримати всі записи про роботу лікаря за його ID
    public async Task<List<DoctorWorkHistory>> GetByDoctorIdAsync(Guid doctorId)
    {
        return await _dbSet
            .Where(dwh => dwh.DoctorId == doctorId)
            .Include(dwh => dwh.Department)
            .Include(dwh => dwh.DoctorSpecialization)
            .ToListAsync();
    }

    // Отримати всі записи для певного відділення
    public async Task<List<DoctorWorkHistory>> GetByDepartmentIdAsync(Guid departmentId)
    {
        return await _dbSet
            .Where(dwh => dwh.DepartmentId == departmentId)
            .Include(dwh => dwh.Doctor)
            .Include(dwh => dwh.DoctorSpecialization)
            .ToListAsync();
    }
}