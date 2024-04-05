using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.DbOption.Repository;

namespace ExcelManagement.DxBlazor.Data.Logic
{
    public class FolderLogic
    {
        public string MainDirectory { get; init; } = @"..\ExcelDocuments";

        private readonly CompanyRepository _companyRepository;

        public FolderLogic(CompanyRepository companyRepository) 
        {
            _companyRepository = companyRepository;
        }
        //public async Task CreateFoldersByCompanyandDepartment(CompanyRepository companyRepository)
        //{
        //    var companies = _companyRepository.GetAll();

        //    foreach (var company in companies)
        //    {
        //        string folderPath = Path.Combine(MainDirectory, company.Id.ToString());
        //        if (!Directory.Exists(folderPath))
        //        {
        //            Directory.CreateDirectory(folderPath);

        //        }
        //    }
        //}

        
    }
}
