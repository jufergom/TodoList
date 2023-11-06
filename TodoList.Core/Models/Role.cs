using Namespace;

namespace TodoList.Core;

public class Role : BaseEntity
{
    public string RoleName { get; set; }

    //navigation properties
    public ICollection<User> Users { get; set; }
}
