using backend.Models;

namespace backend.Services;

public class DocumentService
{
    private readonly List<DocumentRecord> _documents = new();
    private readonly IWebHostEnvironment _env;

    public DocumentService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IEnumerable<DocumentRecord> GetAll() => _documents;

    public DocumentRecord Upload(IFormFile file, string type, string category, string reference, string user)
    {
        var uploads = Path.Combine(_env.ContentRootPath, "Uploads");
        Directory.CreateDirectory(uploads);

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var path = Path.Combine(uploads, fileName);

        using var stream = new FileStream(path, FileMode.Create);
        file.CopyTo(stream);

        var doc = new DocumentRecord
        {
            DocumentName = file.FileName,
            Type = type,
            Category = category,
            Reference = reference,
            UploadedBy = user,
            Size = file.Length,
            FilePath = path
        };

        _documents.Add(doc);
        return doc;
    }

    public DocumentRecord? Get(Guid id) =>
        _documents.FirstOrDefault(x => x.Id == id);
}
