using System;
using System.Threading.Tasks;

public class UserServiceAsync
{
    public async Task<string> GetUserProfileAsync(string userId)
    {
        await Task.Delay(2000);
        return $"Profile of user {userId}";
    }


    public async Task<string> GetOrderHistoryAsync(string userId)
    {
        await Task.Delay(2000);
        return $"Orders of user {userId}";
    }


    public static async Task Main(string[] args)
    {
        var service = new UserServiceAsync();
        var start = DateTime.Now;

        Task<string> profileTask = service.GetUserProfileAsync("101");
        Task<string> ordersTask = service.GetOrderHistoryAsync("101");


        await Task.WhenAll(profileTask, ordersTask);

        Console.WriteLine(profileTask.Result);
        Console.WriteLine(ordersTask.Result);
        Console.WriteLine($"Total time: {(DateTime.Now - start).TotalMilliseconds}ms");

        Console.WriteLine("Starting...");

        string result = await GetDataAsync();

        Console.WriteLine(result);
        Console.WriteLine("Done!");
    }

    public static async Task<string> GetDataAsync()
    {
        await Task.Delay(2000).ConfigureAwait(false);
        return "Data";
    }
}