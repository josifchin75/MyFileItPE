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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReferralDTO referral)
        {
            var val = ModelState.IsValid;
            if (ValidReferral(referral))
            {
                using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
                {
                    var result = svc.AddReferral(SERVICEUSER, SERVICEPASS, referral);
                    if (result.Success)
                    {
                        var i = 0;
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Please enter all required fields.");
            }
            return View(referral);
        }

        private bool ValidReferral(ReferralDTO referral)
        {
            var result = true;

            if (IsEmpty(referral.EMAILADDRESS))
            {
                result = false;
            }
            if (IsEmpty(referral.FIRSTNAME))
            {
                result = false;
            }
            if (IsEmpty(referral.LASTNAME))
            {
                result = false;
            }
            if (IsEmpty(referral.ADDRESS1))
            {
                result = false;
            }
            if (IsEmpty(referral.CITY))
            {
                result = false;
            }
            if (IsEmpty(referral.STATECODE))
            {
                result = false;
            }
            if (IsEmpty(referral.ZIPCODE))
            {
                result = false;
            }
            if (IsEmpty(referral.MOBILEPHONE))
            {
                result = false;
            }

            return result;
        }

        private bool IsEmpty(string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

    }
}