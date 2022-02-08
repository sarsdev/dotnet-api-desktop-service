namespace ProductPackagingService.Models;

public class MResponse
{
    public string Status { get; set; } = string.Empty;

    public List<MProductPackaging> Payload { get; set; } = new List<MProductPackaging>();

    public MFooter Footer { get; set; } = new MFooter();
}