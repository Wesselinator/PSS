using System.Collections.Generic;
namespace PSS.Business_Logic
{
    public static class PSSListExtentions
    {
        public static BaseList<T> ToBaseList<T>(this IEnumerable<T> source) where T : BaseTable, new()
        {
            BaseList<T> ret = new BaseList<T>();
            foreach (T item in source)
            {
                ret.Add(item);
            }
            return ret;
        }
    }
}
