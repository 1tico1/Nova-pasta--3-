using Microsoft.AspNetCore.Mvc;
using MyWebAPIProject.Models;
using MyWebAPIProject.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> Get() => await _itemService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(string id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item newItem)
        {
            await _itemService.CreateAsync(newItem);
            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Item updatedItem)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null) return NotFound();

            updatedItem.Id = item.Id;
            await _itemService.UpdateAsync(id, updatedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null) return NotFound();

            await _itemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
