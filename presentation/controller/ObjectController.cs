using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace teamev.api.Controllers
{
  [ApiController]
  [Route("object")]
  public class TestController : ControllerBase
  {
    [HttpGet]
    public void GetObjects()
    {
      Console.WriteLine("テスト");
    }

    [HttpGet("{id}")]
    public void GetTodayObject()
    {
      Console.WriteLine("今日の目標を取得する。");
    }

    [HttpPost]
    public void CreateObject()
    {
      Console.WriteLine("目標作成");
    }
  }
}