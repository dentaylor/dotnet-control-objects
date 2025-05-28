using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ProgressModel : PageModel
{
    [BindProperty]
    public int ProgressValue { get; set; } = 50; // Default value

    public void OnPost()
    {
        // Bound ProgressValue is used directly
    }
}
