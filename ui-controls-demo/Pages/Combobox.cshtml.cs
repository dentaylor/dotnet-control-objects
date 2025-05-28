using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ComboboxModel : PageModel
{
    [BindProperty]
    public string SelectedOption { get; set; }

    public List<SelectListItem> Options { get; set; }

    public bool HasSubmitted { get; set; }

    public void OnGet()
    {
        Options = GetOptions();
    }

    public void OnPost()
    {
        Options = GetOptions(); // Must repopulate on POST
        HasSubmitted = true;
    }

    private List<SelectListItem> GetOptions()
    {
        return new List<SelectListItem>
        {
            new SelectListItem { Value = "Option1", Text = "Option 1" },
            new SelectListItem { Value = "Option2", Text = "Option 2" },
            new SelectListItem { Value = "Option3", Text = "Option 3" }
        };
    }
}
