public static class CollectionHelper
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        var maxElement = collection.Max(item => convertToNumber(item));

        return collection.FirstOrDefault(item => convertToNumber(item) == maxElement);
    }
}