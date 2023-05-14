using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Authorize]
    public class VCompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        public VCompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public IActionResult Companies()
        {
            var companies = _companyService.List();
            return View("Companies",companies);
        }
        public IActionResult Company(int id)
        {
            var company = _companyService.Get(id);
            if (company.Employees.FirstOrDefault() != null)
            {
                return View( company);
            }
            return View("CompanyIsEmpty");
        }
        [HttpGet]
        public IActionResult UpdateCompany(int id)
        {
            var company = _companyService.Get(id);
            ViewBag.Company=company;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCompany(int id, CompanyUpdateModel companyModel)
        {
            if (ModelState.IsValid)
            {
                var company = _companyService.Update(id, companyModel);
                return View("UpdatedCompany");
            }
            return View(companyModel);
        }
        [HttpGet]
        public IActionResult DeleteCompany(int id) {
            var company = _companyService.Get(id);
            return View(company);
        }
        [HttpPost]
        public IActionResult DeleteCompany(int id, string s)
        {
            _companyService.Delete(id);
            return View("DeletedCompany");
        }
        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddCompany(CompanyModel companyModel)
        {
            if (ModelState.IsValid) {
            var company = _companyService.Create(companyModel);
            return Companies();
        } 
            return View(companyModel);
        }
    }
}
