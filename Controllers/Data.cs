using MongoDB.Driver;
using System.Configuration;

namespace GYM_NoSql.Data
{
    public class MongoDbContext
    {
        protected IMongoDatabase db;

        public MongoDbContext()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoConn"].ConnectionString);
            // Usamos el nombre de la base de datos de tu script
            db = client.GetDatabase("GYM_DB");
        }
    }
}