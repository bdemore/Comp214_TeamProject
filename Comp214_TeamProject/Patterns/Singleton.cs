using Comp214_TeamProject.Utils;

namespace Comp214_TeamProject.Patterns
{
    /// <summary>
    /// Abstract class implementing the Singleton design pattern.
    /// </summary>
    /// <typeparam name="T">The class type that should be instantiated</typeparam>
    public abstract class Singleton<T>
    {
        protected static T INSTANCE = default(T);

        /// <summary>
        /// Gets the singleton instance. If not yet created, create the instance dynamically and return it. Otherwise just return the existing instance.
        /// </summary>
        /// <returns>The singleton instance.</returns>
        public static T GetInstance()
        {
            // Using reflection to instantiate the child singleton class.
            if (null == INSTANCE)
            {
                INSTANCE = ReflectionUtils.ConstructDefaultNonPublic<T>();
            }

            return INSTANCE;
        }
    }
}