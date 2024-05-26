using DemoProject_DataAccess;
using DemoProject_DataAccess.Data;
using DemoProject_Service.Data_Service;
using DemoProject_Service.IService;
using Microsoft.EntityFrameworkCore;

namespace DemoProject_WebAPI
{
	public class RegisterService
	{
		#region Public Methods
		public static void RegisterComponent(IServiceCollection services, IConfiguration configuration)
		{
			RegisterDataService(services, configuration);
		}
		#endregion

		#region Private Methods
		private static void RegisterDataService(IServiceCollection services, IConfiguration configuration)
		{
            //services.AddScoped<IDataService>(s =>new DataService());
            services.AddScoped<IDataService>(s => new DataService(configuration));
        }
		#endregion
	}
}
