using Comp214_TeamProject.Database.Models.PrimaryKeys;
using System;

namespace Comp214_TeamProject.Database.Models
{
    /// <summary>
    /// Abstract class that will be the base class for all the model classes.
    /// </summary>
    public abstract class GenericModel<PK> where PK : GenericPrimaryKey
    {
        // The table primary key.
        public PK PrimaryKey { get; set; }

        // The date the object was created on the database.
        public DateTime? CreateDate { get; set; }
    }
}