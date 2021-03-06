﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFileItDataLayer.Helpers;

namespace MyFileItDataLayer.Models
{
    public partial class SHAREDOCUMENT
    {
        public SHAREDOCUMENT() { }

        public SHAREDOCUMENT(int appUserId, int fileCabinetDocumentId, int? teamEventId, string comment, bool emergency, string emergencyEmailAddress, ref string errorMessage)
        {
            using (var db = new MyFileItEntities())
            {
                //var teamEventDocument = teamEventDocumentId != null ? db.TEAMEVENTDOCUMENTs.SingleOrDefault(td => td.ID == teamEventDocumentId) : null;
                var teamEvent = teamEventId != null ? db.TEAMEVENTs.SingleOrDefault(t => t.ID == teamEventId) : null;
                var fileCabinetDocument = db.FILECABINETDOCUMENTs.SingleOrDefault(d => d.ID == fileCabinetDocumentId);

                if ((teamEvent == null && !emergency) || fileCabinetDocument == null)
                {
                    if (teamEvent == null) {
                        errorMessage += "Event  not found.";
                    }
                    if (fileCabinetDocument == null)
                    {
                        errorMessage += "Document not found.";
                    }
                    //if (organization == null)
                    //{
                    //    errorMessage += "Organization not found.";
                    //}
                }
                else {
                    SetNewID();
                    FILECABINETDOCUMENTID = fileCabinetDocumentId;
                    TEAMEVENTID = teamEventId;
                    DOCUMENTID = fileCabinetDocument.DOCUMENTID;
                    APPUSERID = appUserId;
                    SCANDATE = fileCabinetDocument.SCANDATE;
                    COMMENT = comment;
                    LOCATION = "";//TODO: not sure about this field
                    DOCUMENTTYPEID = fileCabinetDocument.DOCUMENTTYPEID;
                    DOCUMENTSTATUSID = fileCabinetDocument.DOCUMENTSTATUSID;
                    EMERGENCY = emergency.ConvertToFirebirdString();
                    EMERGENCYEMAILADDRESS = emergencyEmailAddress;
                    CABINETID = fileCabinetDocument.CABINETID;//organization.CABINETID;
                    DOCUMENTDATE = fileCabinetDocument.DOCUMENTDATE;
                    DATECREATED = DateTime.Now;

                    VIEWDOCUMENTKEY = Guid.NewGuid().ToString();
                    ISACTIVE = true.ConvertToFirebirdString();
                }
            }
        }

        public void SetNewID()
        {
            using (var db = new MyFileItEntities())
            {
                var sk = db.SHAREDOCUMENTs.OrderByDescending(o => o.ID).FirstOrDefault();
                this.ID = sk == null ? 1 : sk.ID + 1;
            }
        }

        public bool UpdateObject(SHAREDOCUMENT updated)
        {
            var result = false;

            FILECABINETDOCUMENTID = updated.FILECABINETDOCUMENTID;
            TEAMEVENTID = updated.TEAMEVENTID;
            DOCUMENTID = updated.DOCUMENTID;
            APPUSERID = updated.APPUSERID;
            SCANDATE = updated.SCANDATE;
            COMMENT = updated.COMMENT;
            LOCATION = updated.LOCATION;
            DOCUMENTTYPEID = updated.DOCUMENTTYPEID;
            DOCUMENTSTATUSID = updated.DOCUMENTSTATUSID;
            EMERGENCY = updated.EMERGENCY;
            EMERGENCYEMAILADDRESS = updated.EMERGENCYEMAILADDRESS;
            CABINETID = updated.CABINETID;
            DOCUMENTDATE = updated.DOCUMENTDATE;
            DATECREATED = updated.DATECREATED;

            VERIFIEDDATE = updated.VERIFIEDDATE;
            VERIFIEDAPPUSERID = updated.VERIFIEDAPPUSERID;

            result = true;
            return result;
        }
    }
}
