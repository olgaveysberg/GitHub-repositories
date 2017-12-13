using System;
using System.Collections.Generic;
using System.Linq;
using Language = GithubRepository.Contracts.Language;

namespace GithubRepository.Accessors
{
    /// <summary>
    /// Class Extensions.
    /// </summary>
    internal static class Helpers
    {
        /// <summary>
        /// Convert Octokit language enum to [id, name] list.
        /// </summary>
        /// <returns>IEnumerable&lt;Language&gt;.</returns>
        /// <exception cref="Exception">Type parameter should be of enum type</exception>
        internal static IEnumerable<Language> GetEnumList()
        {
            var enumType = typeof(Octokit.Language);
            if (!enumType.IsEnum)
                throw new Exception("Type parameter should be of enum type");

            var dic = Enum.GetValues(enumType).Cast<int>()
                .ToDictionary(v => v, v => Enum.GetName(enumType, v));

            return dic.Select(item => new Language {Id = item.Key, Name = item.Value}).ToList();

        }
        
    }
}
