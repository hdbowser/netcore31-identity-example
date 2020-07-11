using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi1.Authorization;
using webapi1.Core;

namespace webapi.Controllers {
    [Route ("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SecrectController : ControllerBase {
        [HttpGet]
        [UserCan (Actions.SecrectAction)]
        public ActionResult<string> Get () {
            return "Usted ha accedido a un lugar prohibido";
        }
    }
}