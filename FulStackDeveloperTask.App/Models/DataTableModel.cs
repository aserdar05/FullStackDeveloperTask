using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Models
{
    public class DataTableModel
    {
        public DataTableModel() { }

        public int iColumns { get; set; }
        public int iDisplayLength { get; set; }
        public int iDisplayStart { get; set; }
        public string iSortCol_0 { get; set; }
        public int iSortingCols { get; set; }
        public string sColumns { get; set; }
        public string sEcho { get; set; }
        public string SingleSortDirection { get; set; }
        public string SingleSortingColumn { get; set; }
        public string sSearch { get; set; }
        public string sSortDir_0 { get; set; }
    }
}