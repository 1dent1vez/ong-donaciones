using System.Configuration;
using System.Data.SqlClient;

namespace OngDonacionesWpf.Data
{
    public static class DbConnectionFactory
    {
        public static SqlConnection Create()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings[""GestionDonacionesONG""].ConnectionString
            );
        }
    }
}
