using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace teamev.api.Controllers
{
  [ApiController]
  [Route("test")]
  public class TestController : ControllerBase
  {
    [HttpGet]
    public void GetTest()
    {
      Console.WriteLine("テスト");
    }
  }
}