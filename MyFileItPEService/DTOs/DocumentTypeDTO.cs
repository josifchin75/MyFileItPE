using MyFileItDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyFileItService.DTOs
{
    [DataContract]
    public class DocumentTypeDTO
    {
        public DocumentTypeDTO()
        { 
        }

        public DocumentTypeDTO(DOCUMENTTYPE dt) : base()
        {
            ID = dt.ID;
            NAME = dt.NAME;
            APPUSERID = dt.APPUSERID;
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string NAME { get; set; }
        [DataMember]
        public int? APPUSERID { get; set; }
    }
}
