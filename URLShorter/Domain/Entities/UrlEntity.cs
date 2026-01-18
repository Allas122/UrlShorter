using Microsoft.EntityFrameworkCore;

namespace URLShorter.Domain.Entities;

public class UrlEntity
{
    public int Id { get; set; }
    public string Url { get; set; }
    public string ShortCode {get;set;}
    public DateTime CreatedAt {get;set;}
    public DateTime UpdatedAt {get;set;}
    public int AccessCount {get;set;}

    public UrlEntity()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        AccessCount = 0;
    }
}