namespace Application.Common.Models
{
    public class ResultDto
    {
        public object? Item { get; set; }
    }

    public class ResultDto<T>
    {
        public T? Item { get; set; }
    }

    public class ResultsDto
    {
        public object[]? Items { get; set; }
    }

    public class ResultsDto<T>
    {
        public T[]? Items { get; set; }
    }
}
