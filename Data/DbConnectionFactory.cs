using System.Configuration;
using System.Data.SqlClient;
using System.Configuration;
namespace OngDonacionesWpf.Data
{
    public static class DbConnectionFactory
    {
        public static SqlConnection Create()
        {
            var cs = ConfigurationManager.ConnectionStrings["GestionDonacionesONG"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
