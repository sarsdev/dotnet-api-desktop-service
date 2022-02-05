namespace ProductPackaging.Models;

public class MResponseData
{
    public string Status { get; set; } = string.Empty;

    public List<MProductPackaging> Payload { get; set; } = new List<MProductPackaging>();

    public MFooter Footer { get; set; } = new MFooter();
}