using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetMvcGrid.Interfaces
{
    public interface IAppDbContext
    {
        int GetTotalCount();
        QueryResult GetResults(string filterByValue, int start, int length, Dictionary<string, string> orderBy);

    }
}
