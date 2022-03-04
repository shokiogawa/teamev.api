using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using teamev.api.presentation.firebase;
using teamev.api.usecase.command;
using teamev.api.domain.entity;
using teamev.api.utility;
using teamev.api.presentation.BodyStruct;
namespace teamev.api.Controllers
{


  [ApiController]
  [Route("teams/{teamId}/objectives")]
  public class ObjectiveController : ControllerBase
  {
    public ObjectiveController(
      // FirebaseInitApp firebaseInitApp, CreateObjectiveUsecase createObjectiveUsecase
      )
    {
      // this.firebaseMethod = firebaseInitApp;
      // this.createObjectiveUsecase = createObjectiveUsecase;
    }
    // private readonly FirebaseInitApp firebaseMethod;
    // private readonly CreateObjectiveUsecase createObjectiveUsecase;

    // [Authorize]
    [HttpGet]
    [ActionName(nameof(GetObjectivesAsync))]
    public async Task GetObjectivesAsync(string teamId, [FromHeader] Header header)
    {
      // string idToken = header.Authorization.Remove(0, 7);
      // //firebaseのuidを取得
      // string userUid = await firebaseMethod.GetValifyUserUid(idToken);
    }

    // [HttpGet("{id}")]
    // public void GetObjectivesAsync(Guid id)
    // {
    //   Console.WriteLine(id);
    // }

    // [Authorize]
    // [HttpPost]
    // //json形式のデータを受け取る際は、json形式に合わせたclassお作成する。
    // public async Task<ActionResult> CreateTeamObjectiveAsync(Guid teamId, [FromBody] ObjectiveBody value, [FromHeader] Header header)
    // {
    //   string idToken = header.getToken();
    //   string userUid = await firebaseMethod.GetValifyUserUid(idToken);
    //   var publicObjectiveId = await createObjectiveUsecase.InvokeAsync(teamId, value.Title, value.Content, value.Author, userUid);
    //   return CreatedAtAction(nameof(GetObjectivesAsync), new { teamId = teamId }, new { publicObjectiveId = publicObjectiveId });
    // }

    // [HttpPut("{id}")]
    // public void EditObjective(Guid id, [FromBody] ObjectiveBody value)
    // {
    //   Console.WriteLine(id);
    //   Console.WriteLine(value);
    // }
  }
}