using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class LectorController : ControllerBase
        {
            private readonly ILectorService _lectorService;
        private readonly ILogger<LectorController> _logger;
            public LectorController(ILectorService lectorService,ILogger<LectorController> logger)
            {
                _lectorService = lectorService;
                _logger = logger;
            }

            [Authorize]
            [HttpGet]
    
            public  IActionResult GetAll()
            {
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
            var phoneNumber = User.FindFirst(ClaimTypes.MobilePhone)?.Value;

            var isAdminClaim = User.FindFirst("isAdmin")?.Value;
            var isAdmin = isAdminClaim != null && bool.Parse(isAdminClaim);
            var roles = User.Claims
           .Where(c => c.Type == ClaimTypes.Role)
           .Select(c => c.Value)
           .ToList();


            return Ok(new { roles, userEmail,isAdmin, phoneNumber});
            }

           [HttpGet("{id}")]
        [AllowAnonymous]
            public async Task<Lector?> GetById(int id)
            {
                return await _lectorService.GetById(id);
            }


            [HttpPost]
            public async Task<bool> CreateLector(LectorAddDto model)
            {
                return await _lectorService.CreateLector(model);
            }

            [HttpPut]
            public async Task<bool> UpdateLector(int id, LectorAddDto model)
            {
                return await _lectorService.UpdateLector(id, model);
            }


           [HttpDelete]
            public async Task<bool> DeleteLector(int Id)
            {
                return await _lectorService.DeleteLector(Id);
            }


         [HttpGet]
          public async Task<float?> GetMaxGrade(int lectorId)
          {
              return await _lectorService.GetMaxGrade(lectorId);
          }

       [HttpGet]
        public async Task<float?> GetMinGrade(int lectorId)
        {
            return await _lectorService.GetMinGrade(lectorId);
        }

        [HttpGet]
        public async Task<float?> GetAvgGrade(int lectorId)
        {
            return await _lectorService.GetAvgGrade(lectorId);
        }

         [HttpGet]
        public async Task<Dictionary<string, int>?> GroupAndCountStudentsByNameForLector(int lectorId)
        {
            return await _lectorService.GroupAndCountStudentsByNameForLector(lectorId);
        }
    }
}
