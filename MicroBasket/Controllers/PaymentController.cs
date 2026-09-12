using MicroBasket.Models.DTOs.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using Razorpay.Api.Errors;

namespace MicroBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly string _keyId;
        private readonly string _keySecret;

        public PaymentController(IConfiguration config)
        {
            _keyId = config["Razorpay:KeyId"] ?? throw new ArgumentNullException("Razorpay:KeyId is missing");
            _keySecret = config["Razorpay:KeySecret"] ?? throw new ArgumentNullException("Razorpay:KeySecret is missing");
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder(OrderPaymentDTO dto)
        {
            try
            {
                var client = new RazorpayClient(_keyId, _keySecret);

                var options = new Dictionary<string, object>
        {
            { "amount", Convert.ToInt64(dto.Amount * 100) },
            { "currency", "INR" },
            
            { "receipt", $"rcpt_{dto.OrderId}" },
            
            { "payment_capture", 1 }
        };

                Order order = client.Order.Create(options);

                return Ok(new
                {
                    razorpayOrderId = order["id"].ToString(),
                    amount = dto.Amount,
                    currency = "INR",
                    keyId = _keyId
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("verify-payment")]
        public IActionResult VerifyPayment(VerifyPaymentDTO dto)
        {
            try
            {
                var client = new RazorpayClient(_keyId, _keySecret);
                var attributes = new Dictionary<string, string>
                {
                    { "razorpay_order_id", dto.RazorpayOrderId },
                    { "razorpay_payment_id", dto.RazorpayPaymentId },
                    { "razorpay_signature", dto.RazorpaySignature }
                };

                Utils.verifyPaymentSignature(attributes);
                return Ok(new { success = true, message = "Payment verified successfully!" });
            }
            catch (SignatureVerificationError)
            {
                return BadRequest(new { success = false, message = "Invalid payment signature." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
