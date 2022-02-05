namespace ProductPackaging.Models;

public class MResponseExecution
{
    public string Status { get; set; }

    public string Message { get; set; }

    public MResponseExecution()
    {
        Status = "";
        Message = "";
    }
}