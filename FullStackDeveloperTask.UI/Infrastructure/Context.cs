using FulStackDeveloperTask.App.Utils;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackDeveloperTask.UI.Infrastructure
{
    public class Context
    {
        private static Context _instance;
        private static object lockObj = new object();
        private static readonly ILog _logger = Log4NetManager.GetLogger("UILogger");


        public static ILog Logger
        {
            get { return _logger; }
        }
        /// <summary>
        /// Signleton ile InterContext nesnesi getirilir
        /// </summary>
        public static Context Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObj)
                    {
                        if (_instance == null)
                            _instance = new Context();
                    }
                }

                return _instance;
            }
        }

    }
}