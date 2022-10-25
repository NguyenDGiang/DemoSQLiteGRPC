using Microsoft.Data.Sqlite;

namespace Demo.DBConnect
{
    public class DBContext
    {
        protected string connectionString;
        private readonly IConfiguration configuration;

        protected SqliteConnection ConnectString()
        {
            return new SqliteConnection(connectionString);
        }

        public DBContext()
        {

        }

        public DBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("SQLiteConnection");
        }
    }
}
