using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Namespace;

[ApiController]
[Route("[controller]")]
[TranslateResultToActionResult]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService) 
    {
        _roleService = roleService;
    }

    [HttpGet(Name = "GetRoles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<RoleDTO>> Get()
    {
        return _roleService.GetRoles().ToActionResult(this);
    }

    [HttpGet("{id}", Name = "GetRoleById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<RoleDTO> Get(int id)
    {
        return _roleService.GetRoleById(id).ToActionResult(this);
    }

    [HttpPost(Name = "PostRole")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<RoleDTO> Post([FromBody] RoleDTO roleDto)
    {
        return _roleService.AddRole(roleDto).ToActionResult(this);
    }

    [HttpPut("{id}", Name = "PutRole")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put(int id, [FromBody] RoleDTO roleDto)
    {
        return _roleService.UpdateRole(id, roleDto).ToActionResult(this);
    }

    [HttpDelete("{id}", Name = "DeleteRole")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<RoleDTO> Delete(int id)
    {
        return _roleService.DeleteRole(id).ToActionResult(this);
    }
}
