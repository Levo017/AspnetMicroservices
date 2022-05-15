using AutoMapper;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using OrderEntity = Ordering.Domain.Entities.Order;

namespace Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderEntity, Order>().ReverseMap();   

        }
    }
}
