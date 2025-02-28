namespace Domain.Exceptions
{
    public class UnsupportedColourException : Exception
    {
        public UnsupportedColourException(string code)
            : base($"Unsupported colour code: {code}")
        {
        }
    }
}
