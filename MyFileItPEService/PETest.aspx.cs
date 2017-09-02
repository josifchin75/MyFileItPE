using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFileItService.DTOs;
using MyFileItPEService.DTOs;

namespace MyFileItPEService
{
    public partial class PETest : System.Web.UI.Page
    {
        public string USERNAME = "admin";
        public string PASSWORD = "admin";

        public int AppUserId
        {
            get
            {
                var txt = (TextBox)Page.FindControl("txtAppUserId");
                return string.IsNullOrEmpty(txt.Text) ? -1 : int.Parse(txt.Text);
            }
        }

        public string NewDocumentType
        {
            get
            {
                var txt = (TextBox)Page.FindControl("txtDocumentType");
                return txt.Text;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var appUserDto = new MyFileItService.DTOs.AppUserDTO()
            {
                USERNAME = "josifchin75" + DateTime.Now.Second.ToString() + "@gmail.com",
                PASSWORD = "jopass12",
                EMAILADDRESS = "josifchin75@gmail.com",
                ADDRESS1 = "1",
                ADDRESS2 = "2",
                CITY = "Lansdale",
                STATECODE = "PA",
                ZIPCODE = "19446",
                SEX = "M",
                FIRSTNAME = "Jonathan",
                LASTNAME = "Osifchin"
            };
            var result = svc.AddAppUser(USERNAME, PASSWORD, appUserDto, null);
            lblError.Text = result.Success.ToString();
            var i = 0;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var txtuser = (TextBox)Page.FindControl("username");
            var txtpass = (TextBox)Page.FindControl("password");
            var result = svc.LoginAppUser(USERNAME, PASSWORD, txtuser.Text, txtpass.Text);
            lblError.Text = "Login: " + result.Success.ToString() + " Coach: " + result.AppUsers.First().IsCoach.ToString();
        }

        protected void btnGetAppUserDocuments_Click(object sender, EventArgs e)
        {
            var appUserId = 5;
            int? teamEventId = 2;
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.GetAppUserDocumentsListNoImages(USERNAME, PASSWORD, appUserId, teamEventId, null);
            lblError.Text = "Docs Found: " + result.Documents.Count.ToString();
        }

        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var associations = new List<AssociateDocumentDTO>();
            associations.Add(new AssociateDocumentDTO()
            {
                appUserId = 5,
                comment = "TESTING",
                emergency = false,
                fileCabinetDocumentId = 1,
                organizationId = 1,
                teamEventId = 2
            });
            var result = svc.AssociateDocumentsToTeamEventDocuments(USERNAME, PASSWORD, associations);
        }

        protected void btnAddDocumentType_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.AddDocumentType(USERNAME, PASSWORD, AppUserId, NewDocumentType);
            lblError.Text = result.Success.ToString();
        }

        protected void btnGetAllDocTypes_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.GetDocumentTypes(USERNAME, PASSWORD, AppUserId);
            result.DocumentTypes.ForEach(t =>
            {
                lblError.Text += t.NAME + "<br/>";
            });
        }

        protected void btnInitServices_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.InitService();
            lblError.Text = "RAN INIT: " + result.ToString();
        }

        protected void btnSendReminders_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.SendReminderEmails();
            lblError.Text = "RAN Send: " + result.ToString();
        }

        protected void GetReferrals_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.GetReferrals(USERNAME, PASSWORD);
            lblError.Text = "Referral Count: " + result.Referrals.Count().ToString();
        }

        protected void GetReferral_Click(object sender, EventArgs e)
        {

            var id = int.Parse(GetTextBox("txtReferralId").Text);
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.GetReferral(USERNAME, PASSWORD, id);
            lblError.Text = "Referral Count: " + result.Referrals.Count().ToString();
        }

        protected void AddReferral_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var referral = CreateReferralDto();
            var result = svc.AddReferral(USERNAME, PASSWORD, referral);
            lblError.Text = "Referral Count: " + result.Referrals.Count().ToString();
        }

        private ReferralDTO CreateReferralDto()
        {
            return new ReferralDTO()
             {
                 FIRSTNAME = "F",
                 LASTNAME = "L",
                 ADDRESS1 = "A1",
                 ADDRESS2 = "A2",
                 MOBILEPHONE = "1111",
                 EMAILADDRESS = DateTime.Now.Ticks.ToString(),
                 PASSWORD = "PPP",
                 REFERRALCODE = "RRRR",
                 STATECODE = "PA",
                 ZIPCODE = "18914",
                 CITY = "LANSDALE",
                 CHECKINGACCOUNTNUMBER = "CCC",
                 DISCOUNTAMOUNT = decimal.Parse("0.25"),
                 IMAGENAME = "IMAGE",
                 ROUTINGNUMBER = "RRR"
             };
        }

        protected void UpdateReferral_Click(object sender, EventArgs e)
        {
            var id = int.Parse(GetTextBox("txtReferralId").Text);

            var svc = new MyFileItPEService.MyFileItPEMainService();
            var referral = svc.GetReferral(USERNAME, PASSWORD, id).Referrals.First();
            referral.EMAILADDRESS += " -U";
            var result = svc.UpdateReferral(USERNAME, PASSWORD, referral);
            lblError.Text = "Referral Count: " + result.Referrals.Count().ToString();
        }

        protected void LoginReferral_Click(object sender, EventArgs e)
        {
            var id = int.Parse(GetTextBox("txtReferralId").Text);
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var referral = svc.GetReferral(USERNAME, PASSWORD, id).Referrals.First();
            var result = svc.LoginReferral(USERNAME, PASSWORD, referral.EMAILADDRESS, referral.PASSWORD);
            lblError.Text = "Referral Login: " + result.Success.ToString();
        }

        protected void CheckReferralCode_Click(object sender, EventArgs e)
        {
            var code = GetTextBox("txtReferralCode").Text;
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.CheckReferralCode(USERNAME, PASSWORD, code);
            lblError.Text = "Is Referral Code: " + result.Success.ToString();
        }

        protected void AddReferralTransaction_Click(object sender, EventArgs e)
        {
            var referralTransaction = new ReferralTransactionDTO()
            {
                REFERRALID = 1,
                COMMISSIONAMOUNT = decimal.Parse("0.25"),
                COMMISSIONPAID = "0",
                SHAREKEYID = 2
            };
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.AddReferralTransaction(USERNAME, PASSWORD, referralTransaction);
            lblError.Text = "Referral Transaction added: " + result.Success.ToString();
        }

        protected void PayReferralTransaction_Click(object sender, EventArgs e)
        {
            var svc = new MyFileItPEService.MyFileItPEMainService();
            var result = svc.UpdateReferralCommissionPaid(USERNAME, PASSWORD, 1);
            lblError.Text = "Referral Transaction Paid: " + result.Success.ToString();
        }

        private TextBox GetTextBox(string id)
        {
            return (TextBox)Page.FindControl(id);
        }



    }
}