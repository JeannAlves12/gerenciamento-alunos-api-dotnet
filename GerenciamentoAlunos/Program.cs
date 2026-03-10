using GerenciamentoAlunos.Data.Contexts;
using GerenciamentoAlunos.Data.Repositories;
using GerenciamentoAlunos.Domain.Interfaces.IRepositories;
using GerenciamentoAlunos.Domain.Interfaces.IServices;
using GerenciamentoAlunos.Domain.Services;

namespace GerenciamentoAlunos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<DataContext>();

            builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

            builder.Services.AddScoped<IAlunoService, AlunoServices>();

            builder.Services.AddScoped<ICursoRepository, CursoRepository>();

            builder.Services.AddScoped<ICursoService, CursoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");
            
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
