using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Configuration;

namespace MyFileItDirectAmbassador
{
    public class BaseController : Controller
    {
        public string SERVICEUSER
        {
            get
            {
                return ConfigurationManager.AppSettings["ServiceUser"];
            }
        }
        public string SERVICEPASS = ConfigurationManager.AppSettings["ServicePass"];
    }
}
