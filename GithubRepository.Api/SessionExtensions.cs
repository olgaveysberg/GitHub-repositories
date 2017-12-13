using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GithubRepository.Api
{
    /// <summary>
    /// Class SessionExtensions. Extends Session object
    /// </summary>
    // Extension methods enable to "add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.
    public static class SessionExtensions
    {
        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
