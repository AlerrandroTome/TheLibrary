using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.User;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Api.Controller
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings]
    [ODataRoutePrefix("User")]
    [Route("api/[controller]")]
    public class ManageUserController : ODataController, IControllerBase<UserCreateDTO, UserUpdateDTO>
    {
        private readonly IManageUserService _service;

        public ManageUserController(IManageUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(UserCreateDTO dto)
        {
            var response = await _service.Create(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _service.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        [ODataRoute]
        virtual public IActionResult Get() => Ok(_service.Get());

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDTO dto)
        {
            var response = await _service.Update(dto);
            return StatusCode(response.StatusCode, response);
        }
    }
}
