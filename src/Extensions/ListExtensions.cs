using System.Collections.Generic;

namespace API.Extensions
{
    public static class ListExtensions
    {
        public static bool ContainsForAll<T>(this List<T> list, T[] args)
        {
            foreach (var arg in args)
            {
                if (!list.Contains(arg))
                    return false;
            }
            return true;
        }
    }
}
