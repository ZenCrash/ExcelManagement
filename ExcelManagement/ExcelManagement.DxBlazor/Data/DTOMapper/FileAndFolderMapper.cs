//using ExcelManagement.DxBlazor.Data.DTO;
//using ExcelManagement.DxBlazor.Data;
//using ExcelManagement.DxBlazor.Data.Models;

//namespace ExcelManagement.DxBlazor.Data.DTOMapper
//{
//    public class FileAndFolderMapper
//    {
//        //Map to Dto
//        public static FileAndFolderDTO MapToDTO(FileAndFolder fileAndFolder) 
//        {
//            FileAndFolderDTO fileAndFolderDTO = new FileAndFolderDTO
//            {
//                Id = fileAndFolder.Id,
//                ItemName = fileAndFolder.ItemName,
//                Description = fileAndFolder.Description,
//                RelativeFilePath = fileAndFolder.RelativeFilePath,
//                CreatedDate = fileAndFolder.CreatedDate,
//                DataType = fileAndFolder.DataType,

//                CompanyId = fileAndFolder.CompanyId,
//                CreatedByPersonId = fileAndFolder.CreatedByPersonId,
//                UpdatedByPersonId = fileAndFolder.UpdatedByPersonId,

//                CompanyDTO = CompanyMapper.MapToDTOEndpoint(fileAndFolder.Company),
//                CreatedByPersonDTO = PersonMapper.MapToDTOEndpoint(fileAndFolder.CreatedByPerson),
//                UpdatedByPersonDTO = PersonMapper.MapToDTOEndpoint(fileAndFolder.UpdatedByPerson),

//                PeopleDTOs = (fileAndFolder.People == null || fileAndFolder.People.Count == 0) ? null : PersonMapper.MapPersonToDTOList(fileAndFolder.People),
//                GroupDTOs = (fileAndFolder.Groups == null || fileAndFolder.Groups.Count == 0) ? null : GroupMapper.MapGroupToDTOList(fileAndFolder.Groups),
//            };

//            return fileAndFolderDTO;
//        }

//        //Map to Dto Endpoint
//        public static FileAndFolderDTO MapToDTOEndpoint(FileAndFolder fileAndFolder)
//        {
//            FileAndFolderDTO fileAndFolderDTO = new FileAndFolderDTO
//            {
//                Id = fileAndFolder.Id,
//                ItemName = fileAndFolder.ItemName,
//                Description = fileAndFolder.Description,
//                RelativeFilePath = fileAndFolder.RelativeFilePath,
//                CreatedDate = fileAndFolder.CreatedDate,
//                DataType = fileAndFolder.DataType,

//                CompanyId = fileAndFolder.CompanyId,
//                CreatedByPersonId = fileAndFolder.CreatedByPersonId,
//                UpdatedByPersonId = fileAndFolder.UpdatedByPersonId,
//            };

//            return fileAndFolderDTO;
//        }

//        //Map to Model
//        public static FileAndFolder MapToModel(FileAndFolderDTO fileAndFolderDTO)
//        {
//            FileAndFolder fileAndFolder = new FileAndFolder
//            {
//                Id = fileAndFolderDTO.Id,
//                ItemName = fileAndFolderDTO.ItemName,
//                Description = fileAndFolderDTO.Description,
//                RelativeFilePath = fileAndFolderDTO.RelativeFilePath,
//                CreatedDate = fileAndFolderDTO.CreatedDate,
//                DataType = fileAndFolderDTO.DataType,

//                CompanyId = fileAndFolderDTO.CompanyId,
//                CreatedByPersonId = fileAndFolderDTO.CreatedByPersonId,
//                UpdatedByPersonId = fileAndFolderDTO.UpdatedByPersonId,

//                Company = CompanyMapper.MapToModelEndpoint(fileAndFolderDTO.CompanyDTO),
//                CreatedByPerson = PersonMapper.MapToModelEndpoint(fileAndFolderDTO.CreatedByPersonDTO),
//                UpdatedByPerson = PersonMapper.MapToModelEndpoint(fileAndFolderDTO.UpdatedByPersonDTO),

//                People = (fileAndFolderDTO.PeopleDTOs == null || fileAndFolderDTO.PeopleDTOs.Count == 0) ? null : PersonMapper.MapPersonToModelList(fileAndFolderDTO.PeopleDTOs),
//                Groups = (fileAndFolderDTO.GroupDTOs == null || fileAndFolderDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapGroupToModelList(fileAndFolderDTO.GroupDTOs),
//            };

//            return fileAndFolder;
//        }

//        //Map to Model Endpoint
//        public static FileAndFolder MapToModelEndpoint(FileAndFolderDTO fileAndFolderDTO)
//        {
//            FileAndFolder fileAndFolder = new FileAndFolder
//            {
//                Id = fileAndFolderDTO.Id,
//                ItemName = fileAndFolderDTO.ItemName,
//                Description = fileAndFolderDTO.Description,
//                RelativeFilePath = fileAndFolderDTO.RelativeFilePath,
//                CreatedDate = fileAndFolderDTO.CreatedDate,
//                DataType = fileAndFolderDTO.DataType,

//                CompanyId = fileAndFolderDTO.CompanyId,
//                CreatedByPersonId = fileAndFolderDTO.CreatedByPersonId,
//                UpdatedByPersonId = fileAndFolderDTO.UpdatedByPersonId,
//            };

//            return fileAndFolder;
//        }


//        //Logic

//        //Map List<FileAndFolder> to List<FileAndFolderDTO>
//        public static ICollection<FileAndFolderDTO> MapFileAndFolderToDTOList(ICollection<FileAndFolder> filesAndFolders)
//        {
//            if (filesAndFolders == null || filesAndFolders.Count == 0)
//            {
//                return null;
//            }

//            var filesAndFolderDTOs = new List<FileAndFolderDTO>();

//            foreach (var fileAndFolder in filesAndFolders)
//            {
//                var fileAndFolderDTO = MapToDTOEndpoint(fileAndFolder);
//                filesAndFolderDTOs.Add(fileAndFolderDTO);
//            }

//            return filesAndFolderDTOs;
//        }

//        //Map List<FileAndFolderDTO> to List<FileAndFolder>
//        public static ICollection<FileAndFolder> MapFileAndFolderToModelList(ICollection<FileAndFolderDTO> filesAndFolderDTOs)
//        {
//            if (filesAndFolderDTOs == null || filesAndFolderDTOs.Count == 0)
//            {
//                return null;
//            }

//            var filesAndFolders = new List<FileAndFolder>();

//            foreach (var fileAndFolderDTO in filesAndFolderDTOs)
//            {
//                var fileAndFolder = MapToModelEndpoint(fileAndFolderDTO);
//                filesAndFolders.Add(fileAndFolder);
//            }

//            return filesAndFolders;
//        }
//    }
//}
