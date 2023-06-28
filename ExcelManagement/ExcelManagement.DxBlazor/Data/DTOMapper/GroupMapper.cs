using ExcelManagement.DxBlazor.Data.Models;
using ExcelManagement.DxBlazor.Data.DTO;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public class GroupMapper
    {
        //Map to Dto
        public static GroupDTO MapToDTO(Group group)
        {
            GroupDTO groupDTO = new GroupDTO
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                Description = group.Description,
                GroupLogoUrl = group.GroupLogoUrl,
                CreatedDate = group.CreatedDate,
                UpdatedDate = group.UpdatedDate,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(group.Company),
                GroupCreatedByDTO = PersonMapper.MapToDTOEndpoint(group.GroupCreatedBy),
                GroupUpdatedByDTO = PersonMapper.MapToDTOEndpoint(group.GroupUpdatedBy),

                GroupDTOs = (group.Groups == null || group.Groups.Count == 0) ? null : GroupMapper.MapGroupToDTOList(group.Groups),
                FileAndFolderDTOs = (group.FileAndFolders == null || group.FileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToDTOList(group.FileAndFolders),
                PersonDTOs = (group.Persons == null || group.Persons.Count == 0) ? null : PersonMapper.MapPersonToDTOList(group.Persons),
            };

            return groupDTO;
        }

        //Map to Dto Endpoint
        public static GroupDTO MapToDTOEndpoint(Group group)
        {
            GroupDTO groupDTO = new GroupDTO
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                Description = group.Description,
                GroupLogoUrl = group.GroupLogoUrl,
                CreatedDate = group.CreatedDate,
                UpdatedDate = group.UpdatedDate,
            };

            return groupDTO;
        }

        //Map to Model
        public static Group MapToModel(GroupDTO groupDTO)
        {
            Group group = new Group
            {
                GroupId = groupDTO.GroupId,
                GroupName = groupDTO.GroupName,
                Description = groupDTO.Description,
                GroupLogoUrl = groupDTO.GroupLogoUrl,
                CreatedDate = groupDTO.CreatedDate,
                UpdatedDate = groupDTO.UpdatedDate,

                Company = CompanyMapper.MapToModelEndpoint(groupDTO.CompanyDTO),
                GroupCreatedBy = PersonMapper.MapToModelEndpoint(groupDTO.GroupCreatedByDTO),
                GroupUpdatedBy = PersonMapper.MapToModelEndpoint(groupDTO.GroupUpdatedByDTO),

                Groups = (groupDTO.GroupDTOs == null || groupDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapGroupToModelList(groupDTO.GroupDTOs),
                FileAndFolders = (groupDTO.FileAndFolderDTOs == null || groupDTO.FileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToModelList(groupDTO.FileAndFolderDTOs),
                Persons = (groupDTO.PersonDTOs == null || groupDTO.PersonDTOs.Count == 0) ? null : PersonMapper.MapPersonToModelList(groupDTO.PersonDTOs),
            };

            return group;
        }

        //Map to Model Endpoint
        public static Group MapToModelEndpoint(GroupDTO groupDTO)
        {
            Group group = new Group
            {
                GroupId = groupDTO.GroupId,
                GroupName = groupDTO.GroupName,
                Description = groupDTO.Description,
                GroupLogoUrl = groupDTO.GroupLogoUrl,
                CreatedDate = groupDTO.CreatedDate,
                UpdatedDate = groupDTO.UpdatedDate,
            };

            return group;
        }


        //Logic

        //Map List<Group> to List<GroupDTO>
        public static ICollection<GroupDTO> MapGroupToDTOList(ICollection<Group> groups)
        {
            if (groups == null || groups.Count == 0)
            {
                return null;
            }

            var groupDTOs = new List<GroupDTO>();

            foreach (var group in groups)
            {
                var groupDTO = MapToDTOEndpoint(group);
                groupDTOs.Add(groupDTO);
            }

            return groupDTOs;
        }

        //Map List<GroupDTO> to List<Group>
        public static ICollection<Group> MapGroupToModelList(ICollection<GroupDTO> groupDTOs)
        {
            if (groupDTOs == null || groupDTOs.Count == 0)
            {
                return null;
            }

            var groups = new List<Group>();

            foreach (var groupDTO in groupDTOs)
            {
                var group = MapToModelEndpoint(groupDTO);
                groups.Add(group);
            }

            return groups;
        }

    }
}
