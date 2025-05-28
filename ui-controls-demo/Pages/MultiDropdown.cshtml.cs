using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

public class MultidropdownModel : PageModel
{
    [BindProperty]
    public List<string> SelectedOptions { get; set; }

    public List<SelectListItem> Options { get; set; }

    public bool HasSubmitted { get; set; }

    public void OnGet()
    {
        Options = GetOptions();
    }

    public void OnPost()
    {
        Options = GetOptions(); // Re-populate after POST
        HasSubmitted = true;
    }

    private List<SelectListItem> GetOptions()
    {
        return new List<SelectListItem>
        {
            new SelectListItem { Value = "Option1", Text = "Option 1" },
            new SelectListItem { Value = "Option2", Text = "Option 2" },
            new SelectListItem { Value = "Option3", Text = "Option 3" },
            new SelectListItem { Value = "Option4", Text = "Option 4" },
            new SelectListItem { Value = "Option5", Text = "Option 5" }
        };
    }
}
