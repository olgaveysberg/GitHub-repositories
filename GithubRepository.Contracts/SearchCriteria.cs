using System;

namespace GithubRepository.Contracts
{
    /// <summary>
    /// Class SearchCriteria.
    /// </summary>
    public class SearchCriteria 
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>The language.</value>
        public Octokit.Language? Language { get; set; }
        /// <summary>
        /// Gets or sets the greater than.
        /// </summary>
        /// <value>The greater than.</value>
        public DateTime GreaterThan { get; set; }
    }
}
