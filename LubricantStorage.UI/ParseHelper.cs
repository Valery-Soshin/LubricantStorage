namespace LubricantStorage.UI
{
    public static class ParseHelper
    {
        public static double TryParseOrDefaultValue(string number)
        {
            if (double.TryParse(number, out var result))
            {
                return result;
            }

            return 0;
        }
    }
}