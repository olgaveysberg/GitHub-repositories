using GithubRepository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Language = GithubRepository.Contracts.Language;
using Repository = GithubRepository.Contracts.Repository;

namespace GithubRepository.Accessors
{
    /// <summary>
    /// Interface IRepositoryAccessor
    /// </summary>
    public interface IRepositoryAccessor
    {
        /// <summary>
        /// Gets the repositories.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="perPage">The per page.</param>
        /// <returns>Task&lt;IEnumerable&lt;Repository&gt;&gt;.</returns>
        Task<IEnumerable<Repository>> GetRepositories(SearchCriteria searchCriteria, int pageNumber, int? perPage);
        /// <summary>
        /// Gets the languages.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;Language&gt;&gt;.</returns>
        Task<IEnumerable<Language>> GetLanguages();
    }
}
