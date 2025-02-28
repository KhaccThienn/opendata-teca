namespace Shared.Extensions
{
    public static class DateTimeExtentions
    {
        public static long ToUnixEpochDate(this DateTime date)
        {
            return new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();
        }

        public static string ToISOString(this DateTime time, string format = "o")
        {
            return time.ToString(format);
        }
    }
}
