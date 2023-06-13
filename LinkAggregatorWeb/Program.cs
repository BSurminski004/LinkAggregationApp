using LinkAggregator.DataAccess.DBContext;
using LinkAggregator.DataAccess.Repository;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LinkAggregatorWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("LinkAggregation")
                )); ;

            builder.Services.AddScoped<IHyperLinkRepository, HyperLinkRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


           //Dodac serwis do obslugi http
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.Run();
        }
    }
}