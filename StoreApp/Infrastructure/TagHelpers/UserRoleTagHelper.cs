using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "user-role")]
    public class UserRoleTagHelper : TagHelper
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        [HtmlAttributeName("user-name")]
        public string? UserName { get; set; }
        public UserRoleTagHelper(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            TagBuilder ul = new TagBuilder("ul");

            var roles = _roleManager.Roles.ToList().Select(r => r.Name);

            foreach (var role in roles)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.Append($"{role} : {await _userManager.IsInRoleAsync(user, role)}");
                ul.InnerHtml.AppendHtml(li);
            }

            output.Content.AppendHtml(ul);
        }
    }
}
