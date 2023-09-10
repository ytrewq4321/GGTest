public static class StringArray
{
    public static string[] Values { get; private set; }

    static StringArray()
    {
        CreateValues();
    }

    private static void CreateValues()
    {
        Values = new string[101];
        for (int i = 0; i <= 100; i++)
        {
            Values[i] = i.ToString();
        }
    }
}
