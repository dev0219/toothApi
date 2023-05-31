using toothApi.Models;
using toothApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace toothApi.Controllers;

[ApiController]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    public readonly INoteCosmosService _noteCosmosService;
    public NoteController(INoteCosmosService noteCosmosService)
    {
        _noteCosmosService = noteCosmosService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _noteCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Post(Note newNote)
    {
        newNote.Id = Guid.NewGuid().ToString();
        newNote.CreatedUtc = DateTime.UtcNow.ToString("o");
        newNote.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _noteCosmosService.AddAsync(newNote);
        return Ok(result);
    }

    [HttpGet("getNote")]
    public async Task<IActionResult> GetById(string Id)
    {
        var sqlCosmosQuery = "SELECT * FROM c WHERE c.id = @Id";
        var result = await _noteCosmosService.SearchById(sqlCosmosQuery, Id);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Put(Note noteToUpdate)
    {
        noteToUpdate.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _noteCosmosService.Update(noteToUpdate);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _noteCosmosService.Delete(id, customerId);
        return Ok();
    }

}