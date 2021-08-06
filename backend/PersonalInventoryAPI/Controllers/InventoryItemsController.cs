using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PersonalInventoryAPI.Models;
using PersonalInventoryAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalInventoryAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryItemsController : ControllerBase {
    private readonly IInventoryItemRepository _repository;

    public InventoryItemsController(IInventoryItemRepository repository) {
      _repository = repository;
    }

    // GET: api/InventoryItems
    [HttpGet]
    public async Task<IList<InventoryItem>> GetInventoryItems() {
      return await _repository.GetAllAsync();
    }

    // GET: api/InventoryItems/5
    [HttpGet("{id}")]
    public async Task<InventoryItem> GetInventoryItem(ObjectId id) {
      var inventoryItem = await _repository.GetByIdAsync(id);

      return inventoryItem;
    }

    // PUT: api/InventoryItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInventoryItem(InventoryItem inventoryItem) {

      await _repository.SetByIdAsync(inventoryItem, inventoryItem.Id);

      return NoContent();
    }

    // POST: api/InventoryItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem inventoryItem) {
      await _repository.CreateOne(inventoryItem);

      return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);
    }

    [HttpDelete]
    public async Task<ActionResult<long>> DeleteInventoryItems() {
      return await _repository.DeleteAllAsync();
    }
  }
}
