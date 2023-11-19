namespace EngTamerHassanTask.Domain;

public class Ticket : BaseEntity
{
    public DateTime CreationDate { get; set; }

    public string City { get; set; } = null!;
    public string District { get; set; } = null!;
    public string Governorate { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public bool IsHandled { get; set; } = false;
}