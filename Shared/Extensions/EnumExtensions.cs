namespace Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string? GetName(this Enum source)
        {
            FieldInfo? fi = source.GetType()?.GetField(source.ToString());
            if (fi == null) return null;
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}
