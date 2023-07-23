using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace elk.serilog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var uri = builder.Configuration["ElasticSearch:Uri"];


            builder.Host.UseSerilog((ctx, service, lc) => lc
                    .ReadFrom.Configuration(ctx.Configuration)
                    .WriteTo.Console()
                    .WriteTo.Seq(builder.Configuration["Serilog:SeqUri"])
                    .WriteTo.Elasticsearch(
                        new ElasticsearchSinkOptions(new Uri(builder.Configuration["ElasticSearch:Uri"]))
                        {
                            IndexFormat = $"{builder.Configuration["ApplicationName"]}-log-{ctx.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.Now:yyyy-MM-dd}",
                            AutoRegisterTemplate= true,
                            NumberOfShards = 2,
                            NumberOfReplicas = 1
                        }
                        ));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
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