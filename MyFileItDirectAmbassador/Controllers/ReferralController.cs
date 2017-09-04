using MyFileItDirectAmbassador.Helpers;
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
            List<ReferralDTO> model;
            using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
            {
                model = svc.GetReferrals(SERVICEUSER, SERVICEPASS).Referrals.OrderBy(r => r.EMAILADDRESS).ToList();
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        /*******************************
         * CREATE
         * *****************************/
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
                        return RedirectToAction("CreateSuccess", new { referralName = referral.EMAILADDRESS });
                    }
                    else
                    {
                        ModelState.AddModelError("", result.Message);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Please enter all required fields.");
            }
            return View(referral);
        }

        public ActionResult CreateSuccess(string referralName)
        {
            ReferralDTO model;
            using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
            {
                model = svc.GetReferralByEmail(SERVICEUSER, SERVICEPASS, referralName).Referrals.First();
            }
            return View(model);
        }


        /*******************************
         * DETAIL
         * *****************************/
        [Authorize]
        // GET: Referral
        public ActionResult Detail(string referralName)
        {
            ReferralDTO model;
            using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
            {
                model = svc.GetReferralByEmail(SERVICEUSER, SERVICEPASS, referralName).Referrals.First();
                DecryptNumbers(model);
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        // GET: Referral
        public ActionResult Detail(ReferralDTO referral)
        {
            if (ValidReferral(referral))
            {
                using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
                {
                    EncryptNumbers(referral);
                    var result = svc.UpdateReferral(SERVICEUSER, SERVICEPASS, referral);
                    if (result.Success)
                    {
                        ViewMessage = "Your account has been updated.";
                    }
                    DecryptNumbers(referral);
                }
            }

            return View(referral);
        }

       


        /*******************************
         * ADMIN DETAIL
         * *****************************/
        [Authorize(Roles = "admin")]
        public ActionResult AdminDetail(int referralId)
        {
            ReferralDTO model;
            using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
            {
                model = svc.GetReferral(SERVICEUSER, SERVICEPASS, referralId).Referrals.First();
                DecryptNumbers(model);
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        // GET: Referral
        public ActionResult AdminDetail(ReferralDTO referral)
        {
            if (ValidReferral(referral))
            {
                using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
                {
                    EncryptNumbers(referral);
                    var result = svc.UpdateReferral(SERVICEUSER, SERVICEPASS, referral);
                    if (result.Success)
                    {
                        ViewMessage = "This account has been updated.";
                    }
                    DecryptNumbers(referral);
                }
            }

            return View(referral);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddTransaction(string referralName)
        {
            ReferralDTO model;
            using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
            {
                model = svc.GetReferralByEmail(SERVICEUSER, SERVICEPASS, referralName).Referrals.First();
                var organizationId = svc.GetOrganizations(SERVICEUSER, SERVICEPASS,null, null).Organizations.First().ID;
                var appUserId = svc.GetAllAppUsers(SERVICEUSER, SERVICEPASS,organizationId).AppUsers.First().ID;
                var salesRepId = svc.GetSalesReps(SERVICEUSER, SERVICEPASS, null, "", null).SalesReps.First().ID;
                svc.AddShareKeyOrganization(SERVICEUSER, SERVICEPASS, appUserId, organizationId, DateTime.Now, model.REFERRALCODE, "1111", 4m, salesRepId, 1, null, null);

                model = svc.GetReferralByEmail(SERVICEUSER, SERVICEPASS, referralName).Referrals.First();

            }
            return View("~/Views/Referral/AdminDetail.cshtml", model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult MarkCommissionPaid(string referralName, int referralTransactionId)
        {
            ReferralDTO model;
            using (var svc = new MyFileItPEService.MyFileItPEMainServiceClient())
            {
                model = svc.GetReferralByEmail(SERVICEUSER, SERVICEPASS, referralName).Referrals.First();
                var result = svc.UpdateReferralCommissionPaid(SERVICEUSER, SERVICEPASS, referralTransactionId);
                if (result.Success)
                {
                    ViewMessage = "Commission marked as paid.";
                    model = svc.GetReferralByEmail(SERVICEUSER, SERVICEPASS, referralName).Referrals.First();
                }
            }
            return View("~/Views/Referral/AdminDetail.cshtml", model);
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

        private void DecryptNumbers(ReferralDTO referral)
        {
            referral.CHECKINGACCOUNTNUMBER = EncryptionHelper.Decrypt(referral.CHECKINGACCOUNTNUMBER, ENCRYPTIONPASS);
            referral.ROUTINGNUMBER = EncryptionHelper.Decrypt(referral.ROUTINGNUMBER, ENCRYPTIONPASS);
        }

        private void EncryptNumbers(ReferralDTO referral)
        {
            referral.CHECKINGACCOUNTNUMBER = EncryptionHelper.Encrypt(referral.CHECKINGACCOUNTNUMBER, ENCRYPTIONPASS);
            referral.ROUTINGNUMBER = EncryptionHelper.Encrypt(referral.ROUTINGNUMBER, ENCRYPTIONPASS);    
        }

    }
}