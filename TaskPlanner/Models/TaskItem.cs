namespace TaskPlanner.Models;

public enum Priority { Low, Medium, High }

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Hashtag { get; set; }
    public string? Comment { get; set; }
    public string? AttachmentPath { get; set; }
    public bool IsCompleted { get; set; }

    public int? ParentTaskId { get; set; }
    public TaskItem? ParentTask { get; set; }
    public ICollection<TaskItem> SubTasks { get; set; } = new List<TaskItem>();
}