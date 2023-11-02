namespace TodoList.Core;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }

    //navigation properties
    public ICollection<User> Users { get; set; }
}
