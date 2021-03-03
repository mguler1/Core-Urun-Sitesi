using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace CoreAndFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(x => 
                {
                    x.LoginPath = "/Login/Index";
                });
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthenticationPolicyBuilder()
            //    .RequireAuthenticatedUser().
            //    Build();
            //    config.Filters.Add(AuthorizeFilter(policy));
            //});
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Category}/{action=Index}/{id?}");

            });
        }
    }
}
