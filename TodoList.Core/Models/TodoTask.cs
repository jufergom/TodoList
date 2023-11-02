namespace TodoList.Core;

public class TodoTask
{
    public int TodoTaskId { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }

    public int UserId { get; set; }

    //navigation properties
    public User User;
}
