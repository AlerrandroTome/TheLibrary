using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.BookCategory;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Api.Controller
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings]
    [Route("api/[controller]")]
    [ODataRoutePrefix("BookCategory")]
    public class ManagerBookCategoryController : ODataController, IControllerBase<BookCategoryCreateDTO, BookCategoryUpdateDTO>
    {
        private readonly IManagerBookCategoryService _service;

        public ManagerBookCategoryController(IManagerBookCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        [ODataRoute]
        virtual public IActionResult Get() => Ok(_service.Get());

        [HttpPost]
        [AllowAnonymous]
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
