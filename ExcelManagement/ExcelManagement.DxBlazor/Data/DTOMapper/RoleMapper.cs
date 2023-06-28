using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public class RoleMapper
    {

        //Map to Dto
        public static RoleDTO MapToDTO(Role role)
        {
            RoleDTO roleDTO = new RoleDTO
            {
                RoleId = role.RoleId,
                Description = role.Description,
                RoleLogoUrl = role.RoleLogoUrl,
                CreatedDate = role.CreatedDate,
                UpdatedDate = role.UpdatedDate,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(role.Company),
                RoleCreatedByDTO = PersonMapper.MapToDTOEndpoint(role.RoleCreatedBy),
                RoleUpdatedByDTO = PersonMapper.MapToDTOEndpoint(role.RoleUpdatedBy),

                FileAndFolderDTOs = (role.FileAndFolders == null || role.FileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToDTOList(role.FileAndFolders),
                PersonDTOs = (role.Persons == null || role.Persons.Count == 0) ? null : PersonMapper.MapPersonToDTOList(role.Persons),
            };

            return roleDTO;
        }

        //Map to Dto Endpoint
        public static RoleDTO MapToDTOEndpoint(Role role)
        {
            RoleDTO roleDTO = new RoleDTO
            {
                RoleId = role.RoleId,
                Description = role.Description,
                RoleLogoUrl = role.RoleLogoUrl,
                CreatedDate = role.CreatedDate,
                UpdatedDate = role.UpdatedDate,
            };

            return roleDTO;
        }

        //Map to Model
        public static Role MapToModel(RoleDTO roleDTO)
        {
            Role role = new Role
            {
                RoleId = roleDTO.RoleId,
                Description = roleDTO.Description,
                RoleLogoUrl = roleDTO.RoleLogoUrl,
                CreatedDate = roleDTO.CreatedDate,
                UpdatedDate = roleDTO.UpdatedDate,

                Company = CompanyMapper.MapToModelEndpoint(roleDTO.CompanyDTO),
                RoleCreatedBy = PersonMapper.MapToModelEndpoint(roleDTO.RoleCreatedByDTO),
                RoleUpdatedBy = PersonMapper.MapToModelEndpoint(roleDTO.RoleUpdatedByDTO),

                FileAndFolders = (roleDTO.FileAndFolderDTOs == null || roleDTO.FileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToModelList(roleDTO.FileAndFolderDTOs),
                Persons = (roleDTO.PersonDTOs == null || roleDTO.PersonDTOs.Count == 0) ? null : PersonMapper.MapPersonToModelList(roleDTO.PersonDTOs),
            };

            return role;
        }

        //Map to Model Endpoint
        public static Role MapToModelEndpoint(RoleDTO roleDTO)
        {
            Role role = new Role
            {
                RoleId = roleDTO.RoleId,
                Description = roleDTO.Description,
                RoleLogoUrl = roleDTO.RoleLogoUrl,
                CreatedDate = roleDTO.CreatedDate,
                UpdatedDate = roleDTO.UpdatedDate,
            };

            return role;
        }


        //Logic

        //Map List<Role> to List<RoleDTO>
        public static ICollection<RoleDTO> MapRoleToDTOList(ICollection<Role> roles)
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

        //Map List<RoleDTO> to List<Role>
        public static ICollection<Role> MapRoleToModelList(ICollection<RoleDTO> roleDTOs)
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
