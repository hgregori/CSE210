class Scripture
{
    private string _reference;
    private List<string> _text;

    public string Reference
    {
        get => _reference;
        set => _reference = Reference.FromString(value)
    }
    public List<string> Text
    {
        get => _text;
        set => _text = value ?? _text;
    }

    public Scripture(string reference, string[] text)
    {
        _reference = reference;
        _text = text.ToList();
    }

    public void HideRandomWord(int numberToHide)
    {
        
    }

    public string GetDisplayText()
    {

        return $"{_reference}: {string.Join(" ", _text)}";
    }

    public bool IsCompletelyHidden()
    {
        return false;
    }

    
}