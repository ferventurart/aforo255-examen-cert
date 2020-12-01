using AFORO255.MS.TEST.Security.DTO;
using AFORO255.MS.TEST.Security.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MS.AFORO255.Cross.Jwt.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccessService _accessService;
        private readonly JwtOptions _jwtOption;
        public AuthController(IAccessService accessService, IOptionsSnapshot<JwtOptions> jwtOption)
        {
            _accessService = accessService;
            _jwtOption = jwtOption.Value;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            if (!_accessService.Validate(request.UserName, request.Password))
            {
                return Unauthorized();
            }

            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", JwtToken.Create(_jwtOption));

            return Ok();
        }
    }
}
