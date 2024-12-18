using Hackathon2024.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hackathon2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly DataLayer _datalayer;
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger, DataLayer datalayer)
        {
            _logger = logger;
            _datalayer = datalayer;
        }

        [HttpGet("GetProfileTypeById/{id}")]
        public async Task<string?> GetProfileTypeById(string id)
        {
            return await _datalayer.GetProfileType(id);
        }
    }
}

