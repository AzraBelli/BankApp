using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CreditApplicationConfiguration : IEntityTypeConfiguration<CreditApplication>
{
    public void Configure(EntityTypeBuilder<CreditApplication> builder)
    {
        builder.ToTable("CreditApplications");
        
        builder.HasKey(ca => ca.Id);
        
        builder.Property(ca => ca.RequestedAmount)
               .HasColumnType("decimal(18, 2)")
               .IsRequired();
               
        builder.Property(ca => ca.RequestedTerm)
               .IsRequired();
               
        builder.Property(ca => ca.ApprovedAmount)
               .HasColumnType("decimal(18, 2)").IsRequired();
               
        builder.Property(ca => ca.ApprovedTerm).IsRequired();

		builder.Property(ca => ca.InterestRate)
               .HasColumnType("decimal(5, 2)").IsRequired();

		builder.Property(ca => ca.MonthlyPayment)
               .HasColumnType("decimal(18, 2)").IsRequired();

		builder.Property(ca => ca.TotalPayment)
               .HasColumnType("decimal(18, 2)").IsRequired();

		builder.Property(ca => ca.Status)
               .IsRequired();
               
        builder.Property(ca => ca.RejectionReason)
               .HasMaxLength(500);

        // Relationships
        builder.HasOne(ca => ca.Customer)
               .WithMany()
               .HasForeignKey(ca => ca.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ca => ca.CreditType)
               .WithMany(ct => ct.CreditApplications)
               .HasForeignKey(ca => ca.CreditTypeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
} 