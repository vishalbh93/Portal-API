using DemoProject_Model.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoProject_DataAccess.Data
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		private readonly string _connectionString;
		public ApplicationDbContext()
		{
		}
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public ApplicationDbContext(string connectionString)
		{
			this._connectionString = connectionString;
		}
		public virtual DbSet<DummyDatas> DummyDatas { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
			//optionsBuilder.UseSqlServer("Server=tcp:sqlserver2019.database.windows.net,1433;Database=sqlclient;Persist Security Info=False;User ID=vishal;Password=Password@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
		}
    }
}
