using Microsoft.AspNetCore.Mvc;
using Octokit;
using Portafolio_DSAV.Datos;
using Portafolio_DSAV.Models;

namespace Portafolio_DSAV.Controllers
{
    public class PerfilController : Controller
    {
        private static readonly string accessToken = "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";
        private static readonly string owner = "DirierSebastian";


        RepositorioDatos _repositorioDatos = new RepositorioDatos();
        public IActionResult Inicio()
        {
            var lista = _repositorioDatos.Listar();
            return View(lista);
        }

        public IActionResult Listar()
        {
            var lista = _repositorioDatos.Listar();
            return View(lista);
        }

        public async Task<IActionResult> Proyectos()
        {
            var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            github.Credentials = new Credentials(accessToken);

            try
            { 
            var repositories = await github.Repository.GetAllForUser(owner);
            var repositoryList = new List<RepositoryItem>();

            foreach (var repo in repositories)
            {
                var repositoryItem = new RepositoryItem
                {
                    RepositoryName = repo.Name,
                    RepositoryDescription = repo.Description,
                    RepositoryUrl = repo.HtmlUrl
                };
                repositoryList.Add(repositoryItem);
            }

            var model = new GithubModel
            {
                Repositories = repositoryList
            };

            return View(model);
            }
            catch (Exception ex)
            {
                
            }

            return View();
        }

        public IActionResult Contactos()
        {
            return View();
        }
    }
}
