using FulStackDeveloperTask.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackDeveloperTask.UI.Database.Repository
{
    public class RegionRepository : BaseRepository
    {
        /// <summary>
        /// Tüm kıta bilgilerini getirir
        /// </summary>
        /// <returns>Kıta listesi</returns>
        public List<Region> GetAll() {
            return base.GetAll<Region>();
        }
    }
}