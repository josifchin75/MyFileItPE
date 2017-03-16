using MyFileItDataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
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
                        // ddlOrganization.Items.Add(new ListItem(o.NAME, appUserObj.APPUSERID.ToString()));
                        ddlOrganization.Items.Add(new ListItem(o.NAME, appUserObj.ORGANIZATION.ID.ToString()));
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
                var organizationId = int.Parse(ddlOrganization.SelectedValue);
                var primaryAppUserId = -1;//int.Parse(ddlOrganization.SelectedValue);
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
                        //primaryAppUserId = db.APPUSERs.First().ID;
                        primaryAppUserId = db.APPUSERORGANIZATIONs.First(auo => auo.ORGANIZATIONID == organizationId).APPUSERID;
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

                var result = svc.AddShareKeyImageOrganization(SERVICEUSER, SERVICEPASS, primaryAppUserId, organizationId, purchaseDate, promoCode, last4Digits, amount, salesRepId, numKeys, imageName, fileBytes);
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

        protected void btnViewCodes_Click(object sender, EventArgs e)
        {
            litCodes.Text = "";
            var organizationId = int.Parse(ddlOrganization.SelectedValue);
            if (organizationId > -1)
            {
                // var organizationName = ddlOrganization.SelectedItem.Text;
                using (var db = new MyFileItDataLayer.Models.MyFileItEntities())
                {
                    // var primaryAppUserId = int.Parse(ddlOrganization.SelectedValue);
                    var organization = db.ORGANIZATIONs.Single(au => au.ID == organizationId);
                    var sql = CreateSql(organization, false);
                    var dt = FireBirdHelper.GenericSelect(sql, db.Database.Connection.ConnectionString);
                    litCodes.Text = DisplayTableHtml(dt, false);

                    sql = CreateSql(organization, true);
                    dt = FireBirdHelper.GenericSelect(sql, db.Database.Connection.ConnectionString);
                    litCodes.Text += DisplayTableHtml(dt, true);
                }
            }
        }

        private string DisplayTableHtml(DataTable dt, bool unUsed)
        {
            var result = "<h2>" + (unUsed ? "Unused " : "") + "Total Promocodes For Company</h2><hr/>";
            result += "<table><tr><th>Code</th><th>Count</th></tr>";
            foreach (DataRow dr in dt.Rows)
            {
                result += "<tr>";
                result += "<td>" + dr["Promocode"].ToString() + "</td>";
                result += "<td>" + dr["Cnt"].ToString() + "</td>";
                result += "</tr>";
            }
            result += "</table>";

            return result;
        }

        private string CreateSql(MyFileItDataLayer.Models.ORGANIZATION organization, bool unUsed)
        {
            var result = "";
            result += "select promocode, count(*) as cnt from sharekey where OrganizationId=" + organization.ID + (unUsed ? " and AppUserId is null " : "") + " group by Promocode";
            return result;
        }

    }
}