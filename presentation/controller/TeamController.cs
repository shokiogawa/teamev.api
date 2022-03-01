using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using teamev.api.usecase.command;
using teamev.api.presentation.firebase;
using teamev.api.utility;
using teamev.api.presentation.BodyStruct;
using System.Linq;
using teamev.api.domain.entity;
using System.Collections.Generic;
using teamev.api.usecase.query.query_service_interface;
namespace teamev.api.presentation.controller
{
  [ApiController]
  [Route("teams")]
  public class TeamController : Controller
  {

    public TeamController(FirebaseInitApp _firebaseInitApp)
    {
      // this._createTeamUsecase = _createTeamUsecase;
      this._firebaseInitApp = _firebaseInitApp;
      // this._listTeamQueryService = _listTeamQueryService;

    }
    private readonly CreateTeamUsecase _createTeamUsecase;
    private readonly FirebaseInitApp _firebaseInitApp;
    private readonly IListTeamQueryService _listTeamQueryService;

    [HttpGet]
    public async Task<IEnumerable<Team>> GetTeams([FromHeader] Header header)
    {
      // var idToken = header.getToken();
      // string userUid = await _firebaseInitApp.GetValifyUserUid(idToken);
      // var teamList = await _listTeamQueryService.InvokeAsync(userUid);
      List<Team> teams = new List<Team>();
      teams.Add(new Team { Id = 1, PublicTeamId = Guid.NewGuid(), Name = "小川翔生", Number = 1 });
      return teams;
      // Console.WriteLine("自分が所属しているチームを取得");
      // return [];
    }

    // [HttpGet("{id}")]
    // public async Task GetTeamDetail([FromHeader] Header header)
    // {
    //   var idToken = header.getToken();
    //   string userUid = await _firebaseInitApp.GetValifyUserUid(idToken);
    //   //チームに所属している人。
    //   //今日のチーム目標
    //   //メンバーのチーム目標

    //   Console.WriteLine("チームの詳細情報を取得");
    // }

    // [HttpPost]
    // public async Task<ActionResult> CreateTeam([FromHeader] Header header, [FromBody] TeamBody teamBody)
    // {
    //   var idToken = header.getToken();
    //   string userUid = await _firebaseInitApp.GetValifyUserUid(idToken);
    //   var publicTeamId = await _createTeamUsecase.InvokeAsync(userUid, teamBody.name);
    //   return CreatedAtAction(nameof(GetTeams), new { public_team_id = publicTeamId });
    // }

  }
}