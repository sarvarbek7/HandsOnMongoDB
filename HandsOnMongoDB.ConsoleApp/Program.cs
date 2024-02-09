using HandsOnMongoDB.ConsoleApp.Data;

using MongoDB.Bson;
using MongoDB.Driver;

namespace HandsOnMongoDB.ConsoleApp
{
	public class Program
	{
		private static void Main(string[] args)
		{
			var dbContext = new DbContext();

			IMongoCollection<BsonDocument>? collection = dbContext.GetMongoCollection(
				databaseName: "countyDb",
				collectionName: "countries");

			FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Empty;

			long count = collection.CountDocuments(filter);
			Console.WriteLine(count);

			BsonDocument document = new BsonDocument
			{
				{ "name", "Sarvar"},
				{"location", new BsonDocument
					{
						{"lan", "23.12312" },
						{"lon", "123.12312" }
					}
				}
			};

			dbContext.InsertOneDocumentAsync(collection, document);
		}
	}
}