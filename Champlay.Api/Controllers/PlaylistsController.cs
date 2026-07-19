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

        return Ok(result.Models.FirstOrDefault());
    }

    [HttpGet("teste")]
    public async Task<IActionResult> Teste()
    {
        await _supabase.Client.InitializeAsync();

        var playlist = new SupabasePlaylist
        {
            Id = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            Name = "Lista Teste",
            Type = "m3u",
            PlaylistUrl = "https://teste.com/lista.m3u"
        };

        var result = await _supabase.Client
            .From<SupabasePlaylist>()
            .Insert(playlist);

        return Ok(result.Models);
    }
}