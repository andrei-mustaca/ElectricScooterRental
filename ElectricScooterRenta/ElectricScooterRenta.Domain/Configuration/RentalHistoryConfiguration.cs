using ElectricScooterRenta.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectricScooterRenta.Domain.Configuration;

public class RentalHistoryConfiguration:IEntityTypeConfiguration<RentalHistory>
{
    public void Configure(EntityTypeBuilder<RentalHistory> builder)
    {
        builder.HasKey(x =>x.Id);
        builder.HasOne(x => x.Rental)
            .WithMany(r => r.History)
            .HasForeignKey(x => x.RentalId);
    }
}