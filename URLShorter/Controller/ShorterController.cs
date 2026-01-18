using Microsoft.AspNetCore.Mvc;
using URLShorter.Controller.Mappers;
using URLShorter.Controller.Messages;
using URLShorter.Domain.Entities;
using URLShorter.Infrastructure.Data;
using URLShorter.Mappers;
using URLShorter.Services;
using URLShorter.Services.Dto;

namespace URLShorter.Controller;
[ApiController]
public class ShorterController(UrlService urlService) : ControllerBase
{
    
    private UrlService _urlService = urlService;

    [HttpPost("/shorter")]
    public async Task<IActionResult> Shorter(string url)
    {
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return BadRequest("Invalid URL");
        }
        var urlDto = await _urlService.AddUrl(url);
        return Ok(urlDto);
    }

    [HttpGet("/shorter/{shortCode}")]
    public async Task<IActionResult> ShorterGet([FromRoute] string shortCode)
    {
        try
        {
            UrlDto urlDto = await _urlService.GetUrl(shortCode);
            return Ok(urlDto.ToShorterUrlMessage());
        }
        catch (NullReferenceException e)
        {
            return NotFound("No URL found");
        }
    }

    [HttpPut("/shorter/{shortCode}")]
    public async Task<IActionResult> ShorterPut([FromRoute] string shortCode, string url)
    {
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return BadRequest("Invalid URL");
        }
        try
        {
            UrlDto urlDto = await _urlService.UpdateUrl(shortCode, url);
            return Ok(urlDto.ToShorterUrlMessage());
        }
        catch (NullReferenceException e)
        {
            return NotFound("No URL found");
        }
    }

    [HttpDelete("/shorter/{shortCode}")]
    public async Task<IActionResult> ShorterDelete([FromRoute] string shortCode)
    {
        try
        {
            await _urlService.DeleteUrl(shortCode);
            return NoContent();
        }
        catch (NullReferenceException e)
        {
            return NotFound("No URL found");
        }
        
    }

    [HttpGet("/shorter/{shortCode}/stats")]
    public async Task<IActionResult> ShorterStats([FromRoute] string shortCode)
    {
        try
        {
            UrlDto urlDto = await _urlService.GetUrl(shortCode);
            return Ok(urlDto.ToShorterUrlMessageWithStats());
        }
        catch (NullReferenceException e)
        {
            return NotFound("No URL found");
        }
    }
}