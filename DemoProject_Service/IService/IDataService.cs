using DemoProject_Model;
using DemoProject_Model.Model;

namespace DemoProject_Service.IService
{
	public interface IDataService
	{
		string GetData();
		bool SaveOrUpdateData(RequestModel data);
		bool DeleteData(Guid Id);
	}
}
