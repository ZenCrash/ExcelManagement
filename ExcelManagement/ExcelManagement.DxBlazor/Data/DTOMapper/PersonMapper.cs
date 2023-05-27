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

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(person.Company),
                DepartmentDTO = DepartmentMapper.MapToDTOEndpoint(person.Department),
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
            };

            return personDTO;
        }

        //Logic
        public static ICollection<PersonDTO> MapPeopleList(ICollection<Person> people)
        {
            if (people == null || people.Count == 0)
            {
                return null;
            }

            var personDTOList = new List<PersonDTO>();

            foreach (var person in people)
            {
                var departmentDTO = MapToDTOEndpoint(person);
                personDTOList.Add(departmentDTO);
            }

            return personDTOList;
        }
    }
}