using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public static class CompanyMapper
    {
        //Map to Dto
        public static CompanyDTO MapToDTO(Company company)
        {
            CompanyDTO companyDTO = new CompanyDTO
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                Description = company.Description,
                CompanyLogoUrl = company.CompanyLogoUrl,

                DepartmentDTOList = DepartmentMapper.MapDepartmentList(company.Departments),
                PersonDTOList = PersonMapper.MapPeopleList(company.People),
            };

            return companyDTO;
        }
        
        //Map to Dto Endpoint
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

        //Logic
        public static ICollection<CompanyDTO> MapCompanyList(ICollection<Company> companies)
        {
            if (companies == null || companies.Count == 0)
            {
                return null;
            }

            var companyDTOList = new List<CompanyDTO>();

            foreach (var company in companies)
            {
                var companyDTO = MapToDTOEndpoint(company);
                companyDTOList.Add(companyDTO);
            }

            return companyDTOList;
        }

    }
}
