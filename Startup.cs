using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using teamev.api.infrastructure.db;
using teamev.api.infrastructure.db.db_context;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using teamev.api.presentation.firebase;
using teamev.api.usecase.command;
using teamev.api.infrastructure.repository_imp;
using teamev.api.domain.repository_interface;
using teamev.api.domain.domain_service_interface;
using teamev.api.infrastructure.domain_service_imp;
using teamev.api.usecase.query.query_service_interface;
using teamev.api.infrastructure.query_service;
using teamev.api.utility;
namespace teamev.api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    //COnfigureServicesはDIを定義するためのメソッド
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(o => o.AddDefaultPolicy(builder =>
     {
       builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
     }));
      services.AddDbContext<MyAppContext>(options =>
      {
        options.UseMySQL(Configuration["MYSQL_DSN"]);
      });
      //firebase認証
      services.AddSingleton<FirebaseInitApp>();
      //mysqlの接続かつ1つのインスタンスを作成
      services.AddSingleton<MysqlDb>(_ => new MysqlDb(Configuration["MYSQL_DSN"]));
      services.AddSingleton<FirebaseJson>(_ => new FirebaseJson(Configuration["FIREBASE_TYPE"], Configuration["FIREBASE_PROJECT_ID"], Configuration["FIREBASE_PRIVATE_KEY_ID"], createApiKey(), Configuration["FIREBASE_CLIENT_EMAIL"], Configuration["FIREBASE_CLIENT_ID"], Configuration["FIREBASE_AUTH_URI"], Configuration["FIREBASE_TOKEN_URI"], Configuration["FIREBASE_AUTH_PROVIDER"], Configuration["FIREBASE_CLIENT"]));

      //ドメインサービス
      services.AddSingleton<IUserDomainService, UserDomainService>();
      services.AddSingleton<IObjectiveDomainService, ObjectiveDomainService>();

      //infrastructure
      services.AddSingleton<IObjectiveRepository, ObjectiveRepository>();
      services.AddSingleton<IUserRepository, UserRepository>();
      services.AddSingleton<ITeamRepository, TeamRepository>();

      services.AddSingleton<IListTeamQueryService, ListTeamQueryService>();

      //usecase(返り値がない)
      services.AddSingleton<CreateObjectiveUsecase>();
      services.AddSingleton<CreateUserUsecase>();
      services.AddSingleton<CreateTeamUsecase>();
      services.AddControllers();
      // services
      // .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      // .AddJwtBearer(options =>
      // {
      //   options.Authority = "https://securetoken.google.com/teamev-3d0e0";
      //   options.TokenValidationParameters = new TokenValidationParameters
      //   {
      //     ValidateIssuer = true,
      //     ValidIssuer = "https://securetoken.google.com/teamev-3d0e0",
      //     ValidateAudience = true,
      //     ValidAudience = "teamev-3d0e0",
      //     ValidateLifetime = true
      //   };
      // });
    }
    public string createApiKey()
    {
      string firebasApiKey = Configuration["FIREBASE_PRIVATE_KEY"];
      for (int num = 1; num <= 27; num++)
      {
        firebasApiKey += '\n' + Configuration["FIREBASE_PRIVATE_KEY" + num.ToString()];
      }
      Console.WriteLine(firebasApiKey);
      return firebasApiKey;
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        Console.WriteLine("Development");
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }
      if (env.IsStaging())
      {
        Console.WriteLine("Staging");
      }

      if (env.IsProduction())
      {
        Console.WriteLine("Production");

      }
      //httpをhttpsにリダイレクトさせるもの。
      //   app.UseHttpsRedirection();

      app.UseRouting();
      app.UseCors();

      // app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
