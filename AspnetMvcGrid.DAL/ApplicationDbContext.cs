using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using AutoMapper;

using AspnetMvcGrid.Interfaces.DTO;
using AspnetMvcGrid.Interfaces;


namespace AspnetMvcGrid.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserIdentity>
        , IAppDbContext
    {
        static readonly MapperConfiguration config;
        static readonly IMapper mapper;

        static ApplicationDbContext()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Asset, AssetDto>()
                    .ForMember(d => d.BarCode, op => op.ResolveUsing(ctx =>
                    {
                        {
                            var ls = ctx;
                            return ls.Barcode;
                        }
                    }));


                cfg.IgnoreUnmapped();
            });
            config.AssertConfigurationIsValid();
            mapper = config.CreateMapper();

        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Asset> Assets { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public int GetTotalCount()
        {
            IQueryable<Asset> query = this.Assets;
            var totalCount = query.Count();
            return totalCount;
        }

        public QueryResult GetResults(string filterByValue, int start, int length, Dictionary<string , string > orderBy)
        {
            IQueryable<Asset> query = this.Assets;
            var totalCount = query.Count();

            #region Filtering
            // Apply filters for searching
            if (filterByValue != string.Empty)
            {
                var value = filterByValue.Trim();

                query = query.Where(p => p.Barcode.Contains(value) ||
                                         p.Manufacturer.Contains(value) ||
                                         p.ModelNumber.Contains(value) ||
                                         p.Building.Contains(value)
                                   );
            }

            var filteredCount = query.Count();

            #endregion Filtering

            #region Sorting
            // Sorting
            var orderByString = String.Empty;

            foreach (var column in orderBy)
            {
                orderByString += orderByString != String.Empty ? "," : "";
                orderByString += (column.Key) + (column.Value == "Ascendant" ? " asc" : " desc");
            }

            query = query.OrderBy(orderByString == string.Empty ? "BarCode asc" : orderByString);

            #endregion Sorting

            // Paging
            var query2 = query.Skip( start).Take(length);

            var tmp2 = mapper.Map<List< AssetDto>>(query2.Select(x => x).ToList());

            var queryResult = new QueryResult(tmp2,  query.Count(), totalCount );
            return queryResult;
        }
    }
}