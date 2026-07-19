using Supabase;

namespace Champlay.Api.Services;

public class SupabaseService
{
    public Client Client { get; }

    public SupabaseService()
    {
        var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
        var key = Environment.GetEnvironmentVariable("SUPABASE_SERVICE_KEY");

        Client = new Client(url!, key!);
    }
}