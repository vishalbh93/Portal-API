using DemoProject_Model.Model;

namespace DemoProject_Model
{
	public class SaveReturn
	{
		public bool isError { get; set; }
		public string errorMessage { get; set; }
		public List<DummyDatas> returnResult { get; set; }
	}
}