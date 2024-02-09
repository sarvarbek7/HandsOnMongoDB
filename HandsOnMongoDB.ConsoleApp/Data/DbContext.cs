using MongoDB.Bson;
using MongoDB.Driver;

namespace HandsOnMongoDB.ConsoleApp.Data
{
	public class DbContext
	{
		private readonly MongoClient mongoClient;
		public DbContext()
		{
			this.mongoClient = new MongoClient(
				connectionString: "mongodb://localhost:27017/?directConnection=true");
		}

		public List<BsonDocument> GetDatabasesAsList()
		{
			return mongoClient.ListDatabases().ToList();
		}

		public IMongoDatabase GetDatabaseByName(string databaseName)
		{
			return mongoClient.GetDatabase(databaseName);
		}

		public async Task CreateNewCollectionAsync(IMongoDatabase database, string collectionName)
		{
			await database.CreateCollectionAsync(collectionName);
		}

		public async Task CreateNewCollectionAsync(string databaseName, string collectionName)
		{
			IMongoDatabase database = this.GetDatabaseByName(databaseName);
			await database.CreateCollectionAsync(collectionName);
		}

		public IMongoCollection<BsonDocument> GetMongoCollection(IMongoDatabase database, string collectionName)
		{
			return database.GetCollection<BsonDocument>(name: collectionName);
		}

		public IMongoCollection<BsonDocument> GetMongoCollection(string databaseName, string collectionName)
		{
			IMongoDatabase database = this.GetDatabaseByName(databaseName);

			return database.GetCollection<BsonDocument>(name: collectionName);
		}

		public async Task InsertOneDocumentAsync(IMongoCollection<BsonDocument> collection, BsonDocument document)
		{
			await collection.InsertOneAsync(document);
		}
	}
}
