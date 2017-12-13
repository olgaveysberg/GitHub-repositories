using System;
using GithubRepository.Contracts;
using Octokit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Language = GithubRepository.Contracts.Language;
using Repository = GithubRepository.Contracts.Repository;

namespace GithubRepository.Accessors
{
    /// <summary>
    /// Class RepositoryAccessor.
    /// </summary>
    /// <seealso cref="GithubRepository.Accessors.IRepositoryAccessor" />
    public class RepositoryAccessor : IRepositoryAccessor
    {
        private const string GitHubClientProductHeaderValue = "IsracardRepositoryApp";
        /// <summary>
        /// Gets the repositories.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="perPage">The per page.</param>
        /// <returns>Task&lt;IEnumerable&lt;Repository&gt;&gt;.</returns>
        public async Task<IEnumerable<Repository>> GetRepositories(SearchCriteria searchCriteria, int pageNumber, int? perPage)
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue(GitHubClientProductHeaderValue));

                var searchCodeRequest = string.IsNullOrEmpty(searchCriteria.Name)
                    ? new SearchRepositoriesRequest()
                    : new SearchRepositoriesRequest(searchCriteria.Name);
                searchCodeRequest.PerPage = perPage ?? 10; //Limits items per page to improve performance. TODO: Implement paging
                searchCodeRequest.Page = pageNumber;

                if (searchCriteria.GreaterThan > DateTime.MinValue)
                    searchCodeRequest.Created = DateRange.GreaterThan(searchCriteria.GreaterThan);
                if (searchCriteria.Language != null) searchCodeRequest.Language = searchCriteria.Language;

                var result = await client.Search.SearchRepo(searchCodeRequest);

                return result.Items.Select(item => new Repository { Name = item.Name, Avatar = item.Owner.AvatarUrl }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e); //TODO: implement distributed logging
                throw;
            }
            
        }

        /// <summary>
        /// Gets the languages.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;Language&gt;&gt;.</returns>
        public async Task<IEnumerable<Language>> GetLanguages()
        {

            var languages = Helpers.GetEnumList();
            return await Task.FromResult(languages);
        }
        
    }
}
