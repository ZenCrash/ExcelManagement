using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public class FileAndFolderMapper
    {
        public static FileAndFolderDTO MapToDTO(FileAndFolder fileAndFolder)
        {
            FileAndFolderDTO dto = new FileAndFolderDTO()
            {
                Id = fileAndFolder.Id,
                ItemName = fileAndFolder.ItemName,
                Description = fileAndFolder.Description,
                RelativeFilePath = fileAndFolder.RelativeFilePath,
                CreatedDate = fileAndFolder.CreatedDate,
                UpdatedDate = fileAndFolder.UpdatedDate,
                DataType = fileAndFolder.DataType,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(fileAndFolder.Company),
                CreatedByDTO = PersonMapper.MapToDTOEndpoint(fileAndFolder.CreatedBy),
                UpdatedByDTO = PersonMapper.MapToDTOEndpoint(fileAndFolder.UpdatedBy),

                FileAndFolderDTOs = (fileAndFolder.FileAndFolders == null || fileAndFolder.FileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapToDTOEndpointList(fileAndFolder.FileAndFolders),
                PersonDTOs = (fileAndFolder.Persons == null || fileAndFolder.Persons.Count == 0) ? null : PersonMapper.MapToDTOEndpointList(fileAndFolder.Persons),
                RoleDTOs = (fileAndFolder.Roles == null || fileAndFolder.Roles.Count == 0) ? null : RoleMapper.MapToDTOEndpointList(fileAndFolder.Roles),
                GroupDTOs = (fileAndFolder.Groups == null || fileAndFolder.Groups.Count == 0) ? null : GroupMapper.MapToDTOEndpointList(fileAndFolder.Groups),

            };
            return dto;
        }

        public static FileAndFolderDTO MapToDTOEndpoint(FileAndFolder fileAndFolder)
        {
            FileAndFolderDTO dto = new FileAndFolderDTO()
            {
                Id = fileAndFolder.Id,
                ItemName = fileAndFolder.ItemName,
                Description = fileAndFolder.Description,
                RelativeFilePath = fileAndFolder.RelativeFilePath,
                CreatedDate = fileAndFolder.CreatedDate,
                UpdatedDate = fileAndFolder.UpdatedDate,
                DataType = fileAndFolder.DataType,
            };
            return dto;
        }

        public static FileAndFolder MapToModel(FileAndFolderDTO fileAndFolderDTO)
        {
            FileAndFolder model = new FileAndFolder()
            {
                Id = fileAndFolderDTO.Id,
                ItemName = fileAndFolderDTO.ItemName,
                Description = fileAndFolderDTO.Description,
                RelativeFilePath = fileAndFolderDTO.RelativeFilePath,
                CreatedDate = fileAndFolderDTO.CreatedDate,
                UpdatedDate = fileAndFolderDTO.UpdatedDate,
                DataType = fileAndFolderDTO.DataType,

                Company = CompanyMapper.MapToModelEndpoint(fileAndFolderDTO.CompanyDTO),
                CreatedBy = PersonMapper.MapToModelEndpoint(fileAndFolderDTO.CreatedByDTO),
                UpdatedBy = PersonMapper.MapToModelEndpoint(fileAndFolderDTO.UpdatedByDTO),

                FileAndFolders = (fileAndFolderDTO.FileAndFolderDTOs == null || fileAndFolderDTO.FileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapToModelEndpointList(fileAndFolderDTO.FileAndFolderDTOs),
                Persons = (fileAndFolderDTO.PersonDTOs == null || fileAndFolderDTO.PersonDTOs.Count == 0) ? null : PersonMapper.MapToModelEndpointList(fileAndFolderDTO.PersonDTOs),
                Roles = (fileAndFolderDTO.RoleDTOs == null || fileAndFolderDTO.RoleDTOs.Count == 0) ? null : RoleMapper.MapToModelEndpointList(fileAndFolderDTO.RoleDTOs),
                Groups = (fileAndFolderDTO.GroupDTOs == null || fileAndFolderDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapToModelEndpointList(fileAndFolderDTO.GroupDTOs),
            };
            return model;
        }

        public static FileAndFolder MapToModelEndpoint(FileAndFolderDTO fileAndFolderDTO)
        {
            FileAndFolder model = new FileAndFolder()
            {
                Id = fileAndFolderDTO.Id,
                ItemName = fileAndFolderDTO.ItemName,
                Description = fileAndFolderDTO.Description,
                RelativeFilePath = fileAndFolderDTO.RelativeFilePath,
                CreatedDate = fileAndFolderDTO.CreatedDate,
                UpdatedDate = fileAndFolderDTO.UpdatedDate,
                DataType = fileAndFolderDTO.DataType,
            };
            return model;
        }

        //Logic

        //Map List<Object> to List<ObjectDTO>
        public static ICollection<FileAndFolderDTO> MapToDTOEndpointList(ICollection<FileAndFolder> fileAndFolders)
        {
            if (fileAndFolders == null || fileAndFolders.Count == 0)
            {
                return null;
            }

            var fileAndFolderDTOs = new List<FileAndFolderDTO>();

            foreach (var fileAndFolder in fileAndFolders)
            {
                var fileAndFolderDTO = MapToDTOEndpoint(fileAndFolder);
                fileAndFolderDTOs.Add(fileAndFolderDTO);
            }

            return fileAndFolderDTOs;
        }

        //Map List<ObjectDTO> to List<Object>
        public static ICollection<FileAndFolder> MapToModelEndpointList(ICollection<FileAndFolderDTO> fileAndFolderDTOs)
        {
            if (fileAndFolderDTOs == null || fileAndFolderDTOs.Count == 0)
            {
                return null;
            }

            var fileAndFolders = new List<FileAndFolder>();

            foreach (var fileAndFolderDTO in fileAndFolderDTOs)
            {
                var fileAndFolder = MapToModelEndpoint(fileAndFolderDTO);
                fileAndFolders.Add(fileAndFolder);
            }

            return fileAndFolders;
        }
    }
}
