using Managr_API.Data.Entities;
using Managr_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Managr_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly ListService _listService;
        public ListsController(ListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLists()
        {
            var lists = await _listService.GetAllListsAsync();
            return Ok(lists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(string id)
        {
            var list = await _listService.GetListByIdAsync(id);
            if (list == null) return NotFound();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] List list)
        {
            await _listService.CreateListAsync(list);
            return CreatedAtAction(nameof(GetTask), new { id = list.Id }, list);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(string id, [FromBody] List list)
        {
            await _listService.UpdateListAsync(id, list);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(string id)
        {
            await _listService.DeleteListAsync(id);
            return NoContent();
        }
    }
}
