namespace DiscordGameSDKWrapper.Example;

internal class Program
{
    private const long CLIENT_ID = 418559331265675294;

    private static readonly CancellationTokenSource cts = new();
    private static Discord? discordClient;

    static void Main(string[] args)
    {
        Console.WriteLine("Starting discord example...");

        try
        {
            discordClient = new(CLIENT_ID, CreateFlags.Default);
            discordClient.SetLogHook(LogLevel.Debug, (level, message) => Console.WriteLine(message));

            // Periodic task to run callbacks, as if we were in a game loop
            _ = Task.Run(PeriodicTask).ConfigureAwait(false);

            Console.WriteLine("Press 'T' to update the activity, press 'C' to clear it, or press the space bar to exit.");

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Spacebar)
                {
                    break;
                }

                if (key == ConsoleKey.T)
                {
                    Console.WriteLine("Updating activity");

                    discordClient.GetActivityManager().UpdateActivity(new Activity
                    {
                        Name = "DiscordGameSDKWrapper",
                        State = "Playing a game",
                        Details = "Wandering in virtual space"
                    }, result => Console.WriteLine($"Updated activity : {result}"));
                }
                else if (key == ConsoleKey.C)
                {
                    Console.WriteLine("Clearing activity");
                    discordClient.GetActivityManager().ClearActivity(result => Console.WriteLine($"Clear presence: {result}"));
                }
            }

            Console.WriteLine("Stopping...");
            discordClient.Dispose();
            discordClient = null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

#if NET6_0_OR_GREATER
    public static async void PeriodicTask()
    {
        using PeriodicTimer periodicTimer = new(TimeSpan.FromMilliseconds(200));

        while (!cts.IsCancellationRequested && await periodicTimer.WaitForNextTickAsync(cts.Token))
        {
            try
            {
                discordClient?.RunCallbacks();
                discordClient?.GetLobbyManager().FlushNetwork();
            }
            catch (OperationCanceledException)
            {
                // Ignore
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
#else
    public static void PeriodicTask()
    {
        while (!cts.Token.IsCancellationRequested)
        {
            try
            {
                discordClient?.RunCallbacks();
                discordClient?.GetLobbyManager().FlushNetwork();
                Thread.Sleep(200);
            }
            catch (OperationCanceledException)
            {
                // Ignore
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
#endif
}