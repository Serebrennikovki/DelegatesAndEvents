using System.Collections;

namespace DelegatesAndEvents;

public static class Extensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber)
    {
        var enumerator = collection.GetEnumerator();
        var result = default(T);
        while (enumerator.MoveNext())
        {
            var item = (T)enumerator.Current;
            result = convertToNumber(result) < convertToNumber(item) ? item : result;
        }
        return result;
    }
}