namespace LubricantStorage.UI
{
    public static class ParseHelper
    {
        public static double TryParseDoubleOrDefault(string number)
        {
            if (double.TryParse(number, out var result))
            {
                return result;
            }

            return 0;
        }

        public static int TryParseIntOrDefaultValue(string number)
        {
            if (int.TryParse(number, out var result))
            {
                return result;
            }

            return 0;
        }
    }
}