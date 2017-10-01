using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackDeveloperTask.App.ViewModel
{
    public class UIModel
    {
        public OperationType OperationType { get; set; }
    }

    public enum OperationType {
        Save,
        Update,
        Delete
    }
}