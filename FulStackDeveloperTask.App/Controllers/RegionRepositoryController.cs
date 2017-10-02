using FulStackDeveloperTask.App.Models;
using FulStackDeveloperTask.App.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FulStackDeveloperTask.App.Controllers
{
    public class RegionRepositoryController : ApiController
    {
        public List<Region> GetAll()
        {
            using (RegionOperation operation = new RegionOperation())
            {
                return operation.GetAllEntities();
            }
        }
    }
}