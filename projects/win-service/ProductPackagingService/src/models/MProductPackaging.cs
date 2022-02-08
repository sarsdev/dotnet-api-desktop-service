namespace ProductPackagingService.Models;

public class MProductPackaging
{
    public string Id { get; set; } = string.Empty;

    public int Code { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;

    public string GetCSVData () {
        return $"{Id};{Code};{Description};{Unit};";
    }
}