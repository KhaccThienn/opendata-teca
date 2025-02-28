namespace Infrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        private readonly IUser        _user;
        private readonly TimeProvider _dateTime;

        public AuditableEntityInterceptor(IUser user, TimeProvider timeProvider)
        {
            _user         = user;
            _dateTime     = timeProvider;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _user.Id;
                    entry.Entity.Created   = _dateTime.GetUtcNow();
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.LastModifiedBy = _user.Id;
                    entry.Entity.LastModified   = _dateTime.GetUtcNow();
                }
            }
        }
    }
}
