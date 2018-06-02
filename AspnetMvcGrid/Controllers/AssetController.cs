using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.Owin;
using DataTables.Mvc;

using AspnetMvcGrid.Interfaces;



namespace AspnetMvcGrid.Controllers
{
    [Authorize]
    public class AssetController : Controller
    {

        private IAppDbContext _dbContext;


        public AssetController()
        {

        }

        public AssetController(IAppDbContext dbContext)
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
            var totalCount = _dbContext.GetTotalCount();

            var orderBy = new Dictionary<string, string>();
            var sortedColumns = requestModel.Columns.GetSortedColumns();

            foreach (var column in sortedColumns)
            {
                orderBy[column.Data] = column.SortDirection.ToString();
            }

            var queryResult = _dbContext.GetResults(requestModel.Search.Value, requestModel.Start, requestModel.Length, orderBy);

            return Json(new DataTablesResponse(requestModel.Draw, queryResult.Data, queryResult.FilteredCount, queryResult.TotalCount), JsonRequestBehavior.AllowGet);
        }
    }
}