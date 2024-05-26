using DemoProject_DataAccess.Data;
using DemoProject_Model;
using DemoProject_Model.Model;
using DemoProject_Service.IService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DemoProject_Service.Data_Service
{
    public class DataService : IDataService
	{
        #region Private Variable
        private readonly string _connString;
		private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public DataService(IConfiguration configuration)
        {
			_configuration = configuration;
            _connString = _configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region Public Methods
		public virtual ApplicationDbContext CreateDbContext()
		{
			return new ApplicationDbContext(_connString);
		}
        public string GetData()
		{
			_ = new SaveReturn();
			SaveReturn? returnResult;
			try
			{
				dynamic result;
                using var _con = CreateDbContext();
				{
					_con.Database.EnsureCreated();
                    Console.WriteLine("Connection successful!");
                    result = _con.DummyDatas.ToList();
                }
				//var result = _con.DummyDatas.ToList();
				returnResult = new SaveReturn()
				{
					isError = false,
					returnResult = result,
					errorMessage = ""
				};

			}
			catch (Exception ex)
			{
				returnResult = new SaveReturn()
				{
					isError = true,
					errorMessage = ex.Message
				};
			}
			return JsonConvert.SerializeObject(returnResult);
		}
		public bool SaveOrUpdateData(RequestModel data)
		{
			try
			{
				var record = new DummyDatas();
				using (var con = CreateDbContext())
				{
					var dataId = con.DummyDatas.Where(Dummy => Dummy.Id.Equals(new Guid(data.Id))).Select(get => get.Id.ToString())?.FirstOrDefault()?? null;
					if (dataId is not null)
					{
						record = new DummyDatas()
						{
							Id = new Guid(dataId),
							Name = data.Name,
							Contact_No = data.Contact_No,
							Department_Name = data.Department_Name
						};
						con.DummyDatas.Update(record);
					}
					else
					{
						record = new DummyDatas()
						{
							Id = Guid.NewGuid(),
							Name = data.Name,
							Contact_No = data.Contact_No,
							Department_Name = data.Department_Name
						};
						con.DummyDatas.Add(record);
					}
					con.SaveChanges();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool DeleteData(Guid Id) 
		{
			try
			{
				using var _con = CreateDbContext();
				var record = _con.DummyDatas.FirstOrDefault(Dummy => Dummy.Id.Equals(Id))?? new DummyDatas();
				_con.DummyDatas.Remove(record);
				_con.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
		#endregion
	}
}
