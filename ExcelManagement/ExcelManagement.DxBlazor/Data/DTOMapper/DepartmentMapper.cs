using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DTOMapper
{
    public static class DepartmentMapper
    {
        //Map to Dto
        public static DepartmentDTO MapToDTO(Department department)
        {
            var departmentDTO = new DepartmentDTO
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                Description = department.Description,

                CompanyDTO = CompanyMapper.MapToDTOEndpoint(department.Company),
                PersonDTOList = (department.People == null || department.People.Count == 0) ? null : PersonMapper.MapPersonToDTOList(department.People),
            };

            return departmentDTO;
        }

        //Map to Dto Endpoint
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

        //Map to Model
        public static Department MapToModel(DepartmentDTO departmentDTO)
        {
            var department = new Department
            {
                Id = departmentDTO.Id,
                DepartmentName = departmentDTO.DepartmentName,
                Description = departmentDTO.Description,

                Company = CompanyMapper.MapToModelEndpoint(departmentDTO.CompanyDTO),
                People = (departmentDTO.PersonDTOList == null || departmentDTO.PersonDTOList.Count == 0) ? null : PersonMapper.MapPersonToModelList(departmentDTO.PersonDTOList),
            };

            return department;
        }

        //Map to Model Endpoint
        public static Department MapToModelEndpoint(DepartmentDTO departmentDTO)
        {
            var department = new Department
            {
                Id = departmentDTO.Id,
                DepartmentName = departmentDTO.DepartmentName,
                Description = departmentDTO.Description
            };

            return department;
        }

        //Logic

        //Map List<Department> to List<DepartmentDTO>

        public static ICollection<DepartmentDTO> MapDepartmentToDTOList(ICollection<Department> departments)
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

        //Map List<DepartmentDTO> to List<Department>
        public static ICollection<Department> MapDepartmentToModelList(ICollection<DepartmentDTO> departmentDTOs)
        {
            if (departmentDTOs == null || departmentDTOs.Count == 0)
            {
                return null;
            }

            var departments = new List<Department>();

            foreach (var departmentDTO in departmentDTOs)
            {
                var department = DepartmentMapper.MapToModelEndpoint(departmentDTO);
                departments.Add(department);
            }

            return departments;
        }
    }
}
