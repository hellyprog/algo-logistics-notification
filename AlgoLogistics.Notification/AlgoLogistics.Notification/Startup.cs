using AlgoLogistics.Notification.Messages;
using AlgoLogistics.Notification.Messages.Consumers;
using AlgoLogistics.Notification.Services;
using AlgoLogistics.Notification.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AlgoLogistics.Notification
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddOptions();
			services.Configure<RabbitMqConfiguration>(Configuration.GetSection("RabbitMq"));
			services.AddTransient<INotificationService, NotificationService>();
			services.AddHostedService<NotificationConsumer>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
