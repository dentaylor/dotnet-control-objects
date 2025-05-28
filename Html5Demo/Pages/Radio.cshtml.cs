using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

public class RadioModel : PageModel
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
        Options = GetOptions(); // Needed on POST
        HasSubmitted = true;
    }

    private List<SelectListItem> GetOptions()
    {
        return new List<SelectListItem>
        {
            new SelectListItem { Value = "Red", Text = "Red" },
            new SelectListItem { Value = "Green", Text = "Green" },
            new SelectListItem { Value = "Blue", Text = "Blue" }
        };
    }
}
