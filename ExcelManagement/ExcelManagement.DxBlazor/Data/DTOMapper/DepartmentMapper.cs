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

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(department.Company)


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
    }
}
