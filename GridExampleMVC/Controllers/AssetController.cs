using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.Owin;
using DataTables.Mvc;

using GridExampleMVC.DAL;



namespace GridExampleMVC.Controllers
{
    public class AssetController : Controller
    {

        private ApplicationDbContext _dbContext;

        private ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            set
            {
                _dbContext = value;
            }

        }

        public AssetController()
        {

        }

        public AssetController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var totalCount = DbContext.GetTotalCount();

            var orderBy = new Dictionary<string, string>();
            var sortedColumns = requestModel.Columns.GetSortedColumns();

            foreach (var column in sortedColumns)
            {
                orderBy[column.Data] = column.SortDirection.ToString();
            }

            var query = DbContext.GetResults(requestModel.Search.Value, requestModel.Start, requestModel.Length, orderBy);



            var data = query.Select(asset => new
            {
                AssetID = asset.AssetID,
                BarCode = asset.Barcode,
                Manufacturer = asset.Manufacturer,
                ModelNumber = asset.ModelNumber,
                Building = asset.Building,
                RoomNo = asset.RoomNo,
                Quantity = asset.Quantity
            }).ToList();

            var filteredCount = data.Count;

            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount), JsonRequestBehavior.AllowGet);
        }

    }
}