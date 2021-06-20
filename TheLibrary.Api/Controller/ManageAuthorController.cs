using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Author;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Api.Controller
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings]
    [Route("api/[controller]")]
    [ODataRoutePrefix("Author")]
    public class ManageAuthorController : ODataController, IControllerBase<AuthorCreateDTO, AuthorUpdateDTO>
    {
        private readonly IManageAuthorService _service;

        public ManageAuthorController(IManageAuthorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateDTO dto)
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
        public IActionResult Get() => Ok(_service.Get());

        [HttpPut]
        public async Task<IActionResult> Update(AuthorUpdateDTO dto)
        {
            await _service.Update(dto);
            return Ok();
        }
    }
}
