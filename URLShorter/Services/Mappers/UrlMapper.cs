using URLShorter.Domain.Entities;
using URLShorter.Services.Dto;

namespace URLShorter.Mappers;

public static class UrlMapper
{
    public static UrlEntity ToUrlEntity(this UrlDto url)
    {
        return new UrlEntity
        {
            Id = url.Id,
            Url = url.Url,
            ShortCode = url.ShortCode,
            CreatedAt = url.CreatedAt,
            UpdatedAt = url.UpdatedAt,
            AccessCount = url.AccessCount
        };
    }

    public static UrlDto ToUrlDto(this UrlEntity url)
    {
        return new UrlDto
        {
            Id = url.Id,
            Url = url.Url,
            ShortCode = url.ShortCode,
            CreatedAt = url.CreatedAt,
            UpdatedAt = url.UpdatedAt,
            AccessCount = url.AccessCount
        };
    }
}