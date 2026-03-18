class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
            return $"{_book} {_chapter}:{_verse}";

        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }

    public static Reference FromString(string input)
    {
        int lastSpace = input.LastIndexOf(" ");
        string book = input.Substring(0, lastSpace);

        string chapterAndVerses = input.Substring(lastSpace + 1);
        string[] parts = chapterAndVerses.Split(":");

        int chapter = int.Parse(parts[0]);

        if (parts[1].Contains("-"))
        {
            var range = parts[1].Split("-");
            return new Reference(book, chapter, int.Parse(range[0]), int.Parse(range[1]));
        }

        return new Reference(book, chapter, int.Parse(parts[1]));
    }
}