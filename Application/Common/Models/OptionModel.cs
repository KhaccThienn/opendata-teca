namespace Application.Common.Models
{
    public class OptionModel : IPagingModel
    {
        public string? Q         { get; set; }
        public string? Values    { get; set; }
        public int?    Page      { get; set; }
        public int?    Size      { get; set; }
        public int?    Count     { get; set; }
        public string? OrderBy   { get; set; }
        public bool?   Countable { get; set; } = true;

        [JsonIgnore]
        public Dictionary<string, bool>? OrderByObject
        {
            get
            {
                if (!OrderBy.HasValue()) return null;

                try
                {
                    var objValue = OrderBy!.Split(',');
                    var result = new Dictionary<string, bool>();
                    foreach (var item in objValue)
                    {
                        var keyValue = item.Split(' ');
                        result.Add(keyValue[0], keyValue[1].ToLower() == "asc");
                    }
                    return result;
                }
                catch (Exception)
                {
                    throw new System.ComponentModel.DataAnnotations.ValidationException("Tham số OrderBy Không đúng định dạng");
                }
            }
        }
    }
}
