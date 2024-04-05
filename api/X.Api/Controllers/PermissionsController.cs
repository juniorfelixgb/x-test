using Microsoft.AspNetCore.Mvc;
using X.Application.Permissions.Extensions;
using X.Application.Permissions.Requests;
using X.Domain.Shared.Interfaces;

namespace X.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.permissionService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.permissionService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody, Bind] CreatePermissionRequest request)
        {
            var result = await this.permissionService.Create(request.ToPermission());
            return CreatedAtAction(nameof(Get), new { id = result.Id });
        }
    }
}
