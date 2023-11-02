namespace TodoList.Core;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public int RoleId { get; set; }

    //navigation properties
    public Role Role { get; set; }
    public ICollection<TodoTask> TodoTasks { get; set; }
}
