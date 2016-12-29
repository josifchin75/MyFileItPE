using MyFileItDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileItDataLayer.Models
{
    public partial class DOCUMENTTYPE
    {
        public void SetNewID()
        {
            using (var db = new MyFileItEntities())
            {
                var doc = db.DOCUMENTTYPEs.OrderByDescending(d => d.ID).FirstOrDefault();
                this.ID = doc == null ? 1 : doc.ID + 1;
            }
        }

        public bool UpdateObject(DOCUMENTTYPE updated)
        {
            var result = false;

            ID = updated.ID;
            NAME = updated.NAME;
            APPUSERID = updated.APPUSERID;
            result = true;

            return result;
        }
    }
}
