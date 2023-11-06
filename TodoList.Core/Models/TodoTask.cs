using Namespace;

namespace TodoList.Core;

public class TodoTask : BaseEntity
{
    public string Description { get; set; }
    public bool Completed { get; set; }

    public int UserId { get; set; }

    //navigation properties
    public User User;
}
