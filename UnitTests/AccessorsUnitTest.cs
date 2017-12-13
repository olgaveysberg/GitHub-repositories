using System.Linq;
using GithubRepository.Accessors;
using GithubRepository.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Language = Octokit.Language;

namespace UnitTests
{
    /// <summary>
    /// Class AccessorsUnitTest.
    /// </summary>
    [TestClass]
    public class AccessorsUnitTest
    {
        /// <summary>
        /// Gets the repositories test method.
        /// </summary>
        [TestMethod]
        public void GetRepositoriesTestMethod()
        {
            var accessor = new RepositoryAccessor();
            var searchCriteria = new SearchCriteria
            {
                Language = Language.Abap
            };

            var result = accessor.GetRepositories(searchCriteria, 1, 10).Result;
            Assert.AreEqual(result.Count(), 10);
        }

        /// <summary>
        /// Gets the languages test method.
        /// </summary>
        [TestMethod]
        public void GetLanguagesTestMethod()
        {
            var accessor = new RepositoryAccessor();
            
            var result = accessor.GetLanguages().Result;
            Assert.AreNotEqual(result.Count(), 0);
        }
    }
}
