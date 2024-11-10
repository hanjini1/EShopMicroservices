﻿namespace Ordering.Infrastructure.Data.Interceptor
{
    public class AduitableEntityInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        private void UpdateEntities(DbContext? context)
        {
            if (context is null) return;
            foreach (var entry in context.ChangeTracker.Entries<IEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = "Harish";
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                if (entry.State is EntityState.Added || entry.State is EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.LastModifiedBy = "Harish";
                    entry.Entity.LastModifiedAt = DateTime.UtcNow;
                }
            }
        }

    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r => r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && 
        (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}