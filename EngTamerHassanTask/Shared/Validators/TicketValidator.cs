namespace EngTamerHassanTask.Domain;

public class TicketValidator : AbstractValidator<Ticket>
{
    public TicketValidator()
    {
        RuleFor(e => e.City).NotEmpty().WithMessage("City Is Required");
        RuleFor(e => e.District).NotEmpty().WithMessage("District Is Required");
        RuleFor(e => e.Governorate).NotEmpty().WithMessage("Governorate Is Required");
        RuleFor(e => e.PhoneNumber).NotEmpty().WithMessage("Phone Number Is Required");

        RuleFor(e => e.PhoneNumber).Matches(@"^01[0125][0-9]{8}$").WithMessage("Enter Valid Phone number");
    }
}