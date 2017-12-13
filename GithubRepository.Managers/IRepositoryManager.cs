using Octokit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repository = GithubRepository.Contracts.Repository;

namespace GithubRepository.Managers
{
    /// <summary>
    /// Interface IRepositoryManager
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// Gets the repositories.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="language">The language.</param>
        /// <returns>Task&lt;IEnumerable&lt;Repository&gt;&gt;.</returns>
        Task<IEnumerable<Repository>> GetRepositories(string name, Language? language);
        /// <summary>
        /// Gets the languages.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;Contracts.Language&gt;&gt;.</returns>
        Task<IEnumerable<Contracts.Language>> GetLanguages();
    }
}
