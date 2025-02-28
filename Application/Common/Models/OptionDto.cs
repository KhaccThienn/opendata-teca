namespace Application.Common.Models
{
    public class OptionDto<T>
    {
        public T?      Value { get; set; }
        public string? Label { get; set; }
    }
}
