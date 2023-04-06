using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet("")]
        public ActionResult<List<CompanyModel>> List()
        {
            var companies = _companyService.List();

            return companies;
        }

        [HttpGet("{id:int}")]
        public ActionResult<CompanyModel> Get(int id)
        {
            var company = _companyService.Get(id);

            return company;
        }
        [HttpPost("{id:int}")]
        public ActionResult<CompanyModel> Update(int id, CompanyUpdateModel companyModel)
        {
            var company = _companyService.Update(id, companyModel);

            return company;
        }
        [HttpPost("")]
        public ActionResult<CompanyModel> Create([FromBody] CompanyModel companyModel)
        {
            var company = _companyService.Create(companyModel);

            return company;
        }
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _companyService.Delete(id);
        }
    }
}
