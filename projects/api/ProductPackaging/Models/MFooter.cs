namespace ProductPackaging.Models;

public class MFooter
{
    public int Page { get; set; }

    public int Skip { get; set; }

    public bool hasNext { get; set; }

    public long TotalRecords { get; set; }
}