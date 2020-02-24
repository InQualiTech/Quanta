namespace Inqualitech.Data.Entities
{
    public interface IConcurentEntity<TKey> : IEntity<TKey>
    {
        public byte[] RowVersion { get;}
    }
}
