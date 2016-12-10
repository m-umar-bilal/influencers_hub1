using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextPreProcessing
{
    class Program
    {

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
        static void Main(string[] args)
        {
            TrainingData c = new TrainingData("TV & Movies");
          
            foreach (var s in c.WordCount.Keys)
            {
                Console.WriteLine(s+": "+c.WordCount[s]); 
            }
            Console.ReadLine();
        }
    }
    }
