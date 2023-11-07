using Ardalis.Result;
using Microsoft.AspNetCore.Mvc.Razor;
using TodoList.Core;

namespace Namespace;

public class RoleService : IRoleService
{
    private readonly IRepository<Role> _roleRepository;

    public RoleService(IRepository<Role> roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Result<RoleDTO> AddRole(RoleDTO roleDto)
    {
        Role role = new()
        {
            RoleName = roleDto.RoleName
        };
        _roleRepository.Add(role);
        _roleRepository.SaveChanges();
        roleDto.Id = role.Id;
        return Result.Success(roleDto);
    }

    public Result<RoleDTO> DeleteRole(int id)
    {
        Role role = _roleRepository.GetById(id);
        if (role == null)
        {
            return Result.NotFound();
        }
        _roleRepository.Remove(role);
        _roleRepository.SaveChanges();
        RoleDTO deletedRoleDto = new()
        {
            Id = role.Id,
            RoleName = role.RoleName
        };
        return Result.Success(deletedRoleDto);
    }

    public Result<RoleDTO> GetRoleById(int id)
    {
        Role role = _roleRepository.GetById(id);
        if (role == null)
        {
            return Result.NotFound();
        }
        return Result.Success(
            new RoleDTO
            {
                Id = role.Id,
                RoleName = role.RoleName
            }
        );
    }

    public Result<IEnumerable<RoleDTO>> GetRoles()
    {
        IEnumerable<RoleDTO> roles = _roleRepository.GetAll()
            .Select(r => new RoleDTO
            {
                Id = r.Id,
                RoleName = r.RoleName
            });
        return Result.Success(roles);
    }

    public Result UpdateRole(int id, RoleDTO roleDto)
    {
        Role role = _roleRepository.GetById(id);
        if (role == null)
        {
            return Result.NotFound();
        }
        role.RoleName = roleDto.RoleName;
        _roleRepository.Update(role);
        _roleRepository.SaveChanges();
        return Result.Success();
    }
}
