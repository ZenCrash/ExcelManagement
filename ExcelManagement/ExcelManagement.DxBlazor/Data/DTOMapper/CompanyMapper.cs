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

                PeopleDTOs = (company.People == null || company.People.Count == 0) ? null : PersonMapper.MapPersonToDTOList(company.People),
                RoleDTOs = (company.Roles == null || company.Roles.Count == 0) ? null : RoleMapper.MapRoleToDTOList(company.Roles),
                GroupDTOs = (company.Groups == null || company.Groups.Count == 0) ? null : GroupMapper.MapGroupToDTOList(company.Groups),
                FilesAndFolderDTOs = (company.FilesAndFolders == null || company.FilesAndFolders.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToDTOList(company.FilesAndFolders),
                
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

                People = (companyDTO.PeopleDTOs == null || companyDTO.PeopleDTOs.Count == 0) ? null : PersonMapper.MapPersonToModelList(companyDTO.PeopleDTOs),
                Roles = (companyDTO.RoleDTOs == null || companyDTO.RoleDTOs.Count == 0) ? null : RoleMapper.MapRoleToModelList(companyDTO.RoleDTOs),
                Groups = (companyDTO.GroupDTOs == null || companyDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapGroupToModelList(companyDTO.GroupDTOs),
                FilesAndFolders = (companyDTO.FilesAndFolderDTOs == null || companyDTO.FilesAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToModelList(companyDTO.FilesAndFolderDTOs),
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

            var companyDTOs = new List<CompanyDTO>();

            foreach (var company in companies)
            {
                var companyDTO = MapToDTOEndpoint(company);
                companyDTOs.Add(companyDTO);
            }

            return companyDTOs;
        }

        //Map List<CommpanyDTO> to List<Company>
        public static ICollection<Company> MapCompanyToModelList(ICollection<CompanyDTO> companyDTOs)
        {
            if (companyDTOs == null || companyDTOs.Count == 0)
            {
                return null;
            }

            var companies = new List<Company>();

            foreach (var companyDTO in companyDTOs)
            {
                var company = MapToModelEndpoint(companyDTO);
                companies.Add(company);
            }

            return companies;
        }

    }
}
