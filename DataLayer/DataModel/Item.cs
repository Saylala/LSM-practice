namespace DataLayer.DataModel
{
    public class Item
    {
        public static Item CreateItem(string key, string value)
        {
            return new Item(key, value, false);
        }

        public static Item CreateTombStone(string key)
        {
            return new Item(key, null, true);
        }

        public Item()
        {
        }

        private Item(string key, string value, bool isTombstone)
        {
            Key = key;
            Value = value;
            IsTombStone = isTombstone;
        }

        public string Key { get; set; }

        public string Value { get; set; }

        public bool IsTombStone { get; set; }

        #region EqualityMembers

        private bool Equals(Item other)
        {
            return string.Equals(Key, other.Key)
                   && string.Equals(Value, other.Value)
                   && IsTombStone == other.IsTombStone;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Key?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Value?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ IsTombStone.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}
