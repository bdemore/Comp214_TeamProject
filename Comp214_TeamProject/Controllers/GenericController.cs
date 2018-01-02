using Comp214_TeamProject.Patterns;

namespace Comp214_TeamProject.Controllers
{
    /// <summary>
    /// Generic class to be used by all the controller classes.
    /// </summary>
    /// <typeparam name="C"></typeparam>
    public abstract class GenericController<C> : Singleton<C>
        where C : GenericController<C>
    {
    }
}