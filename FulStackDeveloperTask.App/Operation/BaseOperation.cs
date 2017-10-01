using FullStackDeveloperTask.App.ViewModel;
using FulStackDeveloperTask.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Operation
{
    public class BaseOperation
    {
        public virtual ExecuteResult Save<T>(T model) where T : BaseModel {
            return null;
        }
        public virtual ExecuteResult Update<T>(T model) where T : BaseModel
        {
            return null;
        }
        public virtual ExecuteResult Delete<T>(T model) where T : BaseModel
        {
            return null;
        }

    }
}