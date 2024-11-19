using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Reflection;

namespace BLL.Services;

public interface IRoleService
{
    Task<IEnumerable<RoleModel>> GetAllRolesAsync();
    Task AddRoleAsync(RoleModel roleModel);
    Task UpdateRoleAsync(Guid roleId, string newName);
    Task DeleteRoleAsync(Guid roleId);
}

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoleModel>> GetAllRolesAsync()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return _mapper.Map<IEnumerable<RoleModel>>(roles);
    }

    public async Task AddRoleAsync(RoleModel roleModel)
    {
        var role = _mapper.Map<Role>(roleModel);

        // Якщо список користувачів порожній, встановлюємо його як порожній список
        if (roleModel.Users == null || !roleModel.Users.Any())
        {
            role.Users = new List<User>(); // Порожній список
        }

        await _unitOfWork.Roles.AddAsync(role);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateRoleAsync(Guid roleId, string newName)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(roleId);
        if (role == null) throw new KeyNotFoundException("Role not found.");

        role.Name = newName;
        _unitOfWork.Roles.Update(role);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(Guid roleId)
    {
        await _unitOfWork.Roles.DeleteByIdAsync(roleId);
        await _unitOfWork.SaveChangesAsync();
    }
}