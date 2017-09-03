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
        public BaseController()
        {
            SetViewBag();
        }

        private void SetViewBag()
        {
            //ViewBag.Message = ViewMessage;
        }

        public string SERVICEUSER
        {
            get
            {
                return ConfigurationManager.AppSettings["ServiceUser"];
            }
        }
        public string SERVICEPASS
        {
            get
            {
                return ConfigurationManager.AppSettings["ServicePass"];
            }
        }

        public string ViewMessage
        {
            get
            {
                return ViewBag.Message;
            }
            set
            {
                ViewBag.Message = value;
            }
        }
    }
}
