using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    public class CompleteModel : PageModel
    {
        public int OrderId { get; set; }
        public void OnGet(int orderId)
        {
            OrderId = orderId;
        }
    }
}
