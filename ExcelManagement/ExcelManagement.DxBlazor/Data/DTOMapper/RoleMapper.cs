//using ExcelManagement.DxBlazor.Data.DTO;
//using ExcelManagement.DxBlazor.Data.Models;

//namespace ExcelManagement.DxBlazor.Data.DTOMapper
//{
//    public class RoleMapper
//    {

//        //Map to Dto
//        public static RoleDTO MapToDTO(Role role)
//        {
//            RoleDTO roleDTO = new RoleDTO
//            {
//                Id = role.Id,
//                Description = role.Description,
//                RoleLogoUrl = role.RoleLogoUrl,
//                CreatedDate = role.CreatedDate,

//                CompanyId = role.CompanyId,
//                CreatedByPersonId = role.CreatedByPersonId,
//                UpdatedByPersonId = role.UpdatedByPersonId,

//                CompanyDTO = CompanyMapper.MapToDTOEndpoint(role.Company),
//                CreatedByPersonDTO = PersonMapper.MapToDTOEndpoint(role.CreatedByPerson),
//                UpdatedByPersonDTO = PersonMapper.MapToDTOEndpoint(role.UpdatedByPerson),
//            };

//            return roleDTO;
//        }

//        //Map to Dto Endpoint
//        public static RoleDTO MapToDTOEndpoint(Role role)
//        {
//            RoleDTO roleDTO = new RoleDTO
//            {
//                Id = role.Id,
//                Description = role.Description,
//                RoleLogoUrl = role.RoleLogoUrl,
//                CreatedDate = role.CreatedDate,

//                CompanyId = role.CompanyId,
//                CreatedByPersonId = role.CreatedByPersonId,
//                UpdatedByPersonId = role.UpdatedByPersonId,
//            };

//            return roleDTO;
//        }

//        //Map to Model
//        public static Role MapToModel(RoleDTO roleDTO)
//        {
//            Role role = new Role
//            {
//                Id = roleDTO.Id,
//                Description = roleDTO.Description,
//                RoleLogoUrl = roleDTO.RoleLogoUrl,
//                CreatedDate = roleDTO.CreatedDate,

//                CompanyId = roleDTO.CompanyId,
//                CreatedByPersonId = roleDTO.CreatedByPersonId,
//                UpdatedByPersonId = roleDTO.UpdatedByPersonId,

//                Company = CompanyMapper.MapToModelEndpoint(roleDTO.CompanyDTO),
//                CreatedByPerson = PersonMapper.MapToModelEndpoint(roleDTO.CreatedByPersonDTO),
//                UpdatedByPerson = PersonMapper.MapToModelEndpoint(roleDTO.UpdatedByPersonDTO),
//            };

//            return role;
//        }

//        //Map to Model Endpoint
//        public static Role MapToModelEndpoint(RoleDTO roleDTO)
//        {
//            Role role = new Role
//            {
//                Id = roleDTO.Id,
//                Description = roleDTO.Description,
//                RoleLogoUrl = roleDTO.RoleLogoUrl,
//                CreatedDate = roleDTO.CreatedDate,

//                CompanyId = roleDTO.CompanyId,
//                CreatedByPersonId = roleDTO.CreatedByPersonId,
//                UpdatedByPersonId = roleDTO.UpdatedByPersonId,
//            };

//            return role;
//        }


//        //Logic

//        //Map List<Role> to List<RoleDTO>
//        public static ICollection<RoleDTO> MapRoleToDTOList(ICollection<Role> roles)
//        {
//            if (roles == null || roles.Count == 0)
//            {
//                return null;
//            }

//            var roleDTOs = new List<RoleDTO>();

//            foreach (var role in roles)
//            {
//                var roleDTO = MapToDTOEndpoint(role);
//                roleDTOs.Add(roleDTO);
//            }

//            return roleDTOs;
//        }

//        //Map List<RoleDTO> to List<Role>
//        public static ICollection<Role> MapRoleToModelList(ICollection<RoleDTO> roleDTOs)
//        {
//            if (roleDTOs == null || roleDTOs.Count == 0)
//            {
//                return null;
//            }

//            var roles = new List<Role>();

//            foreach (var roleDTO in roleDTOs)
//            {
//                var role = MapToModelEndpoint(roleDTO);
//                roles.Add(role);
//            }

//            return roles;
//        }

//    }
//}
