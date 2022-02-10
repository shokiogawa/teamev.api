using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using teamev.api.presentation.dto;
using Microsoft.AspNetCore.Authorization;
using teamev.api.presentation.firebase;
using teamev.api.usecase.command;
using teamev.api.domain.entity;
namespace teamev.api.Controllers
{
  public class Header
  {
    [FromHeader]
    public string Authorization { get; set; }

  }

  [ApiController]
  [Route("teams/{teamId}/objectives")]
  public class ObjectiveController : ControllerBase
  {
    public ObjectiveController(FirebaseInitApp firebaseInitApp, CreateObjectiveUsecase createObjectiveUsecase)
    {
      this.firebaseMethod = firebaseInitApp;
      this.createObjectiveUsecase = createObjectiveUsecase;
    }
    private readonly FirebaseInitApp firebaseMethod;
    private readonly CreateObjectiveUsecase createObjectiveUsecase;

    // [Authorize]
    [HttpGet]
    [ActionName(nameof(GetObjectivesAsync))]
    public void GetObjectivesAsync(string teamId, [FromHeader] Header header)
    {
      Console.WriteLine(teamId);
      string idToken = header.Authorization.Remove(0, 7);
      //firebaseのuidを取得
      string userUid = firebaseMethod.GetValifyUserUid(idToken);
      Console.WriteLine(userUid);
    }

    [HttpGet("{id}")]
    public void GetObjectivesAsync(Guid id)
    {
      Console.WriteLine(id);
    }

    // [Authorize]
    [HttpPost]
    //json形式のデータを受け取る際は、json形式に合わせたclassお作成する。
    public async Task<ActionResult> CreateTeamObjectiveAsync(Guid teamId, [FromBody] ObjectiveDto value, [FromHeader] Header header)
    {
      Console.WriteLine("コントローラー");
      string idToken = header.Authorization.Remove(0, 7);
      string userUid = firebaseMethod.GetValifyUserUid(idToken);
      var publicObjectiveId = await createObjectiveUsecase.InvokeAsync(teamId, value.Title, value.Content, value.Author, userUid);
      return CreatedAtAction(nameof(GetObjectivesAsync), new { teamId = teamId }, new { publicObjectiveId = publicObjectiveId });
    }

    [HttpPut("{id}")]
    public void EditObjective(Guid id, [FromBody] ObjectiveDto value)
    {
      Console.WriteLine(id);
      Console.WriteLine(value);
    }
  }
}