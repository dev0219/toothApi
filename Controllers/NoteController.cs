using Dot6.API.CosmosDB.Demo.Models;
using Dot6.API.CosmosDB.Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dot6.API.CosmosDB.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    public readonly INoteCosmosService _noteCosmosService;
    public NoteController(INoteCosmosService noteCosmosService)
    {
        _noteCosmosService = noteCosmosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _noteCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Note newNote)
    {
        newNote.Id = Guid.NewGuid().ToString();
        var result = await _noteCosmosService.AddAsync(newNote);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Note noteToUpdate)
    {
        var result = await _noteCosmosService.Update(noteToUpdate);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _noteCosmosService.Delete(id, customerId);
        return Ok();
    }

}