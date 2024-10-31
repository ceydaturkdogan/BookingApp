using Microsoft.AspNetCore.Http;
using BookingApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }//TODO: ileride action filter olarak kodlanacak.
        }
    } }
