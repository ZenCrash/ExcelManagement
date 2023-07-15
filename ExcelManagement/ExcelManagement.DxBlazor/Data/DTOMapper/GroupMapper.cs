
using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;
using static ExcelManagement.DxBlazor.Pages.Account.RegisterModel;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public class GroupMapper
    {
        public static GroupDTO MapToDTO(Group group)
        {
            GroupDTO dto = new GroupDTO()
            {
                Id = group.Id,
                GroupName = group.GroupName,
                Description = group.Description,
                GroupLogoUrl = group.GroupLogoUrl,
                CreatedDate = group.CreatedDate,
                UpdatedDate = group.UpdatedDate,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(group.Company),
                CreatedByDTO = PersonMapper.MapToDTOEndpoint(group.CreatedBy),
                UpdatedByDTO = PersonMapper.MapToDTOEndpoint(group.UpdatedBy),

                PersonDTOs = (group.Persons == null || group.Persons.Count == 0) ? null : PersonMapper.MapToDTOEndpointList(group.Persons),
                GroupDTOs = (group.Groups == null || group.Groups.Count == 0) ? null : GroupMapper.MapToDTOEndpointList(group.Groups),
                FileAndFolderDTOs = (group.FileAndFolders == null || group.FileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapToDTOEndpointList(group.FileAndFolders),
            };
            return dto;
        }

        public static GroupDTO MapToDTOEndpoint(Group group)
        {
            GroupDTO dto = new GroupDTO()
            {
                Id = group.Id,
                GroupName = group.GroupName,
                Description = group.Description,
                GroupLogoUrl = group.GroupLogoUrl,
                CreatedDate = group.CreatedDate,
                UpdatedDate = group.UpdatedDate,
            };
            return dto;
        }

        public static Group MapToModel(GroupDTO groupDTO)
        {
            Group model = new Group()
            {
                Id = groupDTO.Id,
                GroupName = groupDTO.GroupName,
                Description = groupDTO.Description,
                GroupLogoUrl = groupDTO.GroupLogoUrl,
                CreatedDate = groupDTO.CreatedDate,
                UpdatedDate = groupDTO.UpdatedDate,

                Company = CompanyMapper.MapToModelEndpoint(groupDTO.CompanyDTO),
                CreatedBy = PersonMapper.MapToModelEndpoint(groupDTO.CreatedByDTO),
                UpdatedBy = PersonMapper.MapToModelEndpoint(groupDTO.UpdatedByDTO),

                Persons = (groupDTO.PersonDTOs == null || groupDTO.PersonDTOs.Count == 0) ? null : PersonMapper.MapToModelEndpointList(groupDTO.PersonDTOs),
                Groups = (groupDTO.GroupDTOs == null || groupDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapToModelEndpointList(groupDTO.GroupDTOs),
                FileAndFolders = (groupDTO.FileAndFolderDTOs == null || groupDTO.FileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapToModelEndpointList(groupDTO.FileAndFolderDTOs),
            };
            return model;
        }

        public static Group MapToModelEndpoint(GroupDTO groupDTO)
        {
            Group model = new Group()
            {
                Id = groupDTO.Id,
                GroupName = groupDTO.GroupName,
                Description = groupDTO.Description,
                GroupLogoUrl = groupDTO.GroupLogoUrl,
                CreatedDate = groupDTO.CreatedDate,
                UpdatedDate = groupDTO.UpdatedDate,
            };
            return model;
        }

        //Logic

        //Map List<Object> to List<ObjectDTO>
        public static ICollection<GroupDTO> MapToDTOEndpointList(ICollection<Group> groups)
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

        //Map List<ObjectDTO> to List<Object>
        public static ICollection<Group> MapToModelEndpointList(ICollection<GroupDTO> groupDTOs)
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
