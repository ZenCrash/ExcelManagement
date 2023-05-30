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

                DepartmentDTOList = (company.Departments == null || company.Departments.Count() == 0) ? null : DepartmentMapper.MapDepartmentToDTOList(company.Departments),
                PersonDTOList = (company.People == null || company.People.Count == 0) ? null : PersonMapper.MapPersonToDTOList(company.People),
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

        //Map to Model
        public static Company MapToModel(CompanyDTO companyDTO)
        {
            Company company = new Company
            {
                Id = companyDTO.Id,
                CompanyName = companyDTO.CompanyName,
                Description = companyDTO.Description,
                CompanyLogoUrl = companyDTO.CompanyLogoUrl,

                Departments = (companyDTO.DepartmentDTOList == null || companyDTO.DepartmentDTOList.Count() == 0) ? null : DepartmentMapper.MapDepartmentToModelList(companyDTO.DepartmentDTOList),
                People = (companyDTO.PersonDTOList == null || companyDTO.PersonDTOList.Count == 0) ? null : PersonMapper.MapPersonToModelList(companyDTO.PersonDTOList),
            };

            return company;
        }

        //Map to Model Endpoint
        public static Company MapToModelEndpoint(CompanyDTO companyDTO)
        {
            Company company = new Company
            {
                Id = companyDTO.Id,
                CompanyName = companyDTO.CompanyName,
                Description = companyDTO.Description,
                CompanyLogoUrl = companyDTO.CompanyLogoUrl,

                Departments = DepartmentMapper.MapDepartmentToModelList(companyDTO.DepartmentDTOList),
                People = PersonMapper.MapPersonToModelList(companyDTO.PersonDTOList),
            };

            return company;
        }


        //Logic

        //Map List<Commpany> to List<CompanyDTO>
        public static ICollection<CompanyDTO> MapCompanyToDTOList(ICollection<Company> companies)
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

        //Map List<CommpanyDTO> to List<Company>
        public static ICollection<Company> MapCompanyToModelList(ICollection<CompanyDTO> companyDTOList)
        {
            if (companyDTOList == null || companyDTOList.Count == 0)
            {
                return null;
            }

            var companies = new List<Company>();

            foreach (var companyDTO in companyDTOList)
            {
                var company = MapToModelEndpoint(companyDTO);
                companies.Add(company);
            }

            return companies;
        }

    }
}
