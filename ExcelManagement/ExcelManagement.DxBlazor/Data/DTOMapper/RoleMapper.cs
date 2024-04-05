using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;
using static ExcelManagement.DxBlazor.Pages.Account.RegisterModel;
using Role = ExcelManagement.DxBlazor.Data.Models.Role;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public class RoleMapper
    {
        public static RoleDTO MapToDTO(Role role)
        {
            RoleDTO dto = new RoleDTO()
            {
                Id = role.Id,
                RoleName = role.RoleName,
                Description = role.Description,
                RoleLogoUrl = role.RoleLogoUrl,
                CreatedDate = role.CreatedDate,
                UpdatedDate = role.UpdatedDate,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(role.Company),
                CreatedByDTO = PersonMapper.MapToDTOEndpoint(role.CreatedBy),
                UpdatedByDTO = PersonMapper.MapToDTOEndpoint(role.UpdatedBy),

                PersonDTOs = (role.Persons == null || role.Persons.Count == 0) ? null : PersonMapper.MapToDTOEndpointList(role.Persons),
                FileAndFolderDTOs = (role.FileAndFolders == null || role.FileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapToDTOEndpointList(role.FileAndFolders),
            };
            return dto;
        }

        public static RoleDTO MapToDTOEndpoint(Role role)
        {
            RoleDTO dto = new RoleDTO()
            {
                Id = role.Id,
                RoleName = role.RoleName,
                Description = role.Description,
                RoleLogoUrl = role.RoleLogoUrl,
                CreatedDate = role.CreatedDate,
                UpdatedDate = role.UpdatedDate,
            };
            return dto;
        }

        public static Role MapToModel(RoleDTO roleDTO)
        {
            Role model = new Role()
            {
                Id = roleDTO.Id,
                RoleName = roleDTO.RoleName,
                Description = roleDTO.Description,
                RoleLogoUrl = roleDTO.RoleLogoUrl,
                CreatedDate = roleDTO.CreatedDate,
                UpdatedDate = roleDTO.UpdatedDate,

                Company = CompanyMapper.MapToModelEndpoint(roleDTO.CompanyDTO),
                CreatedBy = PersonMapper.MapToModelEndpoint(roleDTO.CreatedByDTO),
                UpdatedBy = PersonMapper.MapToModelEndpoint(roleDTO.UpdatedByDTO),

                Persons = (roleDTO.PersonDTOs == null || roleDTO.PersonDTOs.Count == 0) ? null : PersonMapper.MapToModelEndpointList(roleDTO.PersonDTOs),
                FileAndFolders = (roleDTO.FileAndFolderDTOs == null || roleDTO.FileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapToModelEndpointList(roleDTO.FileAndFolderDTOs),
            };
            return model;
        }

        public static Role MapToModelEndpoint(RoleDTO roleDTO)
        {
            Role model = new Role()
            {
                Id = roleDTO.Id,
                RoleName = roleDTO.RoleName,
                Description = roleDTO.Description,
                RoleLogoUrl = roleDTO.RoleLogoUrl,
                CreatedDate = roleDTO.CreatedDate,
                UpdatedDate = roleDTO.UpdatedDate,
            };
            return model;
        }

        //Logic

        //Map List<Object> to List<ObjectDTO>
        public static ICollection<RoleDTO> MapToDTOEndpointList(ICollection<Role> roles)
        {
            if (roles == null || roles.Count == 0)
            {
                return null;
            }

            var roleDTOs = new List<RoleDTO>();

            foreach (var role in roles)
            {
                var roleDTO = MapToDTOEndpoint(role);
                roleDTOs.Add(roleDTO);
            }

            return roleDTOs;
        }

        //Map List<ObjectDTO> to List<Object>
        public static ICollection<Role> MapToModelEndpointList(ICollection<RoleDTO> roleDTOs)
        {
            if (roleDTOs == null || roleDTOs.Count == 0)
            {
                return null;
            }

            var roles = new List<Role>();

            foreach (var roleDTO in roleDTOs)
            {
                var role = MapToModelEndpoint(roleDTO);
                roles.Add(role);
            }

            return roles;
        }
    }
}
