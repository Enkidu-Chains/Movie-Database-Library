using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Models.Configuration;

class ImageConfiguration : IEntityTypeConfiguration<Image>
{
	public void Configure(EntityTypeBuilder<Image> image)
	{
		image.HasKey(x => x.Id);

		image.HasIndex(x => x.GoogleDriverFileId)
			.IsUnique();

		image.Property(x => x.GoogleDriverFileId)
			.IsRequired();

		image.HasOne(x => x.Movie)
			.WithOne(x => x.Poster)
			.HasForeignKey<Movie>(x => x.PosterId)
			.IsRequired();
	}
}