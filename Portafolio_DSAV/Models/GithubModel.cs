namespace Portafolio_DSAV.Models
{
    public class GithubModel
    {

        public List<RepositoryItem> Repositories { get; set; }

    }
    public class RepositoryItem
    {
        public string RepositoryName { get; set; }
        public string RepositoryDescription { get; set; }
        public string RepositoryUrl { get; set; }
    }
}
