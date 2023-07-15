using DevExpress.Pdf.Drawing;
using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public class PersonMapper
    {
        public static PersonDTO MapToDTO(Person person)
        {
            PersonDTO dto = new PersonDTO()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                JobTitle = person.JobTitle,
                Bio = person.Bio,
                ProfileImageUrl = person.ProfileImageUrl,
                CreatedDate = person.CreatedDate,
                UpdatedDate = person.UpdatedDate,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(person.Company),
                CreatedByDTO = PersonMapper.MapToDTOEndpoint(person.CreatedBy),
                UpdatedByDTO = PersonMapper.MapToDTOEndpoint(person.UpdatedBy),

                RoleDTOs = (person.Roles == null || person.Roles.Count == 0) ? null : RoleMapper.MapToDTOEndpointList(person.Roles),
                GroupDTOs = (person.Groups == null || person.Groups.Count == 0) ? null : GroupMapper.MapToDTOEndpointList(person.Groups),
                FileAndFolderDTOs = (person.FileAndFolders == null || person.FileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapToDTOEndpointList(person.FileAndFolders),
            };
            return dto;
        }

        public static PersonDTO MapToDTOEndpoint(Person person)
        {
            PersonDTO dto = new PersonDTO()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                JobTitle = person.JobTitle,
                Bio = person.Bio,
                ProfileImageUrl = person.ProfileImageUrl,
                CreatedDate = person.CreatedDate,
                UpdatedDate = person.UpdatedDate,
            };
            return dto;
        }

        public static Person MapToModel(PersonDTO personDTO)
        {
            Person model = new Person()
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                JobTitle = personDTO.JobTitle,
                Bio = personDTO.Bio,
                ProfileImageUrl = personDTO.ProfileImageUrl,
                CreatedDate = personDTO.CreatedDate,
                UpdatedDate = personDTO.UpdatedDate,

                Company = CompanyMapper.MapToModelEndpoint(personDTO.CompanyDTO),
                CreatedBy = PersonMapper.MapToModelEndpoint(personDTO.CreatedByDTO),
                UpdatedBy = PersonMapper.MapToModelEndpoint(personDTO.UpdatedByDTO),

                Roles = (personDTO.RoleDTOs == null || personDTO.RoleDTOs.Count == 0) ? null : RoleMapper.MapToModelEndpointList(personDTO.RoleDTOs),
                Groups = (personDTO.GroupDTOs == null || personDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapToModelEndpointList(personDTO.GroupDTOs),
                FileAndFolders = (personDTO.FileAndFolderDTOs == null || personDTO.FileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapToModelEndpointList(personDTO.FileAndFolderDTOs),
            };
            return model;
        }

        public static Person MapToModelEndpoint(PersonDTO personDTO)
        {
            Person model = new Person()
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                JobTitle = personDTO.JobTitle,
                Bio = personDTO.Bio,
                ProfileImageUrl = personDTO.ProfileImageUrl,
                CreatedDate = personDTO.CreatedDate,
                UpdatedDate = personDTO.UpdatedDate,
            };
            return model;
        }

        //Logic

        //Map List<Object> to List<ObjectDTO>
        public static ICollection<PersonDTO> MapToDTOEndpointList(ICollection<Person> persons)
        {
            if (persons == null || persons.Count == 0)
            {
                return null;
            }

            var personDTOs = new List<PersonDTO>();

            foreach (var person in persons)
            {
                var personDTO = MapToDTOEndpoint(person);
                personDTOs.Add(personDTO);
            }

            return personDTOs;
        }

        //Map List<ObjectDTO> to List<Object>
        public static ICollection<Person> MapToModelEndpointList(ICollection<PersonDTO> personDTOs)
        {
            if (personDTOs == null || personDTOs.Count == 0)
            {
                return null;
            }

            var persons = new List<Person>();

            foreach (var personDTO in personDTOs)
            {
                var person = MapToModelEndpoint(personDTO);
                persons.Add(person);
            }

            return persons;
        }
    }
}
