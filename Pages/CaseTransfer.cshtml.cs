using RazorPagesCase.Models;
using RazorPagesCase.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace Transfer.Pages
{
    public class CaseModel : PageModel
    {
        public List<SR> SRs = new();

        [BindProperty]
        public SR NewSR {get; set;}=new();

        public void OnGet()
        {
            SRs=TransferService.GetAll();
        }


    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        TransferService.Add(NewSR);
        return RedirectToAction("Get");
    }

    public IActionResult OnPostDelete(int id)
    {
        TransferService.Delete(id);
        return RedirectToAction("Get");
    }
    }


}

