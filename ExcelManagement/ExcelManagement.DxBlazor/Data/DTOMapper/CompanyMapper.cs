using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public class CompanyMapper
    {
        public static CompanyDTO MapToDTO(Company company)
        {
            CompanyDTO dto = new CompanyDTO()
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                Description = company.Description,
                CompanyLogoUrl = company.CompanyLogoUrl,
                CreatedDate = company.CreatedDate,
                UpdatedDate = company.UpdatedDate,

                CreatedByDTO = PersonMapper.MapToDTOEndpoint(company.CreatedBy),
                UpdatedByDTO = PersonMapper.MapToDTOEndpoint(company.UpdatedBy),

                PersonDTOs = (company.Persons == null || company.Persons.Count == 0) ? null : PersonMapper.MapToDTOEndpointList(company.Persons),
                RoleDTOs = (company.Roles == null || company.Roles.Count == 0) ? null : RoleMapper.MapToDTOEndpointList(company.Roles),
                GroupDTOs = (company.Groups == null || company.Groups.Count == 0) ? null : GroupMapper.MapToDTOEndpointList(company.Groups),
                FileAndFolderDTOs = (company.FileAndFolders == null || company.FileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapToDTOEndpointList(company.FileAndFolders),
            };
            return dto;
        }

        public static CompanyDTO MapToDTOEndpoint(Company company)
        {
            CompanyDTO dto = new CompanyDTO()
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                Description = company.Description,
                CompanyLogoUrl = company.CompanyLogoUrl,
                CreatedDate = company.CreatedDate,
                UpdatedDate = company.UpdatedDate,
            };
            return dto;
        }

        public static Company MapToModel(CompanyDTO companyDTO)
        {
            Company model = new Company()
            {
                Id = companyDTO.Id,
                CompanyName = companyDTO.CompanyName,
                Description = companyDTO.Description,
                CompanyLogoUrl = companyDTO.CompanyLogoUrl,
                CreatedDate = companyDTO.CreatedDate,
                UpdatedDate = companyDTO.UpdatedDate,

                CreatedBy = PersonMapper.MapToModelEndpoint(companyDTO.CreatedByDTO),
                UpdatedBy = PersonMapper.MapToModelEndpoint(companyDTO.UpdatedByDTO),

                Persons = (companyDTO.PersonDTOs == null || companyDTO.PersonDTOs.Count == 0) ? null : PersonMapper.MapToModelEndpointList(companyDTO.PersonDTOs),
                Roles = (companyDTO.RoleDTOs == null || companyDTO.RoleDTOs.Count == 0) ? null : RoleMapper.MapToModelEndpointList(companyDTO.RoleDTOs),
                Groups = (companyDTO.GroupDTOs == null || companyDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapToModelEndpointList(companyDTO.GroupDTOs),
                FileAndFolders = (companyDTO.FileAndFolderDTOs == null || companyDTO.FileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapToModelEndpointList(companyDTO.FileAndFolderDTOs),
            };
            return model;
        }

        public static Company MapToModelEndpoint(CompanyDTO companyDTO)
        {
            Company model = new Company()
            {
                Id = companyDTO.Id,
                CompanyName = companyDTO.CompanyName,
                Description = companyDTO.Description,
                CompanyLogoUrl = companyDTO.CompanyLogoUrl,
                CreatedDate = companyDTO.CreatedDate,
                UpdatedDate = companyDTO.UpdatedDate,
            };
            return model;
        }

        //Logic

        //Map List<Object> to List<ObjectDTO>
        public static ICollection<CompanyDTO> MapToDTOEndpointList(ICollection<Company> companys)
        {
            if (companys == null || companys.Count == 0)
            {
                return null;
            }

            var companyDTOs = new List<CompanyDTO>();

            foreach (var company in companys)
            {
                var companyDTO = MapToDTOEndpoint(company);
                companyDTOs.Add(companyDTO);
            }

            return companyDTOs;
        }

        //Map List<ObjectDTO> to List<Object>
        public static ICollection<Company> MapToModelEndpointList(ICollection<CompanyDTO> companyDTOs)
        {
            if (companyDTOs == null || companyDTOs.Count == 0)
            {
                return null;
            }

            var companys = new List<Company>();

            foreach (var companyDTO in companyDTOs)
            {
                var company = MapToModelEndpoint(companyDTO);
                companys.Add(company);
            }

            return companys;
        }
    }
}
