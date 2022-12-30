using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Models.Configuration;

class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> user)
	{
		user.HasKey(x => x.Id);

		user.HasIndex(x => x.Login)
			.IsUnique();

		user.HasIndex(x => x.Email)
			.IsUnique();

		user.Property(x => x.Login)
			.IsRequired()
			.HasMaxLength(24);

		user.Property(x => x.Password)
			.IsRequired()
			.HasMaxLength(32);

		user.Property(x => x.Email)
			.IsRequired();

		user.HasMany(x => x.MovieLists)
			.WithOne(x => x.Owner)
			.HasForeignKey(x => x.OwnerId)
			.IsRequired()
			.OnDelete(DeleteBehavior.Cascade);
	}
}