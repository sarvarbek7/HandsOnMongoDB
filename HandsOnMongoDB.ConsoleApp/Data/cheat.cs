//using MongoDB.Bson;
//using MongoDB.Driver;

//namespace HandsOnMongoDB.ConsoleApp.Data
//{
//	public class DbContext
//	{
//		private readonly MongoClient mongoClient;

//		/// <summary>
//		/// DbContext connect database.
//		/// </summary>
//		public DbContext()
//		{
//			this.mongoClient =
//				new MongoClient(new MongoUrl("mongodb://localhost:27017/?directConnection=true"));
//		}

//		public IMongoDatabase ConnectDatabase(string databaseName)
//		{
//			try
//			{
//				return mongoClient.GetDatabase(databaseName);
//			}
//			catch (Exception ex)
//			{
//				Console.WriteLine(ex);
//				throw;
//			}
//		}

//		public async Task CreateCollectionAsync(string databaseName, string collectionName, CancellationToken token = default)
//		{
//			await this.ConnectDatabase(databaseName)
//				.CreateCollectionAsync(collectionName, cancellationToken: token);
//		}

//		public async Task CreateCollectionAsync(IMongoDatabase database, string collectionName, CancellationToken cancellationToken = default)
//		{
//			await database.CreateCollectionAsync(collectionName, cancellationToken: cancellationToken);
//		}

//		public IMongoCollection<BsonDocument> GetCollection(string databaseName, string collectionName)
//		{
//			return this.ConnectDatabase(databaseName).GetCollection<BsonDocument>(collectionName);
//		}

//		public IMongoCollection<BsonDocument> GetCollection(IMongoDatabase database, string collectionName)
//		{
//			return database.GetCollection<BsonDocument>(collectionName);
//		}
//	}
//}
