namespace Shared.Extensions
{
    public static class GuidExtentions
    {
        public static string ClearAndUpper(this Guid guid)
        {
            return guid.ToString().Replace("-", "").ToUpper();
        }
    }
}
