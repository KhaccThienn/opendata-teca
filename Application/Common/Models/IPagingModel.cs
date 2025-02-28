namespace Application.Common.Models
{
    public interface IPagingModel
    {
        int?  Page      { get; set; }
        int?  Size      { get; set; }
        bool? Countable { get; set; }
    }
}
