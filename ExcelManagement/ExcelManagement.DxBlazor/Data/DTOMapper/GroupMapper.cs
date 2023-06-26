//using ExcelManagement.DxBlazor.Data.Models;
//using ExcelManagement.DxBlazor.Data.DTO;

//namespace ExcelManagement.DxBlazor.Data.DTOMapper
//{
//    public class GroupMapper
//    {
//        //Map to Dto
//        public static GroupDTO MapToDTO(Group group)
//        {
//            GroupDTO groupDTO = new GroupDTO
//            {
//                Id = group.Id,
//                GroupName = group.GroupName,
//                Description = group.Description,
//                GroupLogoUrl = group.GroupLogoUrl,
//                CreatedDate = group.CreatedDate,

//                CompanyId = group.CompanyId,
//                CreatedByPersonId = group.CreatedByPersonId,
//                UpdatedByPersonId = group.UpdatedByPersonId,

//                CompanyDTO = CompanyMapper.MapToDTOEndpoint(group.Company),
//                CreatedByPersonDTO = PersonMapper.MapToDTOEndpoint(group.CreatedByPerson),
//                UpdatedByPersonDTO = PersonMapper.MapToDTOEndpoint(group.UpdatedByPerson),

//                PeopleDTOs = (group.People == null || group.People.Count == 0) ? null : PersonMapper.MapPersonToDTOList(group.People),
//                FilesAndFolderDTOs = (group.FilesAndFolders == null || group.FilesAndFolders.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToDTOList(group.FilesAndFolders),

//            };

//            return groupDTO;
//        }

//        //Map to Dto Endpoint
//        public static GroupDTO MapToDTOEndpoint(Group group)
//        {
//            GroupDTO groupDTO = new GroupDTO
//            {
//                Id = group.Id,
//                GroupName = group.GroupName,
//                Description = group.Description,
//                GroupLogoUrl = group.GroupLogoUrl,
//                CreatedDate = group.CreatedDate,

//                CompanyId = group.CompanyId,
//                CreatedByPersonId = group.CreatedByPersonId,
//                UpdatedByPersonId = group.UpdatedByPersonId,
//            };

//            return groupDTO;
//        }

//        //Map to Model
//        public static Group MapToModel(GroupDTO groupDTO)
//        {
//            Group group = new Group
//            {
//                Id = groupDTO.Id,
//                GroupName = groupDTO.GroupName,
//                Description = groupDTO.Description,
//                GroupLogoUrl = groupDTO.GroupLogoUrl,
//                CreatedDate = groupDTO.CreatedDate,

//                CompanyId = groupDTO.CompanyId,
//                CreatedByPersonId = groupDTO.CreatedByPersonId,
//                UpdatedByPersonId = groupDTO.UpdatedByPersonId,

//                Company = CompanyMapper.MapToModelEndpoint(groupDTO.CompanyDTO),
//                CreatedByPerson = PersonMapper.MapToModelEndpoint(groupDTO.CreatedByPersonDTO),
//                UpdatedByPerson = PersonMapper.MapToModelEndpoint(groupDTO.UpdatedByPersonDTO),

//                People = (groupDTO.PeopleDTOs == null || groupDTO.PeopleDTOs.Count == 0) ? null : PersonMapper.MapPersonToModelList(groupDTO.PeopleDTOs),
//                FilesAndFolders = (groupDTO.FilesAndFolderDTOs == null || groupDTO.FilesAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToModelList(groupDTO.FilesAndFolderDTOs),
//            };

//            return group;
//        }

//        //Map to Model Endpoint
//        public static Group MapToModelEndpoint(GroupDTO groupDTO)
//        {
//            Group group = new Group
//            {
//                Id = groupDTO.Id,
//                GroupName = groupDTO.GroupName,
//                Description = groupDTO.Description,
//                GroupLogoUrl = groupDTO.GroupLogoUrl,
//                CreatedDate = groupDTO.CreatedDate,

//                CompanyId = groupDTO.CompanyId,
//                CreatedByPersonId = groupDTO.CreatedByPersonId,
//                UpdatedByPersonId = groupDTO.UpdatedByPersonId,
//            };

//            return group;
//        }


//        //Logic

//        //Map List<Group> to List<GroupDTO>
//        public static ICollection<GroupDTO> MapGroupToDTOList(ICollection<Group> groups)
//        {
//            if (groups == null || groups.Count == 0)
//            {
//                return null;
//            }

//            var groupDTOs = new List<GroupDTO>();

//            foreach (var group in groups)
//            {
//                var groupDTO = MapToDTOEndpoint(group);
//                groupDTOs.Add(groupDTO);
//            }

//            return groupDTOs;
//        }

//        //Map List<GroupDTO> to List<Group>
//        public static ICollection<Group> MapGroupToModelList(ICollection<GroupDTO> groupDTOs)
//        {
//            if (groupDTOs == null || groupDTOs.Count == 0)
//            {
//                return null;
//            }

//            var groups = new List<Group>();

//            foreach (var groupDTO in groupDTOs)
//            {
//                var group = MapToModelEndpoint(groupDTO);
//                groups.Add(group);
//            }

//            return groups;
//        }

//    }
//}
