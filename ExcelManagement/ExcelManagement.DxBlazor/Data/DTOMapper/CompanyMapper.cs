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
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                Description = company.Description,
                CompanyLogoUrl = company.CompanyLogoUrl,
                CreatedDate = company.CreatedDate,
                UpdatedDate = company.UpdatedDate,

                RoleDTOs = (company.Roles == null || company.Roles.Count == 0) ? null : RoleMapper.MapRoleToDTOList(company.Roles),
                GroupDTOs = (company.Groups == null || company.Groups.Count == 0) ? null : GroupMapper.MapGroupToDTOList(company.Groups),
                CompanyMemberDTOs = (company.CompanyMembers == null || company.CompanyMembers.Count == 0) ? null : PersonMapper.MapPersonToDTOList(company.CompanyMembers),
                FileAndFolderDTOs = (company.FileAndFolders == null || company.FileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToDTOList(company.FileAndFolders),

            };

            return companyDTO;
        }

        //Map to Dto Endpoint
        public static CompanyDTO MapToDTOEndpoint(Company company)
        {
            CompanyDTO companyDTO = new CompanyDTO
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                Description = company.Description,
                CompanyLogoUrl = company.CompanyLogoUrl,
                CreatedDate = company.CreatedDate,
                UpdatedDate = company.UpdatedDate,
            };

            return companyDTO;
        }

        //Map to Model
        public static Company MapToModel(CompanyDTO companyDTO)
        {
            Company company = new Company
            {
                CompanyId = companyDTO.CompanyId,
                CompanyName = companyDTO.CompanyName,
                Description = companyDTO.Description,
                CompanyLogoUrl = companyDTO.CompanyLogoUrl,
                CreatedDate = companyDTO.CreatedDate,
                UpdatedDate = companyDTO.UpdatedDate,

                Roles = (companyDTO.RoleDTOs == null || companyDTO.RoleDTOs.Count == 0) ? null : RoleMapper.MapRoleToModelList(companyDTO.RoleDTOs),
                Groups = (companyDTO.GroupDTOs == null || companyDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapGroupToModelList(companyDTO.GroupDTOs),
                CompanyMembers = (companyDTO.CompanyMemberDTOs == null || companyDTO.CompanyMemberDTOs.Count == 0) ? null : PersonMapper.MapPersonToModelList(companyDTO.CompanyMemberDTOs),
                FileAndFolders = (companyDTO.FileAndFolderDTOs == null || companyDTO.FileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToModelList(companyDTO.FileAndFolderDTOs),
            };

            return company;
        }

        //Map to Model Endpoint
        public static Company MapToModelEndpoint(CompanyDTO companyDTO)
        {
            Company company = new Company
            {
                CompanyId = companyDTO.CompanyId,
                CompanyName = companyDTO.CompanyName,
                Description = companyDTO.Description,
                CompanyLogoUrl = companyDTO.CompanyLogoUrl,
                CreatedDate = companyDTO.CreatedDate,
                UpdatedDate = companyDTO.UpdatedDate,
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
