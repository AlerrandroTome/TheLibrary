using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TheLibrary.Application.Interfaces;
using TheLibrary.Core.Interfaces;
using TheLibrary.Domain.DTOs.BookCategory;

namespace TheLibrary.Api.Controller
{
    [ApiController]
    [ApiExplorerSettings]
    [Route("api/[controller]")]
    [ODataRoutePrefix("BookCategory")]
    [Authorize]
    public class ManageBookCategoryController : ODataController, IControllerBase<BookCategoryCreateDTO, BookCategoryUpdateDTO>
    {
        private readonly IManageBookCategoryService _service;

        public ManageBookCategoryController(IManageBookCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        [ODataRoute]
        virtual public IActionResult Get() => Ok(_service.Get());

        [HttpPost]
        public async Task<IActionResult> Create(BookCategoryCreateDTO dto)
        {
            await _service.Create(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookCategoryUpdateDTO dto)
        {
            await _service.Update(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
