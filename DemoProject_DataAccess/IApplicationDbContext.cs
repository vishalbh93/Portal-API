using DemoProject_Model.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoProject_DataAccess
{
	public interface IApplicationDbContext
	{
		DbSet<DummyDatas> DummyDatas { get; set; }

	}
}
