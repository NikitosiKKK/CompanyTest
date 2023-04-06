using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICompanyRepository
    {
        public List<CompanyEntity> List();
        public CompanyEntity Get(int id);
        public CompanyEntity Update(CompanyEntity companyEntity, int id);
        public void Delete(int id);
        public CompanyEntity Create(CompanyEntity companyEntity);
    }
}
