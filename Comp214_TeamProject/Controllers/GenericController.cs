using Comp214_TeamProject.Patterns;
using Comp214_TeamProject.Utils;

namespace Comp214_TeamProject.Controllers
{
    /// <summary>
    /// Generic class to be used by all the controller classes.
    /// </summary>
    /// <typeparam name="C"></typeparam>
    public abstract class GenericController<C> : Singleton<C>
        where C : GenericController<C>
    {
        // The parameter prefix.
        protected string paramPrefix = DatabaseUtils.IsOracle() ? "" : "@";
    }
}