using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.DbOption.Repository;
using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.DTOMapper;
using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _applicationUserManager;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICompanyRepository _companyRepository;

        public RegisterModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> applicationUserManager, IDepartmentRepository departmentRepository, ICompanyRepository companyRepository)
        {
            _signInManager = signInManager;
            _applicationUserManager = applicationUserManager;
            _departmentRepository = departmentRepository;
            _companyRepository = companyRepository;
        }

        [BindProperty]
        public InputRegisterModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> Departments { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ReturnUrl = Url.Content("~/");
            Companies = await GetCompanySelectListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            Companies = await GetCompanySelectListAsync();

            if (ModelState.IsValid)
            {
                var userExists = await _applicationUserManager.FindByEmailAsync(Input.Email);
                if (userExists != null)
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");
                    return Page();
                }

                var identity = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Person = new Person {
                        Id = Guid.NewGuid(),
                        FirstName = Input.FirstName, 
                        LastName = Input.LastName, 
                        CompanyId = Input.CompanyDTO.Id, 
                        Department = (Input.DepartmentDTO == null) ? null : DepartmentMapper.MapToModelEndpoint(Input.DepartmentDTO) }
                };

                var result = await _applicationUserManager.CreateAsync(identity, Input.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(identity, isPersistent: false);
                    return LocalRedirect(ReturnUrl);
                }
            }
            else
            {
                var ErrorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
            }

            return Page();
        }

        private async Task<List<SelectListItem>> GetCompanySelectListAsync()
        {
            var companies = await _companyRepository.GetAllAsync();
            List<CompanyDTO> companyDTOs = new();
            foreach (var company in companies)
            {
                var companyDTO = CompanyMapper.MapToDTOEndpoint(company);
                companyDTOs.Add(companyDTO);
            }

            return companyDTOs.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CompanyName }).ToList();
        }

        private async Task<List<SelectListItem>> GetDepartmentSelectListAsync(Guid companyId)
        {
            var departments = await _departmentRepository.GetAllByCompanyIdAsync(companyId);
            List<DepartmentDTO> departmentDTOs = new();
            foreach (var department in departments)
            {
                var departmentDTO = DepartmentMapper.MapToDTOEndpoint(department);
                departmentDTOs.Add(departmentDTO);
            }

            return departmentDTOs.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.DepartmentName }).ToList();
        }
    }
}
