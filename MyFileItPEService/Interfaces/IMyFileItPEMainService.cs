﻿using MyFileItPEService.DTOs;
using MyFileItPEService.FileItMainService;
using MyFileItService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyFileItPEService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyFileItPEMainService" in both code and config file together.
    [ServiceContract]
    public interface IMyFileItPEMainService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        bool InitService();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetReferenceData(string user, string pass, string referenceTableName);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetDocumentTypes(string user, string pass, int appUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddDocumentType(string user, string pass, int appUserId, string documentType);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult UpdateDocumentType(string user, string pass, int id, string documentType);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUserOrganizations(string user, string pass, int appUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetOrganizations(string user, string pass, int? organizationId, string nameLookup);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddOrganization(string user, string pass, OrganizationDTO organization);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult UpdateOrganization(string user, string pass, OrganizationDTO organization);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult RemoveOrganization(string user, string pass, int organizationId);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult UploadFileCabinetDocument(string user, string pass, int appUserId, string filename, string base64Image, FileCabinetDocumentDTO doc);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddEmergencyShare(string user, string pass, int appUserId, int[] fileCabinetDocumentIds, string emergencyEmailAddress, string emailMessage);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AssociateDocumentsToTeamEventDocuments(string user, string pass, List<AssociateDocumentDTO> associations);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult ResendAssociatedDocuments(string user, string pass, int appUserId, int? teamEventId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AssociateDocumentToTeamEvent(string user, string pass, int appUserId, int organizationId, int fileCabinetDocumentId, int teamEventId, string comment, bool emergency, bool remove);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetTeamEventsByAppUser(string user, string pass, int appUserId, int? organizationId, int? teamEventId, string name);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetTeamEventsByCoach(string user, string pass, int appUserId, string name);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetTeamEvents(string user, string pass, int? organizationId, int? teamEventId, string name);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult ValidateTeamEvent(string user, string pass, string teamEventName);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddTeamEvent(string user, string pass, TeamEventDTO teamEvent);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult UpdateTeamEvent(string user, string pass, TeamEventDTO teamEvent);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult RemoveTeamEvent(string user, string pass, int teamEventId);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        bool CheckAppUserExists(string user, string pass, string appUserName);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult LoginAppUser(string user, string pass, string appUserName, string appUserPass);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult ForgotPassword(string user, string pass, string emailAddress);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUsers(string user, string pass, int? appUserId, string nameLookup);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAllAppUsers(string user, string pass, int? organizationId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUsersByEmail(string user, string pass, string userName, string emailAddress, string userPassword);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUsersByPhoneNumber(string user, string pass, string phoneNumber);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUsersByNameSexEmail(string user, string pass, int appUserId, int teamEventId, string firstName, string lastName, string parentEmailAddress, string sex);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetCoachMembers(string user, string pass, int appUserId, int? organizationId, int? teamEventId, string nameLookup, string parentEmailAddress);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddAppUser(string user, string pass, AppUserDTO appUser, int? autoSignUpOrganizationId = null);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AssociateAppUserToOrganization(string user, string pass, int appUserId, int appUserTypeId, int organizationId, DateTime startDate, DateTime expiresDate, int? yearCode, int sportTypeId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult RemoveAppUserFromOrganization(string user, string pass, int appUserId, int organizationId);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult UpdateAppUser(string user, string pass, AppUserDTO appUser);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult RemoveAppUser(string user, string pass, int appUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult UpdateAppUserStatus(string user, string pass, int appUserId, int appUserStatusId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetFamilyUsers(string user, string pass, int primaryAppUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        FileCabinetDocumentDTO GetSingleDocument(string user, string pass, FileCabinetDocumentSingleDTO lookup);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUserDocumentsList(string user, string pass, int appUserId, int? teamEventId, List<int?> downloadedDocumentIds);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUserDocumentsListNoImages(string user, string pass, int appUserId, int? teamEventId, List<int?> downloadedDocumentIds);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUserDocumentsThumbs(string user, string pass, List<int?> lookupDocumentIds);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUserDocuments(string user, string pass, int appUserId, int? teamEventId, List<int?> downloadedDocumentIds, bool? thumbsOnly);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetFamilyDocuments(string user, string pass, int primaryAppUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult DeleteAppUserDocument(string user, string pass, int appUserId, string documentId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        string GetInvitationToShareEmailText(string user, string pass);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult SendInvitationEmail(string user, string pass, string emailAddress, string message);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetSentEmails(string user, string pass, string toEmailAddress);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult SendReminderEmails();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAppUserTeamEventDocumentsByTeamEvent(string user, string pass, int appUserId, int teamEventId);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetTeamEventPlayerRosters(string user, string pass, int? teamEventPlayerRosterId, int? teamEventId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddTeamEventPlayerRoster(string user, string pass, TeamEventPlayerRosterDTO teamEventPlayerRoster);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult UpdateTeamEventPlayerRoster(string user, string pass, TeamEventPlayerRosterDTO teamEventPlayerRoster);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult RemoveTeamEventPlayerRoster(string user, string pass, int teamEventPlayerRosterId);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetSalesReps(string user, string pass, int? salesRepId, string nameLookup, int? salesRepStatusId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult LoginSalesRep(string user, string pass, string emailAddress, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddSalesRep(string user, string pass, SalesRepDTO salesRep);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult UpdateSalesRep(string user, string pass, SalesRepDTO salesRep);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult ChangeSalesRepStatus(string user, string pass, int salesRepId, int salesRepStatusId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult RemoveSalesRep(string user, string pass, int salesRepId, int salesRepIdReplacement);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetCoaches(string user, string pass, int? coachId, string nameLookup, int? appUserId, int? organizationId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetCoachesByOrganizationId(string user, string pass, int organizationId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetCoachesByTeamEventId(string user, string pass, int teamEventId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddCoach(string user, string pass, int appUserId, int organizationId, DateTime startDate, DateTime expiresDate, int? yearCode, int sportTypeId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult SendAddCoachEmail(string user, string pass, string emailAddress, string subject, string bodyMessage, List<string> ccEmailAddresses);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult RemoveCoach(string user, string pass, int appUserId, int organizationId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AssociateCoachToTeamEvent(string user, string pass, CoachDTO coach);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult RemoveCoachFromTeamEvent(string user, string pass, int appUserId, int teamEventId);

        //[OperationContract]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        //MyFileItResult UpdateCoach(string user, string pass, CoachDTO coach);

        //[OperationContract]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        //MyFileItResult AssociateCoachToUser(string user, string pass, int coachId, int appUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult RemoveCoachFromCurrentAppUser(string user, string pass, int coachId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddShareKey(string user, string pass, int primaryAppUserId, DateTime purchaseDate, string promoCode, string last4Digits, decimal amount, int salesRepId, int numKeys, string imageName, string imageUrl);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddShareKeyImage(string user, string pass, int primaryAppUserId, DateTime purchaseDate, string promoCode, string last4Digits, decimal amount, int salesRepId, int numKeys, string uploadImageName, byte[] image, string imageUrl);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddShareKeyOrganization(string user, string pass, int primaryAppUserId, int organizationId, DateTime purchaseDate, string promoCode, string last4Digits, decimal amount, int salesRepId, int numKeys, string imageName, string imageUrl);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddShareKeyImageOrganization(string user, string pass, int primaryAppUserId, int organizationId, DateTime purchaseDate, string promoCode, string last4Digits, decimal amount, int salesRepId, int numKeys, string uploadImageName, byte[] image, string imageUrl);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult UpdateShareKey(string user, string pass, ShareKeyDTO shareKey);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AssociateShareKeyToUser(string user, string pass, int appUserId, int shareKeyId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetShareKeys(string user, string pass, int primaryAppUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetAvailableShareKeysByPromoCodeAndPrimaryUser(string user, string pass, int primaryAppUserId, string promocode);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult AddPaymentHistory(string user, string pass, PaymentHistoryDTO coach);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        MyFileItResult GetPaymentHistory(string user, string pass, int primaryAppUserId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        FileItResponse Authenticate(string user, string pass);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        Dictionary<string, string> GetCabinets(string user, string pass, string targetuser, bool allavailable);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        FileItCabinet GetCabinet(string user, string pass, string cabinetId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        FileItResponse GetDocuments(string user, string pass, string cabinetid, FileItDocumentLookup[] lookups, bool includeThumbs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        FileItResponse UploadDocuments(string user, string pass, string cabinetId, FileItDocument[] documents);

        /*********************
       * REFERRALS - DIRECT AMBASSADOR
       * ******************/
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult GetReferrals(string user, string pass);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult GetReferral(string user, string pass, int referralId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult GetReferralByEmail(string user, string pass, string emailAddress);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult AddReferral(string user, string pass, ReferralDTO referral);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult UpdateReferral(string user, string pass, ReferralDTO referral);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult LoginReferral(string user, string pass, string referralEmailAddress, string referralPassword);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult AddReferralTransaction(string user, string pass, ReferralTransactionDTO referralTransaction);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult UpdateReferralCommissionPaid(string user, string pass, int referralTransactionId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult CheckReferralCode(string user, string pass, string referralCode);

        /*********************
         * REPORTS
         * ******************/
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MyFileItResult GetEventPlayerStatusReport(string user, string pass, int teamEventId);
    }

}
