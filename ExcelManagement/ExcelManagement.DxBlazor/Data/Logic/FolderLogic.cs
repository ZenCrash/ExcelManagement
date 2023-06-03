using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.DbOption.Repository;

namespace ExcelManagement.DxBlazor.Data.Logic
{
    public class FolderLogic
    {
        public string MainDirectory { get; init; } = @"..\ExcelDocuments";

        private readonly CompanyRepository _companyRepository;
        private readonly DepartmentRepository _departmentRepository;

        public FolderLogic(CompanyRepository companyRepository, DepartmentRepository departmentRepository) 
        {
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task CreateFoldersByCompanyandDepartment(CompanyRepository companyRepository, DepartmentRepository departmentRepository)
        {
            var companies = _companyRepository.GetAll();
            var departments = _departmentRepository.GetAll();

            foreach (var company in companies)
            {
                string folderPath = Path.Combine(MainDirectory, company.Id.ToString());
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);

                }
            }

            async Task CreateFolderByDepartment(DepartmentRepository departmentRepository)
            {

            }
        }

        
    }
}
