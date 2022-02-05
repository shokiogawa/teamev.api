using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using teamev.api.presentation.dto;
using Microsoft.AspNetCore.Authorization;
using teamev.api.presentation.firebase;
namespace teamev.api.Controllers
{
  [ApiController]
  [Route("objective")]
  public class ObjectiveController : ControllerBase
  {
    private readonly FirebaseInitApp firebaseMethod;
    public ObjectiveController(FirebaseInitApp firebaseInitApp)
    {
      this.firebaseMethod = firebaseInitApp;
    }
    [Authorize]
    [HttpGet]
    public void GetObjective([FromHeader] string token)
    {
      Console.WriteLine("やあ");
      // string userUid = firebaseMethod.GetValifyUserUid(token);
    }

    [HttpGet("{id}")]
    public void GetObjective(Guid id)
    {
      Console.WriteLine(id);
    }

    [HttpPost]
    //json形式のデータを受け取る際は、json形式に合わせたclassお作成する。
    public void CreateObjective([FromBody] ObjectiveDto value)
    {
      Console.WriteLine(value.Title);
    }

    [HttpPut("{id}")]
    public void EditObjective(Guid id, [FromBody] ObjectiveDto value)
    {
      Console.WriteLine(id);
      Console.WriteLine(value);
    }
  }
}