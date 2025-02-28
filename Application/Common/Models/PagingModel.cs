namespace Application.Common.Models
{
    public record PagingModel : IPagingModel
    {
        public int?  Page        { get; set; }
        public int?  Size        { get; set; }
        public int?  Count       { get; set; }
        public bool? Countable   { get; set; }
        public bool? HasNextPage { get; set; }
    }
}
