using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Champlay.Api.Models;

[Table("playlists")]
public class SupabasePlaylist : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [Column("playlist_url")]
    public string? PlaylistUrl { get; set; }

    [Column("host")]
    public string? Host { get; set; }

    [Column("username")]
    public string? Username { get; set; }

    [Column("password")]
    public string? Password { get; set; }
}