namespace Inqualitech.Data.Entities
{
    public abstract class ConcurrentEntity<TKey> : Entity<TKey>, IConcurentEntity<TKey>
    {
        public byte[] RowVersion { get; protected set; }
    }
}
