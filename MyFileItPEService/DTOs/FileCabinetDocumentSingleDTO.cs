using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using MyFileItDataLayer.Models;
using MyFileItPEService.Helpers;

namespace MyFileItService.DTOs
{
    [DataContract]
    public class FileCabinetDocumentSingleDTO
    {
        [DataMember]
        public int FILECABINETDOCUMENTID { get; set; }
        [DataMember]
        public int? TEAMEVENTID { get; set; }
        [DataMember]
        public int? VerifiedAppUserId { get; set; }
    }
}
