namespace Platform.Domain.Entities;

public class House : BaseAuditableEntity
{
    public string? Address { get; set; }

    public OfferType OfferType { get; set; }

    public string? ImageUrl { get; set; }
}
