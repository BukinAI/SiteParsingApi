namespace business
{
    internal static class StringHelper
    {

        internal static string FindString(List<string> list, string str)
        {
            foreach (var s in list)
            {
                if (s == str)
                {
                    return str;
                }
            }
            return null;
        }

        internal static int GetCount(List<string> list, string str)
        {
            int count = 0;
            foreach (var s in list)
            {
                if (s == str)
                {
                    count++;
                }
            }
            return count;
        }
    }
}