using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public static class DepartmentMapper
    {
        public static DepartmentDTO MapToDTO(Department department)
        {
            var departmentDTO = new DepartmentDTO
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                Description = department.Description,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(department.Company),
                PersonDTOList = PersonMapper.MapPeopleList(department.People),
            };

            return departmentDTO;
        }

        public static DepartmentDTO MapToDTOEndpoint(Department department)
        {
            var departmentDTO = new DepartmentDTO
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                Description = department.Description
            };

            return departmentDTO;
        }

        public static ICollection<DepartmentDTO> MapDepartmentList(ICollection<Department> departments)
        {
            if (departments == null || departments.Count == 0)
            {
                return null;
            }

            var departmentDTOList = new List<DepartmentDTO>();

            foreach (var department in departments)
            {
                var departmentDTO = DepartmentMapper.MapToDTOEndpoint(department);
                departmentDTOList.Add(departmentDTO);
            }

            return departmentDTOList;
        }
    }
}
