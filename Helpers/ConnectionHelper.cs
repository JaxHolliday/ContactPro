using Npgsql;

namespace ContactPro.Helpers
{
    //static - can only be one , dont haft to create instance
    //Static == class that cannot be instantiated 
    //making static so we dont haft to create instance 
    public static class ConnectionHelper
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("pgSettings")["pgConnection"];
            //checks environment that we go to
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            return String.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        //building connection string from the environment. i.e heroku
        private static string BuildConnectionString(string databaseUrl)
        {
            //Universal resource identity 
            var databaseUri = new Uri(databaseUrl);
            //split into array to access individually
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };

            return builder.ToString();  

        }
    }
}
