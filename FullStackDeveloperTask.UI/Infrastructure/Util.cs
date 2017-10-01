using FulStackDeveloperTask.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackDeveloperTask.UI.Infrastructure
{
    public class Util
    {
        public static void TableSortByRequest(DataTableModel table, string sortColumn, string sortDirection)
        {
            table.SingleSortDirection = sortDirection;
            table.SingleSortingColumn = !string.IsNullOrEmpty(table.sColumns) ? table.sColumns.Split(',')[Convert.ToInt32(table.iSortCol_0)] : string.Empty;
        }
    }
}