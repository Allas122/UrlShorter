using Microsoft.EntityFrameworkCore;
using URLShorter.Infrastructure.Data;
using URLShorter.Mappers;
using URLShorter.Services.Dto;
using URLShorter.Services.ServiceLayerExceptions;

namespace URLShorter.Services;

public class UrlService
{
    private readonly DatabaseContext _context;

    public UrlService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<UrlDto> AddUrl(string url)
    {
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) throw new InvalidData("Invalid URL");
        var urlDto = new UrlDto
        {
            Url = url,
            ShortCode = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        var Entity = await _context.Urls.AddAsync(urlDto.ToUrlEntity());
        await _context.SaveChangesAsync();
        return Entity.Entity.ToUrlDto();
    }

    public async Task<UrlDto> GetUrl(string shortCode)
    {
        var entity = await _context.Urls.FirstOrDefaultAsync(url => url.ShortCode == shortCode);
        if (entity == null) throw new EntityNotFound($"{nameof(shortCode)} is null");
        entity.AccessCount += 1;
        await _context.SaveChangesAsync();
        return entity.ToUrlDto();
    }

    public async Task<UrlDto> UpdateUrl(string shortCode, string url)
    {
        var urlEntity = await _context.Urls.FirstOrDefaultAsync(url => url.ShortCode == shortCode);

        if (urlEntity == null) throw new EntityNotFound("url is null");
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) throw new InvalidData("Invalid URL");

        urlEntity.Url = url;
        urlEntity.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return urlEntity.ToUrlDto();
    }

    public async Task DeleteUrl(string shortCode)
    {
        var urlEntity = await _context.Urls.FirstOrDefaultAsync(url => url.ShortCode == shortCode);
        if (urlEntity == null) throw new EntityNotFound("url is null");
        _context.Urls.Remove(urlEntity);
        await _context.SaveChangesAsync();
    }
}