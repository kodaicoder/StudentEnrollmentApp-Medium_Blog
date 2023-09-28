using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configuration
{
	internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
				new IdentityRole()
				{
					///You can specific ID by yourself but for now just left it to the program to handle
					Name = "Administrator",
					NormalizedName = "ADMINISTRATOR"
				},
				new IdentityRole()
				{
					///You can specific ID by yourself but for now just left it to the program to handle
					Name = "User",
					NormalizedName = "USER"
				}
			);
		}
	}
}
