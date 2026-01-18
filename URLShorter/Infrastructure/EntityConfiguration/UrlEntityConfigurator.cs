using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URLShorter.Domain.Entities;

namespace URLShorter.Infrastructure.EntityConfiguration;

public class UrlEntityConfigurator : IEntityTypeConfiguration<UrlEntity>
{
    public void Configure(EntityTypeBuilder<UrlEntity> builder)
    {
        builder.ToTable("Urls");
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.Property(x=>x.Url).IsRequired();
        builder.Property(x=>x.ShortCode).IsRequired().IsUnicode();
    }
}