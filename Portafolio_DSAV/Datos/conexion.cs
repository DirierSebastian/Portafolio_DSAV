using System.Data.SqlClient;
namespace Portafolio_DSAV.Datos
{
    public class conexion
    {
        private string RepositorioContext = string.Empty;
        public conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            RepositorioContext = builder.GetSection("ConnectionStrings:cadenaSql").Value;
        }

        public string getRepositorioContext()
        {
            return RepositorioContext;
        }
    }
}
