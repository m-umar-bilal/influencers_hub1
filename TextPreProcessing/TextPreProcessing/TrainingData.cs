using System;
using MongoDB.Bson;
using MongoDB.Driver;
using TextPreProcessing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DefaultableDictionary;
public class TrainingData
{
    string content ="";
    IDictionary<string,int> wordCount = new Dictionary<string, int>().WithDefaultValue(0);
    string category;

    public IDictionary<string, int> WordCount
    {
        get
        {
            
            return wordCount;
        }

    }

    public TrainingData(string category)
	{
        this.category = category;
        Task.Run(async () =>
        {
            try
            {
                // Start the task.
                await MakeTrainingData();

                // Await the task.

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Perform cleanup here.
            }

        }).Wait();
    }
    
    private void InitializeDictionary()
    {
     /*   
        content.Clear();
        content = new Dictionary<string, string>();
        var getListTask = Category.GetAllCategories(); // returns the Task<List<TvChannel>>

        Task.WaitAll(getListTask); // block while the task completes

        var list = getListTask.Result;
        // Console.WriteLine(list);


        foreach (var document in list)
        {
            content.Add(document, "");
        }
      
    */

    }
    static string[] SplitWords(string s)
    {
      
        return Regex.Split(s, @"\W+");
     
    }

    async Task MakeTrainingData()
    {
        wordCount.Clear();
        wordCount = new Dictionary<string, int>().WithDefaultValue(0);
     //   InitializeDictionary();
        var collection = DBConnector.Database.GetCollection<BsonDocument>("TrainingSample");
        var projection = Builders<BsonDocument>.Projection.Include("tweet").Exclude("_id");
        var builder = Builders<BsonDocument>.Filter;
        var filter = builder.Eq("trend_category", category);
        var options = new FindOptions<BsonDocument> { Projection = projection };
        var count = 0;
        using (var cursor = await collection.FindAsync(filter,options))
        {

            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (var document in batch)
                {
                    // process document
                    content+=TextCleaner.cleanText(document[0].ToString());
                    count++;
                }
            }
            string[] a = SplitWords(content);
           foreach (var s in a)
            {
                wordCount[s] += 1;
            }
          
        }
    }
}
