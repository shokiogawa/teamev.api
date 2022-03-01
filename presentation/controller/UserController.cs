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
  [Route("signin")]
  public class UserController : ControllerBase
  {
    public UserController(FirebaseInitApp _firebaseInitApp)
    {
      this._firebaseMethod = _firebaseInitApp;
      // this._createUserUsecase = _createUserUsecase;
    }
    private readonly FirebaseInitApp _firebaseMethod;
    // private readonly CreateUserUsecase _createUserUsecase;

    [HttpGet]
    public async Task GetUser()
    {
      Console.WriteLine("userデータ取得");
    }

    [HttpPost]
    public async Task<ActionResult> CreateUserAsync([FromHeader] Header header, [FromBody] UserBody userBody)
    {
      string idToken = header.getToken();
      string userUid = await _firebaseMethod.GetValifyUserUid(idToken);
      // Guid publicUserId = await _createUserUsecase.InvokeAsync(userUid, userBody.name, userBody.email);
      //修正箇所
      return CreatedAtAction(nameof(GetUser), new { publicUserId = "成功だよ" });
    }
  }
}