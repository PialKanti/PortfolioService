using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace PortfolioService.Infrastructure.Data
{
    public class MongoClientService
    {
        private readonly IMongoDatabase _database;
        public MongoClientService(string connectionString, string database)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(database);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
