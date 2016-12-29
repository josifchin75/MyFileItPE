using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFileItService.DTOs;

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
                USERNAME = "josifchin75@gmail.com",
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
            var result = svc.AddDocumentType(USERNAME, PASSWORD, AppUserId,NewDocumentType);
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

    }
}