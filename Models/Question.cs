public class Question
{
    public string question { get; set; }
    public List<string> answers { get; set; }

    public Question()
    {
        answers = new List<string>();
    }
}