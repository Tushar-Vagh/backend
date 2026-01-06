namespace backend.Models;

public class DocumentRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string DocumentName { get; set; } = "";
    public string Type { get; set; } = "";
    public string Category { get; set; } = "";
    public string Reference { get; set; } = "";
    public string UploadedBy { get; set; } = "";
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    public long Size { get; set; }
    public string FilePath { get; set; } = "";
}
