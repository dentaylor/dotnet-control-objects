using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class TextareaModel : PageModel
{
    [BindProperty]
    public string Message { get; set; }

    public bool HasSubmitted { get; set; }

    public void OnPost()
    {
        HasSubmitted = true;
    }
}
