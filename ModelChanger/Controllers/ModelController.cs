using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelChanger.Entities;
using ModelChanger.Repositories;

namespace ModelChanger.Controllers;

[ApiController]
[Route("api/models")]
public class ModelController: ControllerBase
{
    private readonly IModelRepository _repo;

    public ModelController(IModelRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repo.GetAllAsync());

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Get(int id)
    {
        var model = await _repo.GetByIdAsync(id);
        return model == null ? NotFound() : Ok(model);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] Model model)
    {
        var created = await _repo.AddAsync(model);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] Model model)
    {
        if (id != model.Id) return BadRequest();
        var updated = await _repo.UpdateAsync(model);
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repo.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}