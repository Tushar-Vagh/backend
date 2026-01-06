using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers;

[ApiController]
[Route("api/documents")]
[Authorize]
public class DocumentsController : ControllerBase
{
    private readonly DocumentService _service;

    public DocumentsController(DocumentService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetDocuments()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost("upload")]
    public IActionResult Upload(
        IFormFile file,
        [FromForm] string type,
        [FromForm] string category,
        [FromForm] string reference
    )
    {
        var user = User.Identity?.Name ?? "System";
        var doc = _service.Upload(file, type, category, reference, user);
        return Ok(doc);
    }

    [HttpGet("download/{id}")]
    public IActionResult Download(Guid id)
    {
        var doc = _service.Get(id);
        if (doc == null) return NotFound();

        return PhysicalFile(doc.FilePath, "application/octet-stream", doc.DocumentName);
    }
}
