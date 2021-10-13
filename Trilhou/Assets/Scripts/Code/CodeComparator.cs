
public class CodeComparator
{
    public int levelIndex;
    public string levelCode;
    public string[] codes;

    public CodeComparator(string levelCode, string[] codes, int levelIndex)
    {
        this.levelCode = levelCode;
        this.codes = codes;
        this.levelIndex = levelIndex;
    }

    public bool CompareCode()
    {
        return levelCode.ToLower() == codes[levelIndex].ToLower() ? true : false;
    }

    public string Message(string message)
    {
        return message;
    }
}
