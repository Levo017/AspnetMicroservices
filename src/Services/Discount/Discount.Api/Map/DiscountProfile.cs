using AutoMapper;
using Discount.API.Entities;
using Discount.Grpc.Protos;

namespace Discount.API.Map
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
