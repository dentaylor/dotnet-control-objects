using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class MeterModel : PageModel
{
    [BindProperty]
    public int MeterValue { get; set; } = 50;

    public void OnPost()
    {
        // MeterValue is automatically bound
    }
}
