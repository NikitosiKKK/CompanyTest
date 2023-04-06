using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompanyService
    {
        public List<CompanyModel> List();
        public CompanyModel Get(int id);
        public CompanyModel Update(int id, CompanyUpdateModel companyModel);
        public void Delete(int id);
        public CompanyModel Create(CompanyModel companyModel);
    }
}
