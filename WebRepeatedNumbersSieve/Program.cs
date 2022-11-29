using Microsoft.AspNetCore.Routing;
using WebRepeatedNumbersSieve.Models;
using WebRepeatedNumbersSieve.Models.ArrayParsers;
using WebRepeatedNumbersSieve.Models.ArraySerializers;
using WebRepeatedNumbersSieve.Models.ArrayTransformations;
using WebRepeatedNumbersSieve.Models.LiteralTransformationEngines;

namespace WebRepeatedNumbersSieve
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ILiteralTransformationEngine, ArrayLiteralTransformationEngine<int>>();
            builder.Services.AddSingleton<IArrayParser<int>, IntegerArrayParser>();
            builder.Services.AddSingleton<IArraySerializer<int>, IntegerArraySerializer>();
            builder.Services.AddSingleton(typeof(IArrayTransformation<int>),
                prov => ActivatorUtilities.CreateInstance(prov, typeof(RepeatedElementsSieve<int>), 3));
            builder.Services.AddScoped<IArrayTransformation<int>, DescendingArraySorter<int>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}