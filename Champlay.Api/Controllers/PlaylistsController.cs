using Microsoft.AspNetCore.Mvc;
using Champlay.Api.Models;

namespace Champlay.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaylistsController : ControllerBase
{
    private static readonly List<Playlist> Playlists = [];

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Playlists);
    }

    [HttpPost]
    public IActionResult Create(Playlist playlist)
    {
        playlist.Id = Guid.NewGuid();

        Playlists.Add(playlist);

        return Ok(playlist);
    }
}