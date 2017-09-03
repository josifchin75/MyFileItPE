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
    public class ReferralDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string EMAILADDRESS { get; set; }
        [DataMember]
        public string PASSWORD { get; set; }
        [DataMember]
        public string REFERRALCODE { get; set; }
        [DataMember]
        public string FIRSTNAME { get; set; }
        [DataMember]
        public string LASTNAME { get; set; }
        [DataMember]
        public string ADDRESS1 { get; set; }
        [DataMember]
        public string ADDRESS2 { get; set; }
        [DataMember]
        public string CITY { get; set; }
        [DataMember]
        public string STATECODE { get; set; }
        [DataMember]
        public string ZIPCODE { get; set; }
        [DataMember]
        public string MOBILEPHONE { get; set; }
        [DataMember]
        public decimal? DISCOUNTAMOUNT { get; set; }
        [DataMember]
        public string IMAGENAME { get; set; }
        [DataMember]
        public string ROUTINGNUMBER { get; set; }
        [DataMember]
        public string CHECKINGACCOUNTNUMBER { get; set; }
        [DataMember]
        public DateTime? DATECREATED { get; set; }
        [DataMember]
        public DateTime? LASTLOGINDATE { get; set; }
        [DataMember]
        public decimal? YTDCommission { get; set; }
        [DataMember]
        public decimal? TotalCommission { get; set; }

        [DataMember]
        public List<ReferralTransactionDTO> ReferralTransactions { get; set; }

        public ReferralDTO()
        {
            ReferralTransactions = new List<ReferralTransactionDTO>();
        }

        public ReferralDTO(REFERRAL referralEF)
        {
            ID = referralEF.ID;
            EMAILADDRESS = referralEF.EMAILADDRESS;
            PASSWORD = referralEF.PASSWORD;
            REFERRALCODE = referralEF.REFERRALCODE;
            FIRSTNAME = referralEF.FIRSTNAME;
            LASTNAME = referralEF.LASTNAME;
            ADDRESS1 = referralEF.ADDRESS1;
            ADDRESS2 = referralEF.ADDRESS2;
            CITY = referralEF.CITY;
            STATECODE = referralEF.STATECODE;
            ZIPCODE = referralEF.ZIPCODE;
            MOBILEPHONE = referralEF.MOBILEPHONE;
            DISCOUNTAMOUNT = referralEF.DISCOUNTAMOUNT;
            IMAGENAME = referralEF.IMAGENAME;
            ROUTINGNUMBER = referralEF.ROUTINGNUMBER;
            CHECKINGACCOUNTNUMBER = referralEF.CHECKINGACCOUNTNUMBER;
            DATECREATED = referralEF.DATECREATED;
            LASTLOGINDATE = referralEF.LASTLOGINDATE;

            YTDCommission = 0m;
            TotalCommission = 0m;
            //load up all sub transactions
            ReferralTransactions = new List<ReferralTransactionDTO>();
            referralEF.REFERRALTRANSACTIONs.ToList().ForEach(rt =>
            {
                var dto = new ReferralTransactionDTO(rt);
                ReferralTransactions.Add(dto);
                if (dto.COMMISSIONPAID == "1")
                {
                    TotalCommission += dto.COMMISSIONAMOUNT;
                    if (dto.DATECREATED.Value.Year == DateTime.Now.Year)
                    {
                        YTDCommission += dto.COMMISSIONAMOUNT;
                    }
                }
            });
        }
        // User-defined conversion from dto to ef 
        public static implicit operator REFERRAL(ReferralDTO dto)
        {
            return new REFERRAL()
            {
                ID = dto.ID,
                EMAILADDRESS = dto.EMAILADDRESS,
                PASSWORD = dto.PASSWORD,
                REFERRALCODE = dto.REFERRALCODE,
                FIRSTNAME = dto.FIRSTNAME,
                LASTNAME = dto.LASTNAME,
                ADDRESS1 = dto.ADDRESS1,
                ADDRESS2 = dto.ADDRESS2,
                CITY = dto.CITY,
                STATECODE = dto.STATECODE,
                ZIPCODE = dto.ZIPCODE,
                MOBILEPHONE = dto.MOBILEPHONE,
                DISCOUNTAMOUNT = dto.DISCOUNTAMOUNT,
                IMAGENAME = dto.IMAGENAME,
                ROUTINGNUMBER = dto.ROUTINGNUMBER,
                CHECKINGACCOUNTNUMBER = dto.CHECKINGACCOUNTNUMBER,
                DATECREATED = dto.DATECREATED,
                LASTLOGINDATE = dto.LASTLOGINDATE
            };
        }
    }
}
