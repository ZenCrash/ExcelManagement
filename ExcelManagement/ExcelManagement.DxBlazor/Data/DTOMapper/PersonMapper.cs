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
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                JobTitle = person.JobTitle,
                Bio = person.Bio,
                ProfileImageUrl = person.ProfileImageUrl,
                CreatedDate = person.CreatedDate,
                UpdatedDate = person.UpdatedDate,

                MemberCompanyDTO = CompanyMapper.MapToDTOEndpoint(person.MemberCompany),
                PersonCreatedByDTO = PersonMapper.MapToDTOEndpoint(person.PersonCreatedBy),
                PersonUpdatedByDTO = PersonMapper.MapToDTOEndpoint(person.PersonUpdatedBy),

                RoleDTOs = (person.Roles == null || person.Roles.Count == 0) ? null : RoleMapper.MapRoleToDTOList(person.Roles),
                GroupDTOs = (person.Groups == null || person.Groups.Count == 0) ? null : GroupMapper.MapGroupToDTOList(person.Groups),
                FileAndFolderDTOs = (person.FileAndFolders == null || person.FileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToDTOList(person.FileAndFolders),

                CreatedPersonDTOs = (person.CreatedPersons == null || person.CreatedPersons.Count == 0) ? null : PersonMapper.MapPersonToDTOList(person.CreatedPersons),
                UpdatedPersonDTOs = (person.UpdatedPersons == null || person.UpdatedPersons.Count == 0) ? null : PersonMapper.MapPersonToDTOList(person.UpdatedPersons),
                CreatedCompanyDTOs = (person.CreatedCompanys == null || person.CreatedCompanys.Count == 0) ? null : CompanyMapper.MapCompanyToDTOList(person.CreatedCompanys),
                UpdatedCompanyDTOs = (person.UpdatedCompanys == null || person.UpdatedCompanys.Count == 0) ? null : CompanyMapper.MapCompanyToDTOList(person.UpdatedCompanys),
                CreatedRoleDTOs = (person.CreatedRoles == null || person.CreatedRoles.Count == 0) ? null : RoleMapper.MapRoleToDTOList(person.CreatedRoles),
                UpdatedRoleDTOs = (person.UpdatedRoles == null || person.UpdatedRoles.Count == 0) ? null : RoleMapper.MapRoleToDTOList(person.UpdatedRoles),
                CreatedGroupDTOs = (person.CreatedGroups == null || person.CreatedGroups.Count == 0) ? null : GroupMapper.MapGroupToDTOList(person.CreatedGroups),
                UpdatedGroupDTOs = (person.UpdatedGroups == null || person.UpdatedGroups.Count == 0) ? null : GroupMapper.MapGroupToDTOList(person.UpdatedGroups),
                CreatedFileAndFolderDTOs = (person.CreatedFileAndFolders == null || person.CreatedFileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToDTOList(person.CreatedFileAndFolders),
                UpdatedFileAndFolderDTOs = (person.UpdatedFileAndFolders == null || person.UpdatedFileAndFolders.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToDTOList(person.UpdatedFileAndFolders),

            };

            return personDTO;
        }

        //Map to Dto Endpoint
        public static PersonDTO MapToDTOEndpoint(Person person)
        {
            var personDTO = new PersonDTO
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                JobTitle = person.JobTitle,
                Bio = person.Bio,
                ProfileImageUrl = person.ProfileImageUrl,
                CreatedDate = person.CreatedDate,
                UpdatedDate = person.UpdatedDate,
            };

            return personDTO;
        }

        //Map to Model
        public static Person MapToModel(PersonDTO personDTO)
        {
            var person = new Person
            {
                PersonId = personDTO.PersonId,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                JobTitle = personDTO.JobTitle,
                Bio = personDTO.Bio,
                ProfileImageUrl = personDTO.ProfileImageUrl,
                CreatedDate = personDTO.CreatedDate,
                UpdatedDate = personDTO.UpdatedDate,

                MemberCompany = CompanyMapper.MapToModelEndpoint(personDTO.MemberCompanyDTO),
                PersonCreatedBy = PersonMapper.MapToModelEndpoint(personDTO.PersonCreatedByDTO),
                PersonUpdatedBy = PersonMapper.MapToModelEndpoint(personDTO.PersonUpdatedByDTO),

                Roles = (personDTO.RoleDTOs == null || personDTO.RoleDTOs.Count == 0) ? null : RoleMapper.MapRoleToModelList(personDTO.RoleDTOs),
                Groups = (personDTO.GroupDTOs == null || personDTO.GroupDTOs.Count == 0) ? null : GroupMapper.MapGroupToModelList(personDTO.GroupDTOs),
                FileAndFolders = (personDTO.FileAndFolderDTOs == null || personDTO.FileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToModelList(personDTO.FileAndFolderDTOs),

                CreatedPersons = (personDTO.CreatedPersonDTOs == null || personDTO.CreatedPersonDTOs.Count == 0) ? null : PersonMapper.MapPersonToModelList(personDTO.CreatedPersonDTOs),
                UpdatedPersons = (personDTO.UpdatedPersonDTOs == null || personDTO.UpdatedPersonDTOs.Count == 0) ? null : PersonMapper.MapPersonToModelList(personDTO.UpdatedPersonDTOs),
                CreatedCompanys = (personDTO.CreatedCompanyDTOs == null || personDTO.CreatedCompanyDTOs.Count == 0) ? null : CompanyMapper.MapCompanyToModelList(personDTO.CreatedCompanyDTOs),
                UpdatedCompanys = (personDTO.UpdatedCompanyDTOs == null || personDTO.UpdatedCompanyDTOs.Count == 0) ? null : CompanyMapper.MapCompanyToModelList(personDTO.UpdatedCompanyDTOs),
                CreatedRoles = (personDTO.CreatedRoleDTOs == null || personDTO.CreatedRoleDTOs.Count == 0) ? null : RoleMapper.MapRoleToModelList(personDTO.CreatedRoleDTOs),
                UpdatedRoles = (personDTO.UpdatedRoleDTOs == null || personDTO.UpdatedRoleDTOs.Count == 0) ? null : RoleMapper.MapRoleToModelList(personDTO.UpdatedRoleDTOs),
                CreatedGroups = (personDTO.CreatedGroupDTOs == null || personDTO.CreatedGroupDTOs.Count == 0) ? null : GroupMapper.MapGroupToModelList(personDTO.CreatedGroupDTOs),
                UpdatedGroups = (personDTO.UpdatedGroupDTOs == null || personDTO.UpdatedGroupDTOs.Count == 0) ? null : GroupMapper.MapGroupToModelList(personDTO.UpdatedGroupDTOs),
                CreatedFileAndFolders = (personDTO.CreatedFileAndFolderDTOs == null || personDTO.CreatedFileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToModelList(personDTO.CreatedFileAndFolderDTOs),
                UpdatedFileAndFolders = (personDTO.UpdatedFileAndFolderDTOs == null || personDTO.UpdatedFileAndFolderDTOs.Count == 0) ? null : FileAndFolderMapper.MapFileAndFolderToModelList(personDTO.UpdatedFileAndFolderDTOs),
            };

            return person;
        }

        //Map to Model Endpoint
        public static Person MapToModelEndpoint(PersonDTO personDTO)
        {
            var person = new Person
            {
                PersonId = personDTO.PersonId,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                JobTitle = personDTO.JobTitle,
                Bio = personDTO.Bio,
                ProfileImageUrl = personDTO.ProfileImageUrl,
                CreatedDate = personDTO.CreatedDate,
                UpdatedDate = personDTO.UpdatedDate,
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