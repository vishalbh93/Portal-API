using DemoProject_Model;
using DemoProject_Model.Model;
using DemoProject_Service.IService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject_WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DataController : Controller
	{
		#region Public Variables
		private readonly IDataService _dataservice;
		#endregion

		#region Constructor
		public DataController(IDataService dataservice)
		{
			_dataservice = dataservice;
		}
		#endregion

		#region Public Methods
		[HttpGet("get-result")]
		public ActionResult GetResult()
		{
			var result = _dataservice.GetData();
			return Ok(result);
		}

		[HttpPut("put-result")]
		public ActionResult CreateData([FromBody] RequestModel data)
		{
			var result = _dataservice.SaveOrUpdateData(data);
			return Ok(result);
		}

		[HttpPost("post-result")]
		public IActionResult UpdateData([FromBody] RequestModel data) {
			var result = _dataservice.SaveOrUpdateData(data);
			return Ok(result);
		}
		[HttpDelete("delete-result")]
		public IActionResult DeleteData(string id)
		{
			var result = _dataservice.DeleteData(new Guid(id));
			return Ok(result);
		}
		#endregion
	}
}
