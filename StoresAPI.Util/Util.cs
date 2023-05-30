namespace StoresAPI.Util
{
    public static class Util
    {
        public static string RemoveDashesAndDots(string str)
        {
            return str.Replace(".", "").Replace("-", "");
        }
    }
}
