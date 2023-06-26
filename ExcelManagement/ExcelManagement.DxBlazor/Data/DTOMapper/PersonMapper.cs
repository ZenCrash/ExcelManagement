using DocumentFormat.OpenXml.ExtendedProperties;
using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public static class PersonMapper
    {
        //Map to Dto
        public static PersonDTO MapToDTO(Person person)
        {
            var personDTO = new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                JobTitle = person.JobTitle,
                Bio = person.Bio,
                ProfileImageUrl = person.ProfileImageUrl,
                CreatedDate = person.CreatedDate,
                UpdatedDate = person.UpdatedDate,

                CompanyId = person.CompanyId,
                CreatedByPersonId = person.CreatedByPersonId,
                UpdatedByPersonId = person.UpdatedByPersonId,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(person.Company),
                CreatedByPersonDTO = PersonMapper.MapToDTOEndpoint(person.CreatedByPerson),
                UpdatedByPersonDTO = PersonMapper.MapToDTOEndpoint(person.UpdatedByPerson),

                RoleDTOs = (person.Roles == null || person.Roles.Count == 0) ? null : RoleMapper.MapRoleToDTOList(person.Roles),
                GroupDTOs = (person.Groups == null || person.Groups.Count == 0) ? null : GroupMapper.MapGroupToDTOList(person.Groups),
                FilesAndFolderDTOs = (person.FilesAndFolders == null || person.FilesAndFolders.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToDTOList(person.FilesAndFolders),
            };

            return personDTO;
        }

        //Map to Dto Endpoint
        public static PersonDTO MapToDTOEndpoint(Person person)
        {
            var personDTO = new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                JobTitle = person.JobTitle,
                Bio = person.Bio,
                ProfileImageUrl = person.ProfileImageUrl,
                CreatedDate = person.CreatedDate,
                UpdatedDate = person.UpdatedDate,

                CompanyId = person.CompanyId,
                CreatedByPersonId = person.CreatedByPersonId,
                UpdatedByPersonId = person.UpdatedByPersonId,
            };

            return personDTO;
        }

        //Map to Model
        public static Person MapToModel(PersonDTO personDTO)
        {
            var person = new Person
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                JobTitle = personDTO.JobTitle,
                Bio = personDTO.Bio,
                ProfileImageUrl = personDTO.ProfileImageUrl,
                CreatedDate = personDTO.CreatedDate,
                UpdatedDate = personDTO.UpdatedDate,

                CompanyId = personDTO.CompanyId,
                CreatedByPersonId = personDTO.CreatedByPersonId,
                UpdatedByPersonId = personDTO.UpdatedByPersonId,

                Company = CompanyMapper.MapToModelEndpoint(personDTO.CompanyDTO),
                CreatedByPerson = PersonMapper.MapToModelEndpoint(personDTO.CreatedByPersonDTO),
                UpdatedByPerson = PersonMapper.MapToModelEndpoint(personDTO.UpdatedByPersonDTO),

                Roles = (personDTO.RoleDTOs == null || personDTO.RoleDTOs.Count == 0) ? null : RoleMapper.MapRoleToModelList(personDTO.RoleDTOs),
                Groups = (personDTO.GroupDTOs == null || personDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapGroupToModelList(personDTO.GroupDTOs),
                FilesAndFolders = (personDTO.FilesAndFolderDTOs == null || personDTO.FilesAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToModelList(personDTO.FilesAndFolderDTOs),
            };

            return person;
        }

        //Map to Model Endpoint
        public static Person MapToModelEndpoint(PersonDTO personDTO)
        {
            var person = new Person
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                JobTitle = personDTO.JobTitle,
                Bio = personDTO.Bio,
                ProfileImageUrl = personDTO.ProfileImageUrl,
                CreatedDate = personDTO.CreatedDate,
                UpdatedDate = personDTO.UpdatedDate,

                CompanyId = personDTO.CompanyId,
                CreatedByPersonId = personDTO.CreatedByPersonId,
                UpdatedByPersonId = personDTO.UpdatedByPersonId,
            };

            return person;
        }

        //Logic

        //Map List<Person> to List<PersonDTO>
        public static ICollection<PersonDTO> MapPersonToDTOList(ICollection<Person> people)
        {
            if (people == null || people.Count == 0)
            {
                return null;
            }

            var personDTOs = new List<PersonDTO>();

            foreach (var person in people)
            {
                var personDTO = MapToDTOEndpoint(person);
                personDTOs.Add(personDTO);
            }

            return personDTOs;
        }

        //Map List<PersonDTO> to List<Person>
        public static ICollection<Person> MapPersonToModelList(ICollection<PersonDTO> personDTOs)
        {
            if (personDTOs == null || personDTOs.Count == 0)
            {
                return null;
            }

            var people = new List<Person>();

            foreach (var personDTO in personDTOs)
            {
                var person = MapToModelEndpoint(personDTO);
                people.Add(person);
            }

            return people;
        }
    }
}