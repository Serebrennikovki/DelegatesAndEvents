using System.Collections;

namespace DelegatesAndEvents;

public static class Extensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber)
    {
        var result = collection.FirstOrDefault();
        foreach (var item in collection)
        {
            result = convertToNumber(result) < convertToNumber(item) ? item : result;
        }
        return result;
    }
}