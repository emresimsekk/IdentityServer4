using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyIdentityServer.Api2.Model;

namespace UdemyIdentityServer.Api2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetPicture()
        {
            var pictureList = new List<Picture>()
            {
                new Picture{ Id=1,Name="Kale",Url=" yol 1"},
                new Picture{ Id=2,Name="sİLGİ",Url=" yol 2"},
                new Picture{ Id=3,Name="Uç",Url=" yol 3"},
                new Picture{ Id=4,Name="Defter",Url=" yol 4"}
            };

            return Ok(pictureList);
        }

    }
}
