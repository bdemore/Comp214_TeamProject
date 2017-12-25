using Comp214_TeamProject.Database.Models.PrimaryKeys;

namespace Comp214_TeamProject.Database.Models
{
    /// <summary>
    /// A domain model class. It will be a class with only 3 fields:
    /// <ul>
    ///     <li>PrimaryKey</li>
    ///     <li>Name</li>
    ///     <li>CreateDate</li>
    /// </ul>
    /// </summary>
    /// <typeparam name="PK"></typeparam>
    public abstract class DomainModel<PK> : GenericModel<PK>
        where PK : GenericPrimaryKey
    {
        // The domain model's name.
        public string Name { get; set; }
    }
}