namespace EngTamerHassanTask.Infrastructure;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).IsRequired();
        builder.Property(t => t.City).IsRequired();
        builder.Property(t => t.District).IsRequired();
        builder.Property(t => t.PhoneNumber).IsRequired();
        builder.Property(t => t.Governorate).IsRequired();
        builder.Property(t => t.CreationDate).IsRequired();
    }
}