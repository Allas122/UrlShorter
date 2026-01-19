using Microsoft.AspNetCore.Mvc;
using URLShorter.Controller.Mappers;
using URLShorter.Services;

namespace URLShorter.Controller;

[ApiController]
public class ShorterController(UrlService urlService) : ControllerBase
{
    private readonly UrlService _urlService = urlService;

    [HttpPost("/shorter")]
    public async Task<IActionResult> Shorter(string url)
    {
        var urlDto = await _urlService.AddUrl(url);
        return Ok(urlDto);
    }

    [HttpGet("/shorter/{shortCode}")]
    public async Task<IActionResult> ShorterGet([FromRoute] string shortCode)
    {
        var urlDto = await _urlService.GetUrl(shortCode);
        return Ok(urlDto.ToShorterUrlMessage());
    }

    [HttpPut("/shorter/{shortCode}")]
    public async Task<IActionResult> ShorterPut([FromRoute] string shortCode, string url)
    {
        var urlDto = await _urlService.UpdateUrl(shortCode, url);
        return Ok(urlDto.ToShorterUrlMessage());
    }

    [HttpDelete("/shorter/{shortCode}")]
    public async Task<IActionResult> ShorterDelete([FromRoute] string shortCode)
    {
        await _urlService.DeleteUrl(shortCode);
        return NoContent();
    }

    [HttpGet("/shorter/{shortCode}/stats")]
    public async Task<IActionResult> ShorterStats([FromRoute] string shortCode)
    {
        var urlDto = await _urlService.GetUrl(shortCode);
        return Ok(urlDto.ToShorterUrlMessageWithStats());
    }
}