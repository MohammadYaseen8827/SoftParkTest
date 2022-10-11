using AutoMapper;
using Newtonsoft.Json;
using Platform.Application.Features.Customers.Commands.CreateCustomer;
using Platform.Application.Features.Customers.Commands.UpdateCustomer;
using Platform.Application.Features.Customers.Queries.GetAllCustomers;
using Platform.Application.Features.Houses.Commands.CreateHouse;
using Platform.Application.Features.Houses.Commands.UpdateHouse;
using Platform.Application.Features.Houses.Queries.GetAllHouses;
using Platform.Domain.Entities;
using Platform.Domain.ValueObjects;

namespace Platform.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region customer
            CreateMap<Customer, GetAllCustomersViewModel>()
                .ForMember(x => x.Addresses, o => o.MapFrom(x => JsonConvert.DeserializeObject<List<Address>>(x.Address)))
                .ForMember(x => x.PhoneNumbers, o => o.MapFrom(x => JsonConvert.DeserializeObject<List<string>>(x.PhoneNumber)));

            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(x => x.Address, o => o.MapFrom(x => JsonConvert.SerializeObject(x.Addresses)))
                .ForMember(x => x.PhoneNumber, o => o.MapFrom(x => JsonConvert.SerializeObject(x.PhoneNumbers)));
            CreateMap<UpdateCustomerCommand, Customer>()
                .ForMember(x => x.Address, o => o.MapFrom(x => JsonConvert.SerializeObject(x.Addresses)))
                .ForMember(x => x.PhoneNumber, o => o.MapFrom(x => JsonConvert.SerializeObject(x.PhoneNumbers)));

            CreateMap<GetAllCustomersQuery, GetAllCustomersParameter>();
            #endregion

            #region house
            CreateMap<House, GetAllHousesViewModel>()
                .ForMember(x => x.Address, o => o.MapFrom(x => JsonConvert.DeserializeObject<Address>(x.Address)));

            CreateMap<CreateHouseCommand, House>()
                .ForMember(x => x.Address, o => o.MapFrom(x => JsonConvert.SerializeObject(x.Address)));

            CreateMap<UpdateHouseCommand, House>()
                .ForMember(x => x.Address, o => o.MapFrom(x => JsonConvert.SerializeObject(x.Address)));

            CreateMap<GetAllHousesQuery, GetAllHousesParameter>();
            #endregion
        }
    }
}
