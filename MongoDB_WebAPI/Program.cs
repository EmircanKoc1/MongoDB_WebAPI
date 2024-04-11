using Core.Models.SettingModels;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concretes;
using Microsoft.Extensions.Options;

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


            builder.Services.AddScoped<IUserMongoRepository,UserMongoRepository>();
            builder.Services.AddScoped<IProductMongoRepository,ProductMongoRepository>();
            //builder.Services.AddScoped<>


            builder.Services.Configure<Core.Models.SettingModels.MongoDB>(builder.Configuration.GetSection("MongoDB")); 

           

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
