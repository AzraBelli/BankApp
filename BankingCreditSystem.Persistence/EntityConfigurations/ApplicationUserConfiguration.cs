using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations
{
	public class ApplicationUserConfiguration:IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.ToTable("ApplicationUsers");
			builder.Property(u => u.PhoneNumber).HasMaxLength(15).IsRequired();			
			builder.Property(u => u.Address).HasMaxLength(200).IsRequired();
			builder.HasOne(u => u.Customer)
				.WithOne(c => c.User)
				.HasForeignKey<Customer>(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);
			


		}
	}
}
