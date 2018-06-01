using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AspnetMvcGrid.Interfaces.DTO;



namespace AspnetMvcGrid.Interfaces
{
    public class QueryResult
    {
        public List<AssetDto> Data { get; private set; }
        public int FilteredCount { get; private set; }
        public int TotalCount { get; private set; }

        public QueryResult(List<AssetDto> data, int filteredCount, int totalCount)
        {
            Data = data;
            FilteredCount = filteredCount;
            TotalCount = totalCount;
        }
    }
}