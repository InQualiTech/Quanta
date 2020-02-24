namespace Inqualitech.Data.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        private int? _hashCode;
        public virtual TKey Id { get; set; }

        public virtual bool IsTransient() => Id.Equals(default(TKey));

        public override bool Equals(object obj)
        {
            if (!(obj is IEntity<TKey>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            IEntity<TKey> item = (IEntity<TKey>)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                
                if (!_hashCode.HasValue)
                    // XOR for random distribution 
                    // (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                    _hashCode = Id.GetHashCode() ^ 31; 
                return _hashCode.Value;
            }
            else
                return base.GetHashCode();

        }

        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            if (object.Equals(left, null))
                return (object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }
    }

}
