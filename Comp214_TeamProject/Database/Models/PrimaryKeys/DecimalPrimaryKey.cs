namespace Comp214_TeamProject.Database.Models.PrimaryKeys
{
    /// <summary>
    /// Decimal primary key representation for model objects.
    /// </summary>
    public class DecimalPrimaryKey : GenericPrimaryKey
    {
        // The decimal key value.
        public decimal Key { get; }

        /// <summary>
        /// Creates a new instance of a DecimalPrimaryKey with ghe given key.
        /// </summary>
        /// <param name="key">The key to be set.</param>
        public DecimalPrimaryKey(decimal key)
        {
            Key = key;
        }

        public override bool Equals(object obj)
        {
            return ((null != obj) && (obj is DecimalPrimaryKey) && (Key == (obj as DecimalPrimaryKey).Key));
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return Key.ToString();
        }
    }
}