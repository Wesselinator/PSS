using System;

namespace PSS.Business_Logic
{
    static class BetweenExt
    {
        public static bool InclusiveBetween(this IComparable me, IComparable start, IComparable end)
        {
            return me.CompareTo(start) >= 0 && me.CompareTo(end) <= 0;
        }

        public static bool ExclusiveBetween(this IComparable me, IComparable start, IComparable end)
        {
            return me.CompareTo(start) > 0 && me.CompareTo(end) < 0;
        }

        public static bool Between(this IComparable me, IComparable start, IComparable end)
        {
            return me.InclusiveBetween(start, end);
        }
    }
}
