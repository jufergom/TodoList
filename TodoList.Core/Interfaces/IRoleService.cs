using Ardalis.Result;
using TodoList.Core;

namespace Namespace;

public interface IRoleService
{
    Result<IEnumerable<RoleDTO>> GetRoles();
    Result<RoleDTO> GetRoleById(int id);
    Result<RoleDTO> AddRole(RoleDTO roleDto);
    Result UpdateRole(int id, RoleDTO roleDto);
    Result<RoleDTO> DeleteRole(int id);
}
