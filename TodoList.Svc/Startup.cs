using Microsoft.Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System.Configuration;
using System.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(TodoList.Svc.Startup))]

namespace TodoList.Svc
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseWindowsAzureActiveDirectoryBearerAuthentication(
				new WindowsAzureActiveDirectoryBearerAuthenticationOptions
				{
					Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
					TokenValidationParameters = new TokenValidationParameters
					{
						ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
					}
				});
		}
	}
}