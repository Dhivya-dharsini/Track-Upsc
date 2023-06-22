using TrackUPSC.Controllers;

namespace TrackUPSC
{
	public class Program
	{
		public static void Main(string[] args)
		{


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
			builder.Services.AddDistributedMemoryCache();
			builder.Services.AddHttpContextAccessor();
            builder.Services.AddRazorPages();
            builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(46);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});
			builder.Services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseExceptionHandler("/Home/Error");

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseSession();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();


        }
    }
}