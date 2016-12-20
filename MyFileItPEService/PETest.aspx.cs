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
    }
}