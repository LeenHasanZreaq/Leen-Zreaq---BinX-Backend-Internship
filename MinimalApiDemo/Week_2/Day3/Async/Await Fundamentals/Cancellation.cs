using System;
using System.Threading;
using System.Threading.Tasks;



namespace Async
{
    public class DownloadDemo
    {
        public static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            Task downloadTask = DownloadFileAsync(cts.Token);

            Console.WriteLine("Press 'c' to cancel the download...");

            _ = Task.Run(() =>
            {
                if (Console.ReadKey(true).KeyChar == 'c')
                {
                    Console.WriteLine("\nCancel requested by user!");
                    cts.Cancel();
                }
            });

            try
            {
                await downloadTask;
                Console.WriteLine("Download completed successfully!");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Download was cancelled cleanly.");
            }
        }


        public static async Task DownloadFileAsync(CancellationToken token)
        {
            int totalChunks = 10;

            for (int i = 0; i <= totalChunks; i++)
            {
                token.ThrowIfCancellationRequested();

                Console.WriteLine($"Downloading chunk {i}/{totalChunks}...");
                await Task.Delay(1000, token);
            }
        }
    }
}