using System.Configuration;
using MongoDB.Driver;

namespace _2do.Data.MongoDb
{
    internal static class MongoDbHelper
    {
        private static MongoDatabase _database;

        public static MongoDatabase GetDatabase()
        {
            if (_database == null)
            {
                var connectionstring =
                    ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
                var url = new MongoUrl(connectionstring);
                var client = new MongoClient(url);
                var server = client.GetServer();
                var database = server.GetDatabase(url.DatabaseName);
                _database = database;
            }
            return _database;
        }
    }
}