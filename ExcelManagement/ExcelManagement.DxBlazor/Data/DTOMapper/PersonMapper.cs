using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public static class PersonMapper
    {
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
    }
}