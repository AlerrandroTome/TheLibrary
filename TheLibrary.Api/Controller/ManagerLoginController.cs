using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Login;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerLoginController : ControllerBase
    {
        private readonly IManagerLoginService _service;

        public ManagerLoginController(IManagerLoginService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto) => Ok(await _service.Login(dto));
    }
}
