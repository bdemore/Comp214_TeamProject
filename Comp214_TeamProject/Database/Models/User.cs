using Comp214_TeamProject.Database.Models.PrimaryKeys;

namespace Comp214_TeamProject.Database.Models
{
    /// <summary>
    /// Class that will represent the data found in the TBUB_USERS table.
    /// </summary>
    public class User : GenericModel<DecimalPrimaryKey>
    {
        // The user's email.
        public string Email { get; set; }

        // The user's password.
        public string Password { get; set; }

        // The user's first name.
        public string FirstName { get; set; }

        // The user's last name.
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            return ((null != obj) && (obj is User) && PrimaryKey.Equals((obj as User).PrimaryKey));
        }

        public override int GetHashCode()
        {
            return PrimaryKey.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("User: {{ PrimaryKey: \"{0}\", Email: \"{1}\", Name: \"{2} {3}\" }}", PrimaryKey, Email, FirstName, LastName);
        }
    }
}