namespace ProductPackaging.Models;

public class MProductPackaging
{
    public int Code { get; set; }

    public string Description { get; set; }

    public string Unit { get; set; }

    public MProductPackaging()
    {
        Description = "";
        Unit = "";
    }
}