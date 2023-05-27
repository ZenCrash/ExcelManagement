using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public static class CompanyMapper
    {
        public static CompanyDTO MapToDTO(Company company)
        {
            CompanyDTO companyDTO = new CompanyDTO
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                Description = company.Description,
                CompanyLogoUrl = company.CompanyLogoUrl
            };

            return companyDTO;
        }
        
        public static CompanyDTO MapToDTOEndpoint(Company company)
        {
            CompanyDTO companyDTO = new CompanyDTO
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                Description = company.Description,
                CompanyLogoUrl = company.CompanyLogoUrl
            };

            return companyDTO;
        }
    }
}
