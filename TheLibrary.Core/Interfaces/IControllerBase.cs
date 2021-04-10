using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TheLibrary.Core.Interfaces
{
    public interface IControllerBase<CreateDTO, UpdateDTO>
    {
        Task<IActionResult> Create(CreateDTO dto);
        Task<IActionResult> Update(UpdateDTO dto);
        Task<IActionResult> Delete(Guid id);
        IActionResult Get();
    }
}
