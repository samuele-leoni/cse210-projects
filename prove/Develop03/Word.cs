class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _isHidden = false;
        _word = word;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
    
    public string GetRenderedText()
    {
        string val = "";
        
        if (_isHidden)
        {
            foreach (char c in _word)
            {
                val += '_';
            }
        }
        else
        {
            val = _word;
        }

        return val;
    }
}