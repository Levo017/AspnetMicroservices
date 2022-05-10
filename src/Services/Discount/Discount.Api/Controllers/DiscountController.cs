using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private IDiscountRepository _discountRepository;
        private ILogger<DiscountController> _logger;
        public DiscountController(IDiscountRepository discountRepository, ILogger<DiscountController> logger)
        {
            _discountRepository = discountRepository;
            _logger = logger;
        }

        [HttpGet("{productName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(IEnumerable<Coupon>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Coupon>>> GetDiscount(string productName)
        {
            var coupon = await _discountRepository.GetDiscount(productName);
            return Ok(coupon);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
        {
            await _discountRepository.CreateDiscount(coupon);

            return CreatedAtRoute("GetCoupon", new { productName = coupon.ProductName}, coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDiscount([FromBody] Coupon product)
        {
            return Ok(await _discountRepository.UpdateDiscount(product));
        }

        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDiscount(string productName)
        {
            return Ok(await _discountRepository.DeleteDiscount(productName));
        }
    }
}
