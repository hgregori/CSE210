class Reference
{
    private string _book;
    private int _chapter; 
    private int _Verse;  
    private int _endVerse;
    
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _Verse = verse;
        _endVerse = verse;
    }   

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _Verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return _endVerse > _Verse ? $"{_book} {_chapter}:{_Verse}-{_endVerse}" : $"{_book} {_chapter}:{_Verse}";
    }
    public static Reference FromString(string input)
    {    
    // Example input: "John 3:4-5"

    // 1. Split book name from chapter/verse
        int lastSpaceIndex = input.LastIndexOf(' ');
        string book = input.Substring(0, lastSpaceIndex);
        string chapterAndVerses = input.Substring(lastSpaceIndex + 1);
        
        // 2. Split chapter from verse(s)
        var chapterAndRest = chapterAndVerses.Split(':');
        int chapter = int.Parse(chapterAndRest[0]);

        // 3. Determine if there is a verse range
        if (chapterAndRest[1].Contains('-'))
        {
            var parts = chapterAndRest[1].Split('-'); // "4-5"
            int verse = int.Parse(parts[0]);
            int endVerse = int.Parse(parts[1]);
            return new Reference(book, chapter, verse, endVerse);
        }
        else
        {
            int verse = int.Parse(chapterAndRest[1]);
            return new Reference(book, chapter, verse);
        }
    }
}