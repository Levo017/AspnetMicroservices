using AutoMapper;
using Discount.API.Entities;
using Discount.API.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using static Discount.Grpc.Protos.DiscountProtoService;

namespace Discount.API.Grpc.Services
{
    public class DiscountService : DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(IDiscountRepository repository, IMapper mapper, ILogger<DiscountService> logger)
        {
            _repository = repository;
            _mapper = mapper;   
            _logger = logger;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetDiscount(request.ProductName);
            var result = _mapper.Map<CouponModel>(coupon);
            return result;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var isSuccess = await _repository.DeleteDiscount(request.ProductName);
            return new DeleteDiscountResponse { Success = isSuccess };
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.CreateDiscount(_mapper.Map<Coupon>(request.Coupon));
            var result = _mapper.Map<CouponModel>(coupon);
            return result;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.CreateDiscount(_mapper.Map<Coupon>(request.Coupon));
            var result = _mapper.Map<CouponModel>(coupon);
            return result;
        }
    }
}
