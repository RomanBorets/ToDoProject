namespace ToDoProject.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static List<TResult> Empty<TResult>(this List<TResult> list)
        {
            return new List<TResult>();
        }

        public static ICollection<TResult> Empty<TResult>(this ICollection<TResult> collection)
        {
            return new List<TResult>();
        }
    }
}
