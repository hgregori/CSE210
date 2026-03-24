class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private Date _uploadDate;
    private List<Comment> _comments = new();

    public Video(string title, string author, int lengthInSeconds, Date uploadDate)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _uploadDate = uploadDate;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine($"Uploaded on: {_uploadDate.GetFullDate()}");
        Console.WriteLine($"Comments ({GetCommentCount()}):");

        foreach (Comment c in _comments)
        {
            Console.WriteLine($" - {c.GetCommenterName()}: {c.GetCommentText()}");
        }

        Console.WriteLine();
    }
}