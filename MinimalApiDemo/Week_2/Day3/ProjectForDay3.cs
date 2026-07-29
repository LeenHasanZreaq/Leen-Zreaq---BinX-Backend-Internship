using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Sequential Calls \n");
            await RunSequentialAsync();

            Console.WriteLine("\n2. Concurrent Calls (Task.WhenAll) \n");
            await RunConcurrentAsync();

            Console.WriteLine("\n 3. Cancellation Demo \n");
            await RunCancellationDemoAsync();

            Console.WriteLine("\nAll demos finished.");
        }



        static async Task<string> GetFromDatabaseAsync()
        {
            await Task.Delay(2000);
            return "Data from Database";
        }

        static async Task<string> GetFromApiAsync()
        {
            await Task.Delay(1500);
            return "Data from API";
        }

        static async Task<string> GetFromCacheAsync(CancellationToken token = default)
        {
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();
                await Task.Delay(300, token);
            }
            return "Data from Cache";
        }


        static async Task RunSequentialAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            string dbResult = await GetFromDatabaseAsync();
            Console.WriteLine(dbResult);

            string apiResult = await GetFromApiAsync();
            Console.WriteLine(apiResult);

            string cacheResult = await GetFromCacheAsync();
            Console.WriteLine(cacheResult);

            stopwatch.Stop();
            Console.WriteLine($"Total elapsed (sequential): {stopwatch.ElapsedMilliseconds}ms");
        }


        static async Task RunConcurrentAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            Task<string> dbTask = GetFromDatabaseAsync();
            Task<string> apiTask = GetFromApiAsync();
            Task<string> cacheTask = GetFromCacheAsync();

            await Task.WhenAll(dbTask, apiTask, cacheTask);

            Console.WriteLine(dbTask.Result);
            Console.WriteLine(apiTask.Result);
            Console.WriteLine(cacheTask.Result);

            stopwatch.Stop();
            Console.WriteLine($"Total elapsed (concurrent): {stopwatch.ElapsedMilliseconds}ms");
        }


        static async Task RunCancellationDemoAsync()
        {
            var cts = new CancellationTokenSource();

            cts.CancelAfter(700);

            try
            {
                string result = await GetFromCacheAsync(cts.Token);
                Console.WriteLine(result);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Cache read was cancelled mid-operation!");
            }
        }
    }
}