using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MyFileItDataLayer.Models;

namespace MyFileItPEService.DTOs
{
    [DataContract]
    public class ReferralTransactionDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int REFERRALID { get; set; }
        [DataMember]
        public int? SHAREKEYID { get; set; }
        [DataMember]
        public DateTime? DATECREATED { get; set; }
        [DataMember]
        public string COMMISSIONPAID { get; set; }
        [DataMember]
        public decimal? COMMISSIONAMOUNT { get; set; }

        public ReferralTransactionDTO()
        {
        }

        public ReferralTransactionDTO(REFERRALTRANSACTION referralTransactionEF)
        {
            ID = referralTransactionEF.ID;
            REFERRALID = referralTransactionEF.REFERRALID;
            SHAREKEYID = referralTransactionEF.SHAREKEYID;
            DATECREATED = referralTransactionEF.DATECREATED;
            COMMISSIONPAID = referralTransactionEF.COMMISSIONPAID;
            COMMISSIONAMOUNT = referralTransactionEF.COMMISSIONAMOUNT;
        }
        // User-defined conversion from dto to ef 
        public static implicit operator REFERRALTRANSACTION(ReferralTransactionDTO dto)
        {
            return new REFERRALTRANSACTION()
            {
                ID = dto.ID,
                REFERRALID = dto.REFERRALID,
                SHAREKEYID = dto.SHAREKEYID,
                DATECREATED = dto.DATECREATED,
                COMMISSIONPAID = dto.COMMISSIONPAID,
                COMMISSIONAMOUNT = dto.COMMISSIONAMOUNT
            };
        }
    }
}
