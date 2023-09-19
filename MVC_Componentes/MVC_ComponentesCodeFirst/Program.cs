using MVC_ComponentesCodeFirst.Services;

namespace MVC_ComponentesCodeFirst
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddScoped<IComponenteRepositorio, EFRepositoryComponentes>();
            builder.Services.AddScoped<IPedidoRepositorio, EFRepositoryPedidos>();
            builder.Services.AddScoped<IRepositorioOrdenador, EFRepositorioOrdenador>();
            builder.Services.AddScoped<IConfiguracionMVC, ConfiguracionMvc>();


            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Componentes}/{action=Index}/{id?}");

            app.Run();
        }
    }
}