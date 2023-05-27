using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<ApplicationUser> _applicationUserManager;

        public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<ApplicationUser> applicationUserManager)
        {
            _signInManager = signInManager;
            _applicationUserManager = applicationUserManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

		public async Task<IActionResult> OnPostAsync()
		{
			ReturnUrl = Url.Content("~/");
			if (ModelState.IsValid)
			{
				var userExists = await _applicationUserManager.FindByEmailAsync(Input.Email);
				if (userExists != null)
				{
					ModelState.AddModelError(string.Empty, "Email already exists.");
					return Page();
				}

				var identity = new ApplicationUser { UserName = Input.Email, Email = Input.Email, 
					Person = new Person { FirstName = Input.FirstName, LastName = Input.LastName, Company = Input.Company } 
				};

				var result = await _applicationUserManager.CreateAsync(identity, Input.Password);

				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(identity, isPersistent: false);
					return LocalRedirect(ReturnUrl);
				}
			}

			return Page();
		}
    }
}
