using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TheLibrary.Application.Interfaces;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.DTOs.User;

namespace TheLibrary.Api.Controller
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings]
    [ODataRoutePrefix("User")]
    [Route("api/[controller]")]
    public class ManageUserController : ODataController, IControllerBase<UserCreateDTO, UserUpdateDTO>
    {
        private readonly IManagerUserService _service;

        public ManageUserController(IManagerUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(UserCreateDTO dto)
        {
            await _service.Create(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        [ODataRoute]
        virtual public IActionResult Get() => Ok(_service.Get());

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDTO dto)
        {
            var result = await _service.Update(dto);
            return Ok(result);
        }
    }
}
