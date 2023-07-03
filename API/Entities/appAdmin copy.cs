namespace API.Entities;
public class Quiz
{
    public int Id { get; set; }
    public string IdCreator { get; set; }
    public DateTime Create { get; set; } = DateTime.UtcNow;
    public string Caption { get; set; }
    public string Text { get; set; }
    public string Solution { get; set; }
}