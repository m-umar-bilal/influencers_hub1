using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPreProcessing
{
    class Tweets
    {
        public async Task InsertCleanedTweet(string tweet, string trend, string collectionName)
        {

            string cleanedTweet = TextCleaner.cleanText(tweet);
            if (!String.IsNullOrWhiteSpace(tweet) && !String.IsNullOrWhiteSpace(trend) && !String.IsNullOrWhiteSpace(collectionName))
            {
                var collection = DBConnector.Database.GetCollection<BsonDocument>(collectionName);
                var keys = Builders<BsonDocument>.IndexKeys.Ascending("trend").Ascending("tweet");
                var options = new CreateIndexOptions();
                options.Unique = true;
                await collection.Indexes.CreateOneAsync(keys, options);
                var document = new BsonDocument
            {
                { "trend", trend },
                { "tweet", cleanedTweet }
            };

                await collection.InsertOneAsync(document);
            }
            else
            {
                throw new System.ArgumentException("Parameters cannot be null");
            }
        }

        public async Task InsertCleanedTweet(string tweet, string collectionName)
        {

            string cleanedTweet = TextCleaner.cleanText(tweet);
            if (!String.IsNullOrWhiteSpace(tweet) && !String.IsNullOrWhiteSpace(collectionName))
            {
                var collection = DBConnector.Database.GetCollection<BsonDocument>(collectionName);
                var keys = Builders<BsonDocument>.IndexKeys.Ascending("tweet");
                var options = new CreateIndexOptions();
                options.Unique = true;
                await collection.Indexes.CreateOneAsync(keys, options);
                var document = new BsonDocument
            {

                { "tweet", cleanedTweet }
            };

                await collection.InsertOneAsync(document);
            }
            else
            {
                throw new System.ArgumentException("Parameters cannot be null");
            }
        }

        public async Task StoreCleanedTweetsOfCategory(string collectionName, string category ,string newCollecion)
        {
            try
            {
                var collection = DBConnector.Database.GetCollection<BsonDocument>(collectionName);
                var projection = Builders<BsonDocument>.Projection.Include("tweet").Exclude("_id");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("trend_category", category);
                var options = new FindOptions<BsonDocument> { Projection = projection };

                using (var cursor = await collection.FindAsync(filter, options))
                {

                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                           // Console.WriteLine(document[0]);
                            try
                            {
                                // Start the task.
                               await InsertCleanedTweet(TextCleaner.cleanText(document[0].ToString()), newCollecion);

                                // Await the task.

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                continue;
                                // Perform cleanup here.
                            }
                            


                        }
                    }
                }
                Console.WriteLine("DataInserted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Perform cleanup here.
            }
        }
        public async Task StoreCleanedTweetsOfCategory(string collectionName,  string newCollecion)
        {
            try
            {
                var collection = DBConnector.Database.GetCollection<BsonDocument>(collectionName);
                var projection = Builders<BsonDocument>.Projection.Include("tweet").Exclude("_id");
                var filter = new BsonDocument();
                var options = new FindOptions<BsonDocument> { Projection = projection };

                using (var cursor = await collection.FindAsync(filter, options))
                {

                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            // Console.WriteLine(document[0]);
                            try
                            {
                                // Start the task.
                                await InsertCleanedTweet(TextCleaner.cleanText(document[0].ToString()), newCollecion);

                                // Await the task.

                            }
                            catch (Exception )
                            {
                               // Console.WriteLine(e.Message);
                                continue;
                                // Perform cleanup here.
                            }



                        }
                    }
                }
                Console.WriteLine("DataInserted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Perform cleanup here.
            }
        }
    }
}
