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
}