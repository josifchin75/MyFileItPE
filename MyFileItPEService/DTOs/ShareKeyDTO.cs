﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using MyFileItDataLayer.Models;
using MyFileItPEService.Helpers;
using MyFileItPEService;
using System.IO;

namespace MyFileItService.DTOs
{
    public class ShareKeyDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int? APPUSERID { get; set; }
        [DataMember]
        public int? PRIMARYAPPUSERID { get; set; }
        [DataMember]
        public DateTime? PURCHASEDATE { get; set; }
        [DataMember]
        public string PROMOCODE { get; set; }
        [DataMember]
        public string LAST4CC { get; set; }
        [DataMember]
        public decimal? AMOUNT { get; set; }
        [DataMember]
        public string SHAREKEYCODE { get; set; }
        [DataMember]
        public int? SALESREPID { get; set; }
        [DataMember]
        public int? PAYMENTTYPEID { get; set; }
        [DataMember]
        public DateTime? DATECREATED { get; set; }
        [DataMember]
        public string SHAREIMAGE { get; set; }
        [DataMember]
        public string SHAREIMAGEURL { get; set; }
        [DataMember]
        public string ShareImageBase64 { get; set; }
        [DataMember]
        public AppUserDTO ApplicationUser { get; set; }

        public ShareKeyDTO() { }

        public ShareKeyDTO(SHAREKEY sharekeyEF, bool skipUserInclude = false)
        {
            ID = sharekeyEF.ID;
            APPUSERID = sharekeyEF.APPUSERID;
            PRIMARYAPPUSERID = sharekeyEF.PRIMARYAPPUSERID;
            PURCHASEDATE = sharekeyEF.PURCHASEDATE;
            PROMOCODE = sharekeyEF.PROMOCODE;
            LAST4CC = sharekeyEF.LAST4CC;
            AMOUNT = sharekeyEF.AMOUNT;
            SHAREKEYCODE = sharekeyEF.SHAREKEYCODE;
            SALESREPID = sharekeyEF.SALESREPID;
            PAYMENTTYPEID = sharekeyEF.PAYMENTTYPEID;
            SHAREIMAGE = sharekeyEF.SHAREIMAGE;
            SHAREIMAGEURL = sharekeyEF.SHAREIMAGEURL;
            if (!string.IsNullOrWhiteSpace(SHAREIMAGE))
            {
                var filePath = Path.Combine(ConfigurationSettings.PromoCodeImagePath, SHAREIMAGE);
                if (File.Exists(filePath))
                {
                    ShareImageBase64 = FileHelper.FileToBase64(filePath);
                }
            }
            if (!skipUserInclude)
            {
                ApplicationUser = new AppUserDTO(sharekeyEF.APPUSER);
            }
        }

        // User-defined conversion from dto to ef 
        public static implicit operator SHAREKEY(ShareKeyDTO dto)
        {
            return new SHAREKEY()
            {
                ID = dto.ID,
                APPUSERID = dto.APPUSERID,
                PRIMARYAPPUSERID = dto.PRIMARYAPPUSERID,
                PURCHASEDATE = dto.PURCHASEDATE,
                PROMOCODE = dto.PROMOCODE,
                LAST4CC = dto.LAST4CC,
                AMOUNT = dto.AMOUNT,
                SHAREKEYCODE = dto.SHAREKEYCODE,
                SALESREPID = dto.SALESREPID,
                PAYMENTTYPEID = dto.PAYMENTTYPEID,
                SHAREIMAGE = dto.SHAREIMAGE,
                DATECREATED = dto.DATECREATED,
                SHAREIMAGEURL = dto.SHAREIMAGEURL
            };
        }
    }
}