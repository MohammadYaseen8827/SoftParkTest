using Platform.Domain.ValueObjects;

namespace Platform.Application.Features.Houses.Commands;
public partial class HouseCommandBase
{
    public  string ImageUrl { get; init; } 

    public  Address Address { get; init; }
}