using MyFileItDirectAmbassador.MyFileItPEService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFileItDirectAmbassador.Controllers
{
    public class ReferralController : BaseController
    {
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        // GET: Referral
        public ActionResult Detail(string referralName)
        {
            ReferralDTO model;
            using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
            {
                model = svc.GetReferralByEmail(SERVICEUSER, SERVICEPASS, referralName).Referrals.First();
            }
            return View(model);
        }
    }
}