using GithubRepository.Managers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GithubRepository.Api.Controllers
{
    /// <summary>
    /// Class GithubRepositoryController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiVersion("1.0")]
    public class GithubRepositoryController : Controller
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IRepositoryManager _manager;
        private readonly ISession _session;

        /// <summary>
        /// Initializes a new instance of the <see cref="GithubRepositoryController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public GithubRepositoryController(IRepositoryManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _manager = manager;
        }

        /// <summary>
        /// Gets the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="language">The language.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpGet("api/v{version:apiVersion}/GithubRepository")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(typeof(List<Contracts.Repository>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Get(string name, Language? language)
        {
            try
            {
                var result = await _manager.GetRepositories(name, language);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await Console.Error.WriteAsync(ex.Message); //TODO: implement distributed logging
                throw;
            }
        }

        /// <summary>
        /// Gets the languages.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpGet("api/v{version:apiVersion}/GithubRepository/Languages")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetLanguages()
        {
            try
            {
                var result = await _manager.GetLanguages();
                return Ok(result);
            }
            catch (Exception ex)
            {
                await Console.Error.WriteAsync(ex.Message); //TODO: implement distributed logging
                throw;
            }
        }

        /// <summary>
        /// Saves the bookmark.
        /// </summary>
        /// <param name="repositories">The repositories.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPut("api/v{version:apiVersion}/GithubRepository/Bookmark")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(typeof(List<Contracts.Repository>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> SaveBookmark([FromBody] Contracts.Repository[] repositories)
        {
            try
            {
                var bookmark = _session.Get<List<Contracts.Repository>>("Repository");
                if (bookmark != null)
                {
                    bookmark.AddRange(repositories);
                }
                else
                {
                    bookmark = repositories.ToList();
                }
                _session.Set("Repository", bookmark);
                return Ok(_session.Get<List<Contracts.Repository>>("Repository"));
            }
            catch (Exception ex)
            {
                await Console.Error.WriteAsync(ex.Message); //TODO: implement distributed logging
                throw;
            }
        }

        
    }
}
