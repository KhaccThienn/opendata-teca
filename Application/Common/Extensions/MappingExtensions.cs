namespace Application.Common.Extensions
{
    public static class MappingExtensions
    {
        public static async Task<PagingDto<T>> ToPagedListAsync<T>(this IQueryable<T> source, IPagingModel option, CancellationToken cancellationToken = default)
        {
            // Ensure page number and size are valid
            option.Page = option.Page ?? 1;
            option.Size = option.Size ?? 10;
            option.Size = option.Size > 5000 ? 5000 : option.Size;

            int count = 0;
            int sizeLimit = option.Size.Value;

            // If counting is not required, adjust size limit
            if (option.Countable == false && option.Size > 1)
            {
                sizeLimit++;
            }
            else
            {
                count = await source.CountAsync(cancellationToken);
            }

            // Apply pagination
            if (option.Page > 1)
            {
                source = source.Skip((option.Page.Value - 1) * option.Size.Value);
            }
            source = source.Take(sizeLimit);

            var items = await source.ToListAsync(cancellationToken);

            bool? hasNextPage    = null;
            if (option.Countable == false)
            {
                count = items.Count;
                if (count > option.Size)
                {
                    items.RemoveAt(items.Count - 1);
                    count--;
                    hasNextPage = true;
                }
            }

            var pagedList = new PagingDto<T>
            {
                Items = items,
                Meta  = new PagingModel
                {
                    Page        = option.Page,
                    Size        = option.Size,
                    Count       = count,
                    Countable   = option.Countable,
                    HasNextPage = hasNextPage
                }
            };

            return pagedList;
        }

        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
            => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
    }
}
