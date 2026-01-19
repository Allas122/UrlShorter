using URLShorter.Controller.Messages;
using URLShorter.Services.Dto;

namespace URLShorter.Controller.Mappers;

public static class UrlMapper
{
    public static ShorterUrlMessage ToShorterUrlMessage(this UrlDto url)
    {
        return new ShorterUrlMessage
        {
            Id = url.Id,
            Url = url.Url,
            ShortCode = url.ShortCode,
            CreatedAt = url.CreatedAt,
            UpdatedAt = url.UpdatedAt
        };
    }

    public static ShortedUrlMessageWithStats ToShorterUrlMessageWithStats(this UrlDto url)
    {
        return new ShortedUrlMessageWithStats
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