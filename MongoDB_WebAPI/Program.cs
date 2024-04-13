using BusinessLayer.ServiceRegistrations;
using DataAccessLayer.ServiceRegistrations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Presentation.API.CustomActionFilters;
using CMS = Core.Models.SettingModels;

namespace MongoDB_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          

            builder.Services.AddControllers();
           


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           

            builder.Services.RegisterRepositories();
            builder.Services.RegisterServices();

            builder.Services.Configure<CMS.MongoDB>(builder.Configuration.GetSection("MongoDB"));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<Presentation.API.CustomMiddlewares.ExceptionHandlerMiddleware>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
