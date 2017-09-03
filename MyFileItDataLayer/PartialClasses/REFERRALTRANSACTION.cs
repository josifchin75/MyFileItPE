using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFileItDataLayer.Helpers;

namespace MyFileItDataLayer.Models
{
    public partial class REFERRALTRANSACTION
    {

        public void SetNewID()
        {
            using (var db = new MyFileItEntities())
            {
                var sk = db.REFERRALTRANSACTIONs.OrderByDescending(o => o.ID).FirstOrDefault();
                this.ID = sk == null ? 1 : sk.ID + 1;
            }
        }

        public void FormatData()
        {
            COMMISSIONPAID = COMMISSIONPAID.ConvertToFirebirdBoolean();
        }

        public bool UpdateObject(REFERRALTRANSACTION updated)
        {
            var result = false;

            ID = updated.ID;
            REFERRALID = updated.REFERRALID;
            SHAREKEYID = updated.SHAREKEYID;
            DATECREATED = updated.DATECREATED;
            COMMISSIONPAID = updated.COMMISSIONPAID;
            COMMISSIONAMOUNT = updated.COMMISSIONAMOUNT;

            result = true;
            return result;
        }
    }
}
