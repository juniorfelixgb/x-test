using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.Domain.Shared.Interfaces;

namespace X.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        public PermissionTypesController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.permissionService.GetTypes();
            return Ok(result);
        }
    }
}
