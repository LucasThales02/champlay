namespace Champlay.Api.Models;

public class Playlist
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string? PlaylistUrl { get; set; }

    public string? Host { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}