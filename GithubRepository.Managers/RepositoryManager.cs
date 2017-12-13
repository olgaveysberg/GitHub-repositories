using System;
using GithubRepository.Accessors;
using GithubRepository.Contracts;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using Language = GithubRepository.Contracts.Language;
using Repository = GithubRepository.Contracts.Repository;

namespace GithubRepository.Managers
{
    /// <summary>
    /// Class RepositoryManager.
    /// </summary>
    /// <seealso cref="GithubRepository.Managers.IRepositoryManager" />
    public class RepositoryManager : IRepositoryManager
    {
        /// <summary>
        /// The accessor
        /// </summary>
        private readonly IRepositoryAccessor _accessor;
        /// <summary>
        /// The settings
        /// </summary>
        private readonly RepositoryAppSettings _settings;
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryManager"/> class.
        /// </summary>
        /// <param name="accessor">The accessor.</param>
        /// <param name="settings">The settings.</param>
        public RepositoryManager(IRepositoryAccessor accessor, IOptions<RepositoryAppSettings> settings)
        {
            _accessor = accessor;
            _settings = settings.Value;
        }

        /// <summary>
        /// Gets the repositories.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="language">The language.</param>
        /// <returns>Task&lt;IEnumerable&lt;Repository&gt;&gt;.</returns>
        public async Task<IEnumerable<Repository>> GetRepositories(string name, Octokit.Language? language)
        {
            var searchCriteria = new SearchCriteria
            {
                Name = !string.IsNullOrEmpty(name) ? name : null,
                Language = language
            };

            //If now criteria was provided limits search result for items created no more than one year ago
            //to improve performance. TODO: Implement paging
            if (string.IsNullOrEmpty(name) && language == null)
                searchCriteria.GreaterThan = DateTime.UtcNow.AddYears(_settings.GreaterThan);
            //Limits items per page to improve performance. TODO: Implement paging
            return await _accessor.GetRepositories(searchCriteria, 1, _settings.ItemsPerPage);
        }

        /// <summary>
        /// Gets the languages.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;Contracts.Language&gt;&gt;.</returns>
        public async Task<IEnumerable<Language>> GetLanguages()
        {
            return await _accessor.GetLanguages();
        }
    }
}
