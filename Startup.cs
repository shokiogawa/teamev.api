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
      services.AddDbContext<UserContext>(options =>
      {
        options.UseMySQL("server=localhost;database=mysql;user=user;password=secret");
      });
      //mysqlの接続かつ1つのインスタンスを作成。
      // services.AddSingleton<MysqlDb>();
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "teamev.api", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "teamev.api v1"));
        Console.WriteLine("Develop");
      }
      //httpをhttpsにリダイレクトさせるもの。
      //   app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
