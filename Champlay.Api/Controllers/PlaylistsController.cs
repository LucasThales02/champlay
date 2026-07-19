using Champlay.Api.Models;
using Champlay.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Champlay.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaylistsController : ControllerBase
{
    private readonly SupabaseService _supabase;

    public PlaylistsController(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await _supabase.Client.InitializeAsync();

        var result = await _supabase.Client
            .From<SupabasePlaylist>()
            .Get();

        return Ok(result.Models);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SupabasePlaylist playlist)
    {
        await _supabase.Client.InitializeAsync();

        playlist.Id = Guid.NewGuid();

        var result = await _supabase.Client
            .From<SupabasePlaylist>()
            .Insert(playlist);

        return Ok(new
        {
            success = true,
            id = playlist.Id,
            name = playlist.Name
        });
    }

    [HttpGet("teste")]
    public async Task<IActionResult> Teste()
    {
        await _supabase.Client.InitializeAsync();

        var playlist = new SupabasePlaylist
        {
            Id = Guid.NewGuid(),
            UserId = Guid.Parse("36609942-e627-43d0-b901-d12ac3862139"),
            Name = "Lista Teste",
            Type = "m3u",
            PlaylistUrl = "https://teste.com/lista.m3u"
        };

        await _supabase.Client
            .From<SupabasePlaylist>()
            .Insert(playlist);

        return Ok(new
        {
            success = true,
            id = playlist.Id,
            userId = playlist.UserId,
            name = playlist.Name,
            type = playlist.Type,
            playlistUrl = playlist.PlaylistUrl
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _supabase.Client.InitializeAsync();

        var playlist = new SupabasePlaylist
        {
            Id = id
        };

        await _supabase.Client
            .From<SupabasePlaylist>()
            .Delete(playlist);

        return Ok(new
        {
            success = true,
            id
        });
    }
}