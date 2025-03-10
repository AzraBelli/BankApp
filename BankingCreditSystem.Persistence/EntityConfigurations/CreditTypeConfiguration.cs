using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CreditTypeConfiguration : IEntityTypeConfiguration<CreditType>
{
    public void Configure(EntityTypeBuilder<CreditType> builder)
    {
        builder.ToTable("CreditTypes");
        
        builder.HasKey(ct => ct.Id);
        
        builder.Property(ct => ct.Name)
               .HasMaxLength(100)
               .IsRequired();
               
        builder.Property(ct => ct.Description)
               .HasMaxLength(500).IsRequired();
               
        builder.Property(ct => ct.CustomerType)
               .IsRequired();
               
        builder.Property(ct => ct.MinAmount)
               .HasColumnType("decimal(18, 2)")
               .IsRequired();
               
        builder.Property(ct => ct.MaxAmount)
               .HasColumnType("decimal(18, 2)")
               .IsRequired();
               
        builder.Property(ct => ct.MinTerm)
               .IsRequired();
               
        builder.Property(ct => ct.MaxTerm)
               .IsRequired();
               
        builder.Property(ct => ct.BaseInterestRate)
               .HasColumnType("decimal(5, 2)")
               .IsRequired();

        // Self-referencing relationship for hierarchical credit types
        builder.HasOne(ct => ct.ParentCreditType)
               .WithMany(ct => ct.SubCreditTypes)
               .HasForeignKey(ct => ct.ParentCreditTypeId)
               .OnDelete(DeleteBehavior.Restrict);            
   
    }
} 