using System.Reflection;

namespace Comp214_TeamProject.Utils
{
    /// <summary>
    /// Class built to deal with reflection manipulation.
    /// </summary>
    public class ReflectionUtils
    {
        /// <summary>
        /// Creates a new instance of the given parameterized object using its default constructor.
        /// </summary>
        /// <typeparam name="T">The object to be instantiated.</typeparam>
        /// <returns>The instantiated object.</returns>
        public static T ConstructDefault<T>()
        {
            var type = typeof(T);
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            return (T)constructors[0].Invoke(new object[] { });
        }

        /// <summary>
        /// Creates a new instance of the given parameterized object using its default constructor that will be non public.
        /// </summary>
        /// <typeparam name="T">The object to be instantiated.</typeparam>
        /// <returns>The instantiated object.</returns>
        public static T ConstructDefaultNonPublic<T>()
        {
            var type = typeof(T);
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            return (T)constructors[0].Invoke(new object[] { });
        }
    }
}