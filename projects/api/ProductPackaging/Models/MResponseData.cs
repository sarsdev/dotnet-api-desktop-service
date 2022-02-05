namespace ProductPackaging.Models;

public class MResponseData
{
    public string Status { get; set; }

    public List<MProductPackaging> Payload { get; set; }

    public MFooter Footer { get; set; }

    public MResponseData()
    {
        Status = "";
        Payload = new List<MProductPackaging>();
        Footer = new MFooter();
    }
}