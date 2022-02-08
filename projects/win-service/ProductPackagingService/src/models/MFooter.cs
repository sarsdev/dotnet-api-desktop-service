namespace ProductPackagingService.Models;

public class MFooter
{
    public int Page { get; set; }

    public int Skip { get; set; }

    public bool HasNext { get; set; }

    public int TotalRecords { get; set; }
}