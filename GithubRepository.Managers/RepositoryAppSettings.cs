namespace GithubRepository.Managers
{
    /// <summary>
    /// Class Settings.
    /// </summary>
    public class RepositoryAppSettings
    {
        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        /// <value>The items per page.</value>
        public int ItemsPerPage { get; set; }
        /// <summary>
        /// Gets or sets the date range.
        /// </summary>
        /// <value>The date range.</value>
        public int GreaterThan { get; set; }
    }
}
