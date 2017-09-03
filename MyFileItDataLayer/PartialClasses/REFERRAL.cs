using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileItDataLayer.Models
{
    public partial class REFERRAL
    {
        public void SetNewID()
        {
            using (var db = new MyFileItEntities())
            {
                var sk = db.REFERRALs.OrderByDescending(o => o.ID).FirstOrDefault();
                this.ID = sk == null ? 1 : sk.ID + 1;
                this.REFERRALCODE = CreateReferralCode();
            }
        }

        private string CreateReferralCode()
        {
            //create the share key code
            //use date time and a count
            var result = (FIRSTNAME.Length > 1 ? FIRSTNAME.Substring(0,1) : FIRSTNAME) + (LASTNAME.Length > 3 ? LASTNAME.Substring(0,3): LASTNAME);
            
            var curCnt = 1;
            var testResult = result + curCnt.ToString().PadLeft(3, '0');
            using (var db = new MyFileItEntities())
            {
                while (db.REFERRALs.Any(r => r.REFERRALCODE.Equals(testResult, StringComparison.CurrentCultureIgnoreCase)))
                {
                    testResult = result + curCnt.ToString().PadLeft(3, '0');
                    if (curCnt > 1000000)
                    {
                        result = "";
                        testResult = "";
                        break;
                    }
                    curCnt++;
                }
                result = testResult;
            }

            return result;
        }

        public bool UpdateObject(REFERRAL updated)
        {
            var result = false;

            ID = updated.ID;
            EMAILADDRESS = updated.EMAILADDRESS;
            PASSWORD = updated.PASSWORD;
            REFERRALCODE = updated.REFERRALCODE;
            FIRSTNAME = updated.FIRSTNAME;
            LASTNAME = updated.LASTNAME;
            ADDRESS1 = updated.ADDRESS1;
            ADDRESS2 = updated.ADDRESS2;
            CITY = updated.CITY;
            STATECODE = updated.STATECODE;
            ZIPCODE = updated.ZIPCODE;
            MOBILEPHONE = updated.MOBILEPHONE;
            DISCOUNTAMOUNT = updated.DISCOUNTAMOUNT;
            IMAGENAME = updated.IMAGENAME;
            ROUTINGNUMBER = updated.ROUTINGNUMBER;
            CHECKINGACCOUNTNUMBER = updated.CHECKINGACCOUNTNUMBER;
            DATECREATED = updated.DATECREATED;
            LASTLOGINDATE = updated.LASTLOGINDATE;

            result = true;
            return result;
        }
    }
}
