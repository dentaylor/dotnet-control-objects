using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIControlsDemo.Pages
{
    public class ButtonModel : PageModel
    {
        public string Message { get; set; }

        public void OnPost()
        {
            Message = "You clicked the button!";
        }
    }
}
