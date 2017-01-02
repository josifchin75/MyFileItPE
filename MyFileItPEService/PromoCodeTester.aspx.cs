using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFileItPEService
{
    public partial class PromoCodeTester : System.Web.UI.Page
    {
        public string SERVICEUSER = "admin";
        public string SERVICEPASS = "admin";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                loadDrops();
            }
        }

        private void loadDrops()
        {
            ddlOrganization.Items.Clear();
            ddlOrganization.Items.Add(new ListItem("<No Organization>", "-1"));
            using (var db = new MyFileItDataLayer.Models.MyFileItEntities())
            {
                db.ORGANIZATIONs.ToList().ForEach(o =>
                {
                    var appUserObj = db.APPUSERORGANIZATIONs.Where(au => au.ORGANIZATIONID == o.ID).FirstOrDefault();
                    if (appUserObj != null)
                    {
                        ddlOrganization.Items.Add(new ListItem(o.NAME, appUserObj.APPUSERID.ToString()));
                    }
                });

                db.SALESREPs.ToList().ForEach(s =>
                {
                    ddlSalesRep.Items.Add(new ListItem(s.FIRSTNAME + " " + s.LASTNAME, s.ID.ToString()));
                });
            }
        }

        protected void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            if (validKey())
            {
                var svc = new MyFileItPEMainService();
                var primaryAppUserId = int.Parse(ddlOrganization.SelectedValue);
                var salesRepId = int.Parse(ddlSalesRep.SelectedValue);
                var purchaseDate = DateTime.Now;
                var promoCode = txtPromoCode.Text;
                var last4Digits = "1111";
                decimal amount = 1.00M;
                var numKeys = int.Parse(txtNumberKeys.Text);

                if (primaryAppUserId == -1)
                {
                    using (var db = new MyFileItDataLayer.Models.MyFileItEntities())
                    {
                        primaryAppUserId = db.APPUSERs.First().ID;
                        //salesRepId = db.SALESREPs.First().ID;
                    }
                }
                byte[] fileBytes = null;
                string imageName = null;
                if (fuImage.FileContent.Length > 0)
                {
                    imageName = fuImage.FileName;
                    fileBytes = fuImage.FileBytes;
                }

                var result = svc.AddShareKeyImage(SERVICEUSER, SERVICEPASS, primaryAppUserId, purchaseDate, promoCode, last4Digits, amount, salesRepId, numKeys, imageName, fileBytes);
                lblError.Text = result.Success ? "Keys have been added to the system" : "Error adding keys. " + result.Message;
                if (result.Success)
                {
                    txtNumberKeys.Text = "";
                    txtPromoCode.Text = "";
                }
            }
        }

        private bool validKey()
        {
            var success = true;
            var i = 0;

            if (txtPromoCode.Text.Length == 0)
            {
                lblError.Text = "Please enter a promo code";
                success = false;
            }
            if (txtNumberKeys.Text.Length == 0 || !int.TryParse(txtNumberKeys.Text, out i))
            {
                lblError.Text = "Please enter a valid number of keys to generate";
                success = false;
            }
            return success;
        }

    }
}