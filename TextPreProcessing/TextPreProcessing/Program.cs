using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextPreProcessing
{
    class Program
    {

        
        public static void CalculateScore(string [] tweetarr)
        {
            string [] PoliticsLexicon= { 
                                        "morality","politic","politics","political","establishment","humanity","strike",
                                        "conscience",
                                        "law","lawmakers","lawmaker","republican","republic",
                                        "right",
                                        "justice",
                                        "fairness",
                                        "equity",
                                        "judges","judgment",
                                        "nation",
                                        "state",
                                        "government","jalsa","charged",
                                        "decree",
                                        "rule",
                                        "constitution",
                                        "monarchy",
                                        "aristocracy","power","powers","divided","fall","trust",
                                        "republic",
                                        "citizen","peace","victims",
                                        "subject",
                                        "sovereign","stronghold",
                                        "sovereignty", "workers","supporters","workers&supporters",
                                        "government","corner",
                                        "parliament",
                                        "liberalism", "affiliation","mqm","mqms","pak","mqm-pak","crowd",
                                        "life",
                                        "liberty ",    "equality", "egalitarianism",
                                        "force",
                                        "violence","successful","threatens","administrative",
                                        "possession",
                                        "property",
                                        "inheritance",
                                        "alienable",
                                        "libertarianism","united",
                                        "oppression",
                                        "totalitarianism",
                                        "revolution",
                                        "socialism"};
            string [] FoodDrinkLexicon= { "peanut","butter","cheetos","nutella","cookies","bake","cookie","dough","fries","lobster","kfc","foodporn","caramel","cheesecake","macroni", "noodles","chocolate","parfaits","cupcake", "cupcakes","chocolates","frosting", "cream" ,"brownie","brownies","truffle","oreo","cake","yum","yummy","milkshake"};
            string [] ScienceTechnologyLexicon= {"technology" };
            string [] SportsGamingLexicon= {"football","sixes","fours","strikerate","six","record","mcg","xbox","playbold","played","plays","playing","boxing","fast","bowler","batsman","ps4","install","ea","sports","sport","game","gaming","defeat","draw","losers","scored","score","lose","match","innings","training","allrounder","cricket","bowlers","victory"};
            string [] TvMoviesLexicon=
                { "watch","share","movies","movie","Stephen","currys", "walk", "remember"};

            string[] ArtDesignLexicon = {"artwork"};
            string[] FashionLexicon = { "fashion" };
            string[] HealthLexicon = { "health" , "gurantee","care","afford", "guaranteeing" };
            string[] MusicLexicon = { "music" };
            string[] ReligionLexicon = { "religion" };
            string [] winner = { "FoodDrink", "Politics", "TvMovies", "ScienceTechnology", "SportsGaming" , "ArtDesign", "Fashion", "Health", "Music", "Religion" };
            Dictionary<string, double> FoodDrinkWScore = new Dictionary<string, double>();
            Dictionary<string, double> SportsGamingWScore = new Dictionary<string, double>();
            Dictionary<string, double> PoliticsWScore = new Dictionary<string, double>();
            Dictionary<string, double> TvMoviesWScore = new Dictionary<string, double>();
            Dictionary<string, double> ScienceTechnologyWScore = new Dictionary<string, double>();
            Dictionary<string, double> ArtDesignWScore = new Dictionary<string, double>();
            Dictionary<string, double> FashionWScore = new Dictionary<string, double>();
            Dictionary<string, double> HealthWScore = new Dictionary<string, double>();
            Dictionary<string, double> MusicWScore = new Dictionary<string, double>();
            Dictionary<string, double> ReligionWScore = new Dictionary<string, double>();
            TrainingData FoodDrink = new TrainingData("FoodDrink");//0
            var probofClass = 0.1;
            var score = Math.Log(probofClass);
           
            double[] Score = { score, score, score, score , score, score, score, score, score, score, };
            TrainingData Politics = new TrainingData("Politic");//1
            TrainingData TvMovies = new TrainingData("TvMovies");//2
            TrainingData ScienceTechnology = new TrainingData("ScienceTechnlogy");//3
            TrainingData SportsGaming = new TrainingData("SportsGaming");//4
            TrainingData ArtDesign = new TrainingData("ArtDesign");//5
            TrainingData Fashion = new TrainingData("Fashion");//6
            TrainingData Health = new TrainingData("Health");//7
            TrainingData Music = new TrainingData("Music");//8
            TrainingData Religion = new TrainingData("Religion");//9
            HashSet<string> vocab = new HashSet<string>(FoodDrink.Vocabulary);
           
            vocab.UnionWith(SportsGaming.Vocabulary);
            vocab.UnionWith(Politics.Vocabulary);
            vocab.UnionWith(TvMovies.Vocabulary);
            vocab.UnionWith(ScienceTechnology.Vocabulary);
            vocab.UnionWith(ArtDesign.Vocabulary);
            vocab.UnionWith(Fashion.Vocabulary);
            vocab.UnionWith(Health.Vocabulary);
            vocab.UnionWith(Music.Vocabulary);
            vocab.UnionWith(Religion.Vocabulary);
            foreach (var word in vocab)
            {
                if (FoodDrink.WordCount.ContainsKey(word))
                {
                    FoodDrinkWScore.Add(word, (FoodDrink.WordCount[word] + 1) / (FoodDrink.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    FoodDrinkWScore.Add(word, 0);
                }


                if (Politics.WordCount.ContainsKey(word))
                {
                    PoliticsWScore.Add(word, (Politics.WordCount[word] + 1) / (Politics.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    PoliticsWScore.Add(word, 0);
                }


                if (TvMovies.WordCount.ContainsKey(word))
                {
                    TvMoviesWScore.Add(word, (TvMovies.WordCount[word] + 1) / (TvMovies.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    TvMoviesWScore.Add(word, 0);
                }


                if (ScienceTechnology.WordCount.ContainsKey(word))
                {
                    ScienceTechnologyWScore.Add(word, (ScienceTechnology.WordCount[word] + 1) / (ScienceTechnology.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    ScienceTechnologyWScore.Add(word, 0);
                }


                if (SportsGaming.WordCount.ContainsKey(word))
                {
                    SportsGamingWScore.Add(word, (SportsGaming.WordCount[word] + 1) / (SportsGaming.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    SportsGamingWScore.Add(word, 0);
                }

                if (ArtDesign.WordCount.ContainsKey(word))
                {
                    ArtDesignWScore.Add(word, (ArtDesign.WordCount[word] + 1) / (ArtDesign.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    ArtDesignWScore.Add(word, 0);
                }

                if (Fashion.WordCount.ContainsKey(word))
                {
                    FashionWScore.Add(word, (Fashion.WordCount[word] + 1) / (Fashion.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    FashionWScore.Add(word, 0);
                }

                if (Health.WordCount.ContainsKey(word))
                {
                    HealthWScore.Add(word, (Health.WordCount[word] + 1) / (Health.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    HealthWScore.Add(word, 0);
                }

                if (Music.WordCount.ContainsKey(word))
                {
                    MusicWScore.Add(word, (Music.WordCount[word] + 1) / (Music.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    MusicWScore.Add(word, 0);
                }

                if (Religion.WordCount.ContainsKey(word))
                {
                    ReligionWScore.Add(word, (Religion.WordCount[word] + 1) / (Religion.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    ReligionWScore.Add(word, 0);
                }

            }
            int featureScore = 786786;
          //  var FoodDrinkscore = Math.Log(probofClass);
           // var bscore = Math.Log(probofClass);
            foreach (var token in tweetarr)
            {
                if (FoodDrinkWScore.ContainsKey(token)|| FoodDrinkLexicon.Contains(token))
                {

                    if (FoodDrinkLexicon.Contains(token))
                    {
                        Score[0] += Math.Log(featureScore);
                    }
                    else if(FoodDrinkWScore[token] != 0.000000000)
                    {
                       Score[0] += Math.Log(FoodDrinkWScore[token]);
                    }
                }
                if (PoliticsWScore.ContainsKey(token)|| PoliticsLexicon.Contains(token))
                {
                    if(PoliticsLexicon.Contains(token))
                    {
                        Score[1] += Math.Log(featureScore);
                    }
                    else if (PoliticsWScore[token] != 0.000000000)
                    {
                        Score[1] += Math.Log(PoliticsWScore[token]);
                    }
                }
                if (TvMoviesWScore.ContainsKey(token)|| TvMoviesLexicon.Contains(token))
                {

                    if (TvMoviesLexicon.Contains(token))
                    {
                        Score[2] += Math.Log(featureScore);
                    }
                    else if (TvMoviesWScore[token] != 0.000000000)
                    {
                        Score[2] += Math.Log(TvMoviesWScore[token]);
                    }
                }
                if (ScienceTechnologyWScore.ContainsKey(token) || ScienceTechnologyLexicon.Contains(token))
                {
                    if (ScienceTechnologyLexicon.Contains(token))
                    {
                        Score[3] += Math.Log(featureScore);
                    }
                    else if (ScienceTechnologyWScore[token] != 0.000000000)
                    {
                        Score[3] += Math.Log(ScienceTechnologyWScore[token]);
                    }
                }
                if (SportsGamingWScore.ContainsKey(token)|| SportsGamingLexicon.Contains(token))
                {
                    if (SportsGamingLexicon.Contains(token))
                    {
                        
                        Score[4] += Math.Log(featureScore);
                    }
                    else if(SportsGamingWScore[token] != 0.0000000000)
                    {
                        Score[4] += Math.Log(SportsGamingWScore[token]);
                    }
                }
                if (ArtDesignWScore.ContainsKey(token) || ArtDesignLexicon.Contains(token))
                {

                    if (ArtDesignLexicon.Contains(token))
                    {

                        Score[5] += Math.Log(featureScore);
                    }
                    else if (ArtDesignWScore[token] != 0.000000000)
                    {
                        Score[5] += Math.Log(ArtDesignWScore[token]);
                    }
                }
                if (FashionWScore.ContainsKey(token) || FashionLexicon.Contains(token))
                {

                    if (FashionLexicon.Contains(token))
                    {

                        Score[6] += Math.Log(featureScore);
                    }
                    else if(FashionWScore[token] != 0.000000000)
                    {
                        Score[6] += Math.Log(FashionWScore[token]);
                    }
                }
                if (HealthWScore.ContainsKey(token) || HealthLexicon.Contains(token))
                {

                    if (HealthLexicon.Contains(token))
                    {

                        Score[7] += Math.Log(featureScore);
                    }
                    else if (HealthWScore[token] != 0.000000000)
                    {
                        Score[7] += Math.Log(HealthWScore[token]);
                    }
                }
                if (MusicWScore.ContainsKey(token) || MusicLexicon.Contains(token))
                {

                    if (MusicLexicon.Contains(token))
                    {

                        Score[8] += Math.Log(featureScore);
                    }
                    else if (MusicWScore[token] != 0.000000000)
                    {
                        Score[8] += Math.Log(MusicWScore[token]);
                    }
                }
                if (ReligionWScore.ContainsKey(token) || ReligionLexicon.Contains(token))
                {

                    if (ReligionLexicon.Contains(token))
                    {

                        Score[9] += Math.Log(featureScore);
                    }
                    else if (ReligionWScore[token] != 0.000000000)
                    {
                        Score[9] += Math.Log(ReligionWScore[token]);
                    }
                }

            }
            double m = Score.Max();
            int p = Array.IndexOf(Score, m);
           
            Console.WriteLine("Tweet is categorized as "+winner[p]);
        
            Console.WriteLine("food: "+Score[0]);
            Console.WriteLine("Politic: " + Score[1]);
            Console.WriteLine("TvMovie: " + Score[2]);
            Console.WriteLine("Technolgy: " + Score[3]);
            Console.WriteLine("sports: " + Score[4]);
            Console.WriteLine("Art & Design: " + Score[5]);
            Console.WriteLine("Fashion: " + Score[6]);
            Console.WriteLine("Health: " + Score[7]);
            Console.WriteLine("Music: " + Score[8]);
            Console.WriteLine("Religion: " + Score[9]);
            //Console.WriteLine(Politics.WordCount.Values.Max());
            //  Console.WriteLine(bestMove1);

        }
        static void Main(string[] args)
        {
            var tweet = "Why must we guarantee health care as a right? Because people who can’t afford care deserve to live as much as those who can.";
            tweet = TextCleaner.cleanText(tweet);
            string[] tweetarr = TrainingData.SplitWords(tweet);
            Dictionary<string,string> arr= new Dictionary<string, string>();
            foreach (var wd in tweetarr)
            {
               
                arr.Add(wd, wd);
            }
            Program.CalculateScore(arr.Keys.ToArray());
            
          
          
            Console.ReadLine();

         
            

        }
    }
    }


/* for Categories
         static void Main(string[] args)
         {

             var Category = new Category();
             // Catching exceptions for async tasks
            Task.Run(async () =>
             {
                 try
                 {
                     // Start the task.
                      await Category.InsertCategory("TV & Movies");

                     // Await the task.

                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e.Message);
                     // Perform cleanup here.
                 }

             }).Wait();

             var getListTask = Category.GetAllCategories(); // returns the Task<List<TvChannel>>

             Task.WaitAll(getListTask); // block while the task completes

             var list = getListTask.Result;
            // Console.WriteLine(list);


             foreach (var document in list)
             {
                 Console.WriteLine(document);
             }


             //  DataRetrieval d = new DataRetrieval();
             //  d.proc();
             //  Console.ReadLine();
             // String myString;
             // Console.WriteLine("Enter a string having '&' or '\"'  in it, ");
             // myString = Console.ReadLine();
             // myString = "I luv my &lt;3 iphone &amp; @ @umar you’re awsm apple. DisplayIsAwesome, sooo happppppy 🙂 http://www.apple.com”";
             // Console.WriteLine(myString);
             //MessageBox.Show(myString);
             //String myEncodedString = TextCleaner.cleanText(myString);
             // Console.WriteLine("\n\n" + myEncodedString);
             // MessageBox.Show(myEncodedString);
             Console.ReadLine();
         }*/


/* TrainingData c = new TrainingData("FoodDrink");

          foreach (var s in c.WordCount.Keys)
         {
              Console.WriteLine(s+": "+c.WordCount[s]); 
         }

        Console.WriteLine("Vocabulary: " + c.Vocabulary.Count.ToString());
        Console.ReadLine(); */



// FOR ENTERING CLEAN TWEETS TO DATABASE
/* Tweets t = new Tweets();
  Task.Run(async () =>
  {
      try
      {
          // Start the task.
          await t.StoreCleanedTweetsOfCategory("ReligionTweets", "ReligionCTweets");

          // Await the task.

      }
      catch (Exception e)
      {
          Console.WriteLine(e.Message);
          // Perform cleanup here.
      }

  }).Wait();
  Console.WriteLine();
*/



//   KeyValuePair<string, double> bestMove1 = Politics.WordCount.First();
//  foreach (KeyValuePair<string, double> move in Politics.WordCount)
//  {
//       if (move.Value > bestMove1.Value) bestMove1 = move;
//   }
//For Getiting Top N Words WRT Count
/*  var sortedDict = (from entry in SportsGaming.WordCount orderby entry.Value descending select entry)
            .Take(10)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

   foreach (var w in sortedDict)
   {
       Console.WriteLine(w);
   }*/
