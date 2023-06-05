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
                CompanyId = person.CompanyId,
                DepartmentId = person.DepartmentId,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(person.Company),
                DepartmentDTO = (person.Department == null) ? null : DepartmentMapper.MapToDTOEndpoint(person.Department),
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
                CompanyId = person.CompanyId,
                DepartmentId = person.DepartmentId,
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
                CompanyId = personDTO.CompanyId,
                DepartmentId = personDTO.DepartmentId,

                Company = CompanyMapper.MapToModelEndpoint(personDTO.CompanyDTO),
                Department = (personDTO.DepartmentDTO == null) ? null : DepartmentMapper.MapToModelEndpoint(personDTO.DepartmentDTO),
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
                CompanyId = personDTO.CompanyId,
                DepartmentId = personDTO.DepartmentId,
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

            var personDTOList = new List<PersonDTO>();

            foreach (var person in people)
            {
                var personDTO = MapToDTOEndpoint(person);
                personDTOList.Add(personDTO);
            }

            return personDTOList;
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