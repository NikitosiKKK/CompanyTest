using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers { 

    [Route("api/[controller]")]
    [ApiController]

    public class DBController : Controller
    {
        private readonly IDBCreationService _dbCreationService;
        public DBController(IDBCreationService dbCreationService)
        {
            _dbCreationService = dbCreationService;
        }
        [HttpPut]
        public void CreationDB()
        {
            _dbCreationService.CompanyCreation();
            _dbCreationService.EmployeeCreation();
            _dbCreationService.UsersCreation();
        }
    }
}
