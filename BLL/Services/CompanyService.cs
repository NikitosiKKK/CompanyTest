using BLL.Interfaces;
using BLL.Maps;
using BLL.Models;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository= companyRepository;
        }

        public CompanyModel Create(CompanyModel companyModel)
        {
            var companyEntity = CompanyMap.Map(companyModel);
            var createEntity = _companyRepository.Create(companyEntity);
            return CompanyMap.Map(createEntity);
        }

        public void Delete(int id)
        {
            _companyRepository.Delete(id);
        }

        public CompanyModel Get(int id)
        {
            var companyEntity = _companyRepository.Get(id);

            return CompanyMap.Map(companyEntity);
        }

        public List<CompanyModel> List()
        {
            var companyEntities = _companyRepository.List();

            var companyModels = companyEntities.Select(p => CompanyMap.Map(p));
            return companyModels.ToList();
        }

        public CompanyModel Update(int id, CompanyUpdateModel companyModel)
        {
            var companyEntity = CompanyMap.Map(companyModel);
            var updatedEntity = _companyRepository.Update(companyEntity, id);
            return CompanyMap.Map(updatedEntity);
        }
    }
}
