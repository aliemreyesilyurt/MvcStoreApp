using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    public class CompleteModel : PageModel
    {
        public Guid OrderId { get; set; }
        public void OnGet(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
