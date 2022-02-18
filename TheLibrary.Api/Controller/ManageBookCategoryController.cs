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
            var response = await _service.Create(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookCategoryUpdateDTO dto)
        {
            var response = await _service.Update(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _service.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
